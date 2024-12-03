using Npgsql;

namespace Holidaymaker_VASS;
class MainMenu
{

    public static async Task Menu(CreateUser createUser, NpgsqlDataSource dataSource)
    {
        bool showMenu = true;

        while (showMenu)
        {
            Console.WriteLine("Main Menu!");
            Console.WriteLine("1) Create User");
            Console.WriteLine("2) Create Booking");
            Console.WriteLine("3) Edit Booking");
            Console.WriteLine("4) View Booking");
            Console.WriteLine("5) History");
            Console.WriteLine("9) Quit");
            
            string mainoption = Console.ReadLine();

            switch (mainoption)
            {
                case "1":
                    int addressId = await createUser.AddAdress();
                    await createUser.AddUser(addressId);
                    break;
                case "2":
                    //CreateBooking();
                    Console.WriteLine("Creating a booking"); // ta bort när vi har en create booking method
                    break;
                case "3":
                    //EditBooking();
                    await EditBookingMenu.EditMenu();
                    break;
                case "4":
                    //var viewBookings = new ViewBookings(dataSource);
                    //await viewBookings.ShowBookings();
                    break;
                case "5":
                    //History();
                    Console.WriteLine("Viewing history booking"); //ta bort när vi har en History method
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
}