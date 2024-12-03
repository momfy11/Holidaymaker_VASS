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

    public async void RemoveBooking(int id)
    {
        await using (var cmd2 = _database.CreateCommand("DELETE FROM bookingsxextras where booking_id = $1"))
        {
            cmd2.Parameters.AddWithValue(id);
            int result = await cmd2.ExecuteNonQueryAsync();
            Console.WriteLine(result);
        }
        
        await using (var cmd = _database.CreateCommand("DELETE FROM bookings WHERE id = $1"))
        {
            cmd.Parameters.AddWithValue(id);
            int result = await cmd.ExecuteNonQueryAsync();
            Console.WriteLine(result);
        }
    }

    public async Task SelectUserToEdit()
    {
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
    }
    
    private async Task<List<AccountModel>> GetUsersAsync()
    {
        var users = new List<AccountModel>();

        await using (var cmd = _database.CreateCommand($"SELECT * FROM account"))
        {
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    users.Add(new AccountModel
                    {
                        AccountId = reader.GetInt32(0),
                        Phone = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
            }
        }

        return users;
    }

    public async Task<List<BookingsModel>> GetBookingsAsync(int AccountId)
    {
        var bookings = new List<BookingsModel>();
        
        await using (var cmd = _database.CreateCommand($"SELECT * FROM bookings WHERE account = {AccountId}"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                bookings.Add(new BookingsModel
                {
                    Id = reader.GetInt32(0),
                    RoomId = reader.GetInt32(1),
                    booking_start = reader.GetDateTime(2),
                    booking_end = reader.GetDateTime(3),
                    AccountId = reader.GetInt32(4),
                    total_price = reader.GetInt32(5)
                });
            }
        }

        return bookings;
    }

    public async Task<List<ExtraModel>> GetBookingsXExtrasAsync(int bookingId)
    {
        var extras = new List<ExtraModel>();

        await using (var cmd = _database.CreateCommand($"SELECT * FROM extras JOIN bookingsxextras ON extras_id = id WHERE booking_id = {bookingId}"))
        {
            cmd.Parameters.AddWithValue(bookingId);

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
        }
        return extras;
    }
}