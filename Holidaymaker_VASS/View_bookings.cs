using Npgsql;

namespace app;

    public class ViewBookings
    {
        private readonly NpgsqlDataSource _database;

        public ViewBookings(NpgsqlDataSource database)
        {
            _database = database;
        }

        public async Task ShowBookings()
        {
            bool bookingMenu = true;

            while (bookingMenu)
            {
                Console.WriteLine("View Bookings!");
                Console.WriteLine("1) View Active Bookings");
                Console.WriteLine("2) View Archived Bookings");
                Console.WriteLine("9) Return");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        await ActiveBooking();
                        break;
                    case "2":
                        await ArchivedBooking();
                        break;
                    case "9":
                        bookingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private async Task ActiveBooking()
        {
            Console.WriteLine("Fetching active bookings...");

            
            await using var cmd = _database.CreateCommand("SELECT * FROM active_bookings");

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                
                Console.WriteLine($"Booking ID: {reader["booking_id"]}, Room ID: {reader["room"]}, Email: {reader["user_email"]}");
                Console.WriteLine(
                    $"Start: {reader["booking_start"]}, End: {reader["booking_end"]}, Total Price: {reader["total_price"]}\n");
            }

        }

        private async Task ArchivedBooking()
        {
            Console.WriteLine("Fetching archived bookings...");

           
            await using var cmd = _database.CreateCommand("SELECT * FROM archived_bookings");

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                
                Console.WriteLine($"Booking ID: {reader["booking_id"]}, Room ID: {reader["room"]}, Email: {reader["user_email"]}");
                Console.WriteLine(
                    $"Start: {reader["booking_start"]}, End: {reader["booking_end"]}, Total Price: {reader["total_price"]}\n");
            }
        }
    }
   