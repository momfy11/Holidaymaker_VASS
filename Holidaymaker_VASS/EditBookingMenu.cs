using System;
using System.Threading.Tasks;
using Npgsql;

namespace Holidaymaker_VASS
{
    public class EditBookingMenu
    {
        public static async Task EditMenu()
        {
            bool showMenu = true;

            Console.WriteLine("Edit Booking Menu!");
            Console.WriteLine("1) Select User");
            Console.WriteLine("9) Quit");

            while (showMenu)
            {
                string mainoption = Console.ReadLine();

                switch (mainoption)
                {
                    case "1":
                        await SelectUser();
                        break;

                    case "9":
                        showMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
        
        public static async Task SelectUser()
        {
            var connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=holidaymaker_database";
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            var dataSource = dataSourceBuilder.Build();
            
            var showUserBookings = new ShowUserBookings(dataSource);
            
            await showUserBookings.ShowUserList();
            
            Console.WriteLine("Enter user ID to view their bookings:");
            if (int.TryParse(Console.ReadLine(), out int userId))
            {
                await showUserBookings.ShowUserBookingsList(userId);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
    }
}