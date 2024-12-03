namespace Holidaymaker_VASS
{
    using Npgsql;
    using System;
    using System.Threading.Tasks;

    public class ShowUserBookings
    {
        private readonly NpgsqlDataSource _database;
        
        public ShowUserBookings(NpgsqlDataSource database)
        {
            _database = database;
        }
        public async Task ShowUserList()
        {
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT * FROM \"user\""))
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No users found.");
                        return;
                    }
                    
                    Console.WriteLine("ID \t\t Email");
                    Console.WriteLine("--------------------------");

                    while (await reader.ReadAsync())
                    {
                        int id = reader.GetInt32(0);
                        string email = reader.GetString(2);

                        Console.WriteLine($"{id} \t {email}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        public async Task ShowUserBookingsList(int userId)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("SELECT * FROM \"bookings\" WHERE \"user\" = @UserId"))
                {
                    cmd.Parameters.AddWithValue("UserId", userId);
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine($"User with ID {userId} has no bookings.");
                            return;
                        }
                        
                        Console.WriteLine($"Bookings for user {userId}:");
                        Console.WriteLine("Booking ID \t Booking Start \t Booking End");
                        Console.WriteLine("------------------------------------------------");

                        var bookings = new System.Collections.Generic.List<(int bookingId, DateTime bookingStart, DateTime bookingEnd)>();
                        
                        while (await reader.ReadAsync())
                        {
                            int bookingId = reader.GetInt32(0);
                            DateTime bookingStart = reader.GetDateTime(2);
                            DateTime bookingEnd = reader.GetDateTime(3);

                            Console.WriteLine($"{bookingId} \t {bookingStart.ToShortDateString()} \t {bookingEnd.ToShortDateString()}");
                            
                            bookings.Add((bookingId, bookingStart, bookingEnd));
                        }
                        
                        Console.WriteLine("\nSelect a booking by entering its Booking ID:");
                        string input = Console.ReadLine();

                        if (int.TryParse(input, out int selectedBookingId))
                        {
                            var selectedBooking = bookings.Find(b => b.bookingId == selectedBookingId);

                            if (selectedBooking.bookingId != 0)
                            {
                                Console.WriteLine($"You have selected booking with ID {selectedBooking.bookingId}:");
                                Console.WriteLine($"Start: {selectedBooking.bookingStart.ToShortDateString()}");
                                Console.WriteLine($"End: {selectedBooking.bookingEnd.ToShortDateString()}");
                                
                                bool returnToBookingsMenu = await ShowBookingOptions(selectedBooking.bookingId);
                                if (returnToBookingsMenu)
                                {
                                    await ShowUserBookingsList(userId);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid booking ID, no booking found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid booking ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
        private async Task<bool> ShowBookingOptions(int bookingId)
        {
            bool exitMenu = false;
            bool returnToBookingsMenu = false;

            while (!exitMenu)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1) Delete the booking");
                Console.WriteLine("2) Add extras");
                Console.WriteLine("3) Remove extras");
                Console.WriteLine("9) Go back");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await DeleteBooking(bookingId);
                        exitMenu = true;
                        break;

                    case "2":
                        await AddExtras(bookingId);
                        break;

                    case "3":
                        await RemoveExtras(bookingId);
                        break;

                    case "9":
                        exitMenu = true;
                        returnToBookingsMenu = true; 
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

            return returnToBookingsMenu; 
        }
        
        private async Task DeleteBooking(int bookingId)
        {
            try
            {
                await using (var cmd = _database.CreateCommand("DELETE FROM \"bookings\" WHERE id = @BookingId"))
                {
                    cmd.Parameters.AddWithValue("BookingId", bookingId);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Booking with ID {bookingId} has been deleted.");
                    }
                    else
                    {
                        Console.WriteLine("The booking could not be deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the booking: {ex.Message}");
            }
        }
        
private async Task AddExtras(int bookingId)
{
    Console.WriteLine("\nAvailable Extras:");
    
    await using (var cmd = _database.CreateCommand("SELECT * FROM \"extras\""))
    {
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            
            if (!reader.HasRows)
            {
                Console.WriteLine("No extras available to add.");
                return;
            }
            
            Console.WriteLine("ID \t Extra Name");
            Console.WriteLine("----------------------------");

            var extras = new System.Collections.Generic.List<(int extrasId, string extraName)>();

            while (await reader.ReadAsync())
            {
                int extrasId = reader.GetInt32(0);
                string extraName = reader.GetString(1);
                Console.WriteLine($"{extrasId} \t {extraName}");
                
                extras.Add((extrasId, extraName));
            }
            
            Console.WriteLine("\nSelect an extra by entering its ID:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedExtrasId))
            {
                var selectedExtra = extras.Find(e => e.extrasId == selectedExtrasId);

                if (selectedExtra.extrasId != 0)
                {
                    Console.WriteLine($"You have selected extra: {selectedExtra.extraName}");

                    
                    try
                    {
                        await using (var cmdInsert = _database.CreateCommand("INSERT INTO \"bookingsxextras\" (booking_id, extras_id) VALUES (@BookingId, @ExtrasId)"))
                        {
                            cmdInsert.Parameters.AddWithValue("BookingId", bookingId);
                            cmdInsert.Parameters.AddWithValue("ExtrasId", selectedExtrasId);

                            int rowsAffected = await cmdInsert.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Extra service '{selectedExtra.extraName}' has been added to booking with ID {bookingId}.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add the extra service.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while adding the extra service: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid extra ID, no extra found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid extra ID.");
            }
        }
    }
}


        
private async Task RemoveExtras(int bookingId)
{
    Console.WriteLine("\nExtras currently added to the booking:");

    
    await using (var cmd = _database.CreateCommand(@"
        SELECT be.extras_id, e.name 
        FROM ""bookingsxextras"" AS be
        JOIN ""extras"" AS e ON be.extras_id = e.id
        WHERE be.booking_id = @BookingId"))
    {
        cmd.Parameters.AddWithValue("BookingId", bookingId);
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            
            if (!reader.HasRows)
            {
                Console.WriteLine("No extras found for this booking.");
                return;
            }
            
            Console.WriteLine("ID \t Extra Name");
            Console.WriteLine("----------------------------");

            var extras = new List<(int extrasId, string extraName)>();

            while (await reader.ReadAsync())
            {
                int extrasId = reader.GetInt32(0);
                string extraName = reader.GetString(1);
                Console.WriteLine($"{extrasId} \t {extraName}");

                
                extras.Add((extrasId, extraName));
            }
            
            Console.WriteLine("\nSelect an extra to remove by entering its ID:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedExtrasId))
            {
                var selectedExtra = extras.Find(e => e.extrasId == selectedExtrasId);

                if (selectedExtra.extrasId != 0)
                {
                    Console.WriteLine($"You have selected to remove extra: {selectedExtra.extraName}");
                    
                    try
                    {
                        await using (var cmdDelete = _database.CreateCommand(@"
                            DELETE FROM ""bookingsxextras""
                            WHERE booking_id = @BookingId AND extras_id = @ExtrasId"))
                        {
                            cmdDelete.Parameters.AddWithValue("BookingId", bookingId);
                            cmdDelete.Parameters.AddWithValue("ExtrasId", selectedExtrasId);

                            int rowsAffected = await cmdDelete.ExecuteNonQueryAsync();

                            if (rowsAffected > 0)
                            {
                                Console.WriteLine($"Extra service '{selectedExtra.extraName}' has been removed from booking with ID {bookingId}.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to remove the extra service.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while removing the extra service: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid extra ID, no extra found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid extra ID.");
            }
        }
    } 
}



    }
}
