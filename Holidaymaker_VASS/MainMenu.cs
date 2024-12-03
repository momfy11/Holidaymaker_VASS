using Npgsql;

namespace app;
class MainMenu
{

    public static async Task Menu(NpgsqlDataSource dataSource)
    {
        Database database = new Database();
        var createUser = new CreateUser(database.Connection());
        var bookingMenu = new BookingMenu(database.Connection());
        var searchBooking = new SearchBookingToEdit(database.Connection());
        Accommodation accommodation = new(database.Connection());
        SearchBookingToEdit searchBookingToEdit = new(database.Connection());
        
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
                    int addressId = await createUser.AddAdress();
                    await createUser.AddUser(addressId);
                    break;
                case "2":
                    await bookingMenu.BookingsMenu();
                    break;
                case "3":
                    await searchBookingToEdit.EditBookingsMenu();
                    break;
                case "4":
                    var viewBookings = new ViewBookings(dataSource);
                    await viewBookings.ShowBookings();
                    break;
                case "5":
                    
                    break;
                case "6":
                    var accommodationMenu = new AccommodationMenu(accommodation);
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
