namespace app;

public class Program
{
    static async Task Main(string[] args)
    {
        Database database = new Database();
        var createUser = new CreateUser(database.Connection());
<<<<<<< HEAD
        var bookingMenu = new BookingMenu(database.Connection());
        var searchBooking = new SearchBookingToEdit(database.Connection());

        await searchBooking.EditBookingsMenu();

=======
        //var bookingMenu = new BookingMenu(database.Connection());
        
>>>>>>> main
        //await bookingMenu.BookingsMenu();

        //int addressId = await createUser.AddAdress();
        //await createUser.AddUser(addressId);
<<<<<<< HEAD

        //MainMenu mainmenu = new MainMenu();
        //MainMenu.Menu();

        // Accommodation accommodation = new(database.Connection());
        // var accommodationMenu = new AccommodationMenu(accommodation);
        // await accommodationMenu.Menu();

=======
        
        //MainMenu mainmenu = new MainMenu();
        //MainMenu.Menu();

        // Accommodation accommodation = new(database.Connection());
        // var accommodationMenu = new AccommodationMenu(accommodation);
        // await accommodationMenu.Menu();
        
>>>>>>> main
        //int addressId = await createUser.AddAdress();
        //await createUser.AddUser(addressId);
        //await createUser.AddGuest();
    }
    
}