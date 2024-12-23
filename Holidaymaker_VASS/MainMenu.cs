using Npgsql;

namespace app;
class MainMenu
{

    public static async Task Menu(NpgsqlDataSource dataSource)
    {
       
        var createUser = new CreateUser(dataSource);
        var bookingMenu = new BookingMenu(dataSource);
        var viewBookings = new ViewBookings(dataSource);
        var accommodation = new Accommodation(dataSource);
        var searchBookingToEdit = new SearchBookingToEdit(dataSource);
        var searchRoom = new SearchRoom(dataSource);
        var accommodationMenu = new AccommodationMenu(accommodation);
        
        
        bool showMenu = true;

        while (showMenu)
        {
            Console.WriteLine("Main Menu!");
            Console.WriteLine("1) Create User");
            Console.WriteLine("2) Create Booking");
            Console.WriteLine("3) Edit Booking");
            Console.WriteLine("4) View Booking");
            Console.WriteLine("5) Search By Room");
            Console.WriteLine("6) Accommodations Menu");
            Console.WriteLine("9) Quit");
            
            string mainoption = Console.ReadLine();

            switch (mainoption)
            {
                case "1":
                    await createUser.CreateUserMenu();
                    break;
                
                case "2":
                    await bookingMenu.BookingsMenu();
                    break;
                
                case "3":
                    await searchBookingToEdit.EditBookingsMenu();
                    break;
                
                case "4":
                    await viewBookings.ShowBookings();
                    break;
                
                case "5":
                    await searchRoom.RoomMenu();
                    break;
                
                case "6":
                    await accommodationMenu.Menu();
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
