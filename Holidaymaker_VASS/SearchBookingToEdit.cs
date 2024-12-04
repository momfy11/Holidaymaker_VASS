using System.Data;
using System.Transactions;
using app.Classes;
using Npgsql;
namespace app;

public class SearchBookingToEdit
{
    private NpgsqlDataSource _database;

    public SearchBookingToEdit(NpgsqlDataSource database)
    {
        _database = database;
    }
    
    public async Task EditBookingsMenu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nSelect User Menu");
            Console.WriteLine("1. Select User(Account) to edit");
            Console.WriteLine("9. Exit to Main Menu");
            Console.WriteLine("Choose An Option");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await SelectUserToEdit();
                    break;
                case "9":
                    isRunning = false;
                    Console.WriteLine("Return to main menu..");
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please choose 1 or 9.");
                    break;
            }
        }
    }
    
    public async Task SelectUserToEdit()
    {
        #region old-Code
        /*
        Console.WriteLine("\nGetting Users(Accounts) from database");
        var users = await GetUsersAsync();

        if (!users.Any())
        {
            Console.WriteLine("No accounts found!");
            return;
        }
        
        Console.WriteLine("\nAvailable Accounts:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Email: {users[i].Email}, Phone: {users[i].Phone} (ID: {users[i].AccountId})");
        }
        Console.WriteLine("Select User by Number:");
        if (!int.TryParse(Console.ReadLine(), out int userIndex) || userIndex < 1 || userIndex > users.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        var selectedUser = users[userIndex -1];
        
        Console.WriteLine("\nConnecting Bookings...");
        var connectedBookings = await GetBookingsAsync(selectedUser.AccountId);

        for (int i = 0; i < connectedBookings.Count; i++)
        {
            var booking = connectedBookings[i];
            Console.WriteLine($"{i + 1}. Room Details: ");
            Console.WriteLine($"    Booking Id: {booking.Id}");
            Console.WriteLine($"    Account Id: {booking.AccountId}");
            Console.WriteLine($"    Booking Started: {booking.booking_start}");
            Console.WriteLine($"    Booking Ending: {booking.booking_end}");
            Console.WriteLine($"    Room Id: {booking.RoomId}");
            Console.WriteLine($"    Price: {booking.total_price}");
        }
        Console.WriteLine("Delete booking by Number:");
        if (!int.TryParse(Console.ReadLine(), out int bookingIndex))
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        
        RemoveBooking(bookingIndex);
        */
        #endregion

        var bookings = await GetAllBookingsAsync();
        Console.WriteLine("\nAvailable Bookings: ");
        for (int i = 0; i < bookings.Count; i++)
        {
            Console.WriteLine($"{i +1}. Booking Id: {bookings[i].Id}, Account Id: {bookings[i].AccountId}, Total Price: {bookings[i].total_price}");
        }
        
        Console.WriteLine("Select a booking by Number: ");
        if (!int.TryParse(Console.ReadLine(), out int bookingIndex) || bookingIndex < 0 ||
            bookingIndex > bookings.Count)
        {
            Console.WriteLine("Invalid Section!");
            return;
        }

        var selectedBooking = bookings[bookingIndex - 1];
        Console.WriteLine($"Selected Booking Id: {selectedBooking.Id}");

        await ManageExtrasForBooking(selectedBooking.Id);
    }
    
    private async Task ManageExtrasForBooking(int bookingId)
    {
        bool isEditing = true;

        while (isEditing)
        {
            Console.WriteLine("\nManage Extras for Booking");
            Console.WriteLine("1. Add Extra");
            Console.WriteLine("2. Remove Extra");
            Console.WriteLine("3. Delete Booking");
            Console.WriteLine("9. Return to Edit Menu");
            Console.Write("Choose an Option: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await AddExtraToBooking(bookingId);
                    break;
                case "2":
                    await RemoveExtraFromBooking(bookingId);
                    break;
                case "3":
                    await DeleteBookingAsync(bookingId);
                    isEditing = false;
                    break;;
                case "9":
                    isEditing = false;
                    Console.WriteLine("Returning to Edit Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid Option: Please choose 1,2,3 or 9.");
                    break;
            }
        }
    }

    private async Task AddExtraToBooking(int bookingId)
    {
        var availableExtras = await GetExtrasAsync();
        Console.WriteLine("\nAvailable Extras: ");
        for (int i = 0; i < availableExtras.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableExtras[i].Name} ( Price: {availableExtras[i].Price})");
        }
        
        Console.Write("Select an Extra to add by Number: ");
        if (!int.TryParse(Console.ReadLine(), out int extraIndex) || extraIndex < 1 ||
            extraIndex > availableExtras.Count)
        {
            Console.WriteLine("Invalid Section!");
            return;
        }

        var selectedExtra = availableExtras[extraIndex - 1];

        await using (var cmd = _database.CreateCommand(
                         $"INSERT INTO bookingsxextras (booking_id, extras_id) VALUES ($1, $2)"))
        {
            cmd.Parameters.AddWithValue(bookingId);
            cmd.Parameters.AddWithValue(selectedExtra.ExtraId);
            await cmd.ExecuteNonQueryAsync();
        }

        await using (var updateCMD =
                     _database.CreateCommand($"UPDATE bookings SET total_price = total_price + $1 WHERE id = $2"))
        {
            updateCMD.Parameters.AddWithValue(selectedExtra.Price);
            updateCMD.Parameters.AddWithValue(bookingId);
            await updateCMD.ExecuteNonQueryAsync();
        }
        
        Console.WriteLine($"Added {selectedExtra.Name} (Price: {selectedExtra.Price}) to Booking Id: {bookingId}");
    }

    private async Task RemoveExtraFromBooking(int bookingId)
    {
        var currentExtras = await GetBookingsXExtrasAsync(bookingId);
        if (!currentExtras.Any())
        {
            Console.WriteLine("No Extras to remove from this booking.");
            return;
        }
        
        Console.WriteLine("\nCurrent Extras: ");
        for (int i = 0; i < currentExtras.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {currentExtras[i].Name} ( Price: {currentExtras[i].Price})");
        }
        
        Console.WriteLine("Select an Extra to remove by Number: ");
        if (!int.TryParse(Console.ReadLine(), out int extraIndex) || extraIndex < 1 ||
            extraIndex > currentExtras.Count)
        {
            Console.WriteLine("Invalid Section!");
            return;
        }

        var selectedExtra = currentExtras[extraIndex - 1];
        await using (var cmd = _database.CreateCommand(
                         "DELETE FROM bookingsxextras WHERE booking_id = $1 AND extras_id = $2"))
        {
            cmd.Parameters.AddWithValue(bookingId);
            cmd.Parameters.AddWithValue(selectedExtra.ExtraId);

            await cmd.ExecuteNonQueryAsync();
            Console.WriteLine($"Removed {selectedExtra.Name} from Booking Id: {bookingId}");
        }
    }
    
    private async Task<List<BookingsModel>> GetAllBookingsAsync()
    {
        var bookings = new List<BookingsModel>();
        await using (var cmd = _database.CreateCommand("SELECT * FROM bookings"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                bookings.Add(new BookingsModel
                {
                    Id = reader.GetInt32(0),
                    AccountId = reader.GetInt32(4),
                    total_price = reader.GetInt32(5)
                });
            }
        }

        return bookings;
    }

    private async Task<List<ExtraModel>> GetExtrasAsync()
    {
        var extras = new List<ExtraModel>();
        await using (var cmd = _database.CreateCommand("SELECT * FROM extras"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                extras.Add(new ExtraModel
                {
                    ExtraId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetInt32(2)
                });
            }
        }

        return extras;
    }

    private async Task<List<ExtraModel>> GetBookingsXExtrasAsync(int bookingId)
    {
        var extras = new List<ExtraModel>();

        try
        {
            await using (var cmd = _database.CreateCommand(
                             @"SELECT extras.id, extras.name, extras.price 
                            FROM bookingsxextras 
                            INNER JOIN extras ON bookingsxextras.extras_id = extras.id 
                            WHERE bookingsxextras.booking_id = @bookingId"))
            {
                cmd.Parameters.AddWithValue("@bookingId", bookingId);

                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        extras.Add(new ExtraModel
                        {
                            ExtraId = reader.GetInt32(reader.GetOrdinal("id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Price = reader.GetInt32(reader.GetOrdinal("price"))
                        });
                    }
                }
            }
        }
        catch (NpgsqlException npgEx)
        {
            Console.WriteLine($"Database error: {npgEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }

        return extras;
    }

    private async Task DeleteBookingAsync(int bookingId)
    {
        await using var connection = await _database.OpenConnectionAsync();
        await using var transaction = await connection.BeginTransactionAsync();

        try
        {
            await using (var cmd = _database.CreateCommand(
                             $"DELETE FROM bookingsxextras WHERE booking_id = {bookingId}"))
            {
                cmd.Parameters.AddWithValue(bookingId);
                await cmd.ExecuteNonQueryAsync();
            }

            await using (var cmd = _database.CreateCommand(
                             $"DELETE FROM bookings WHERE id = {bookingId}"))
            {
                cmd.Parameters.AddWithValue(bookingId);
                await cmd.ExecuteNonQueryAsync();
            }

            await transaction.CommitAsync();
            Console.WriteLine($"Booking Id: {bookingId} and associtated extras were successfully deleted.");
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine($"Failed to delete Booking Id: {bookingId}: {ex.Message}");
        }
    }
}