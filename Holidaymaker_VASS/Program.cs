namespace app;

public class Program
{
    static async Task Main(string[] args)
    {
        Database database = new Database();
        var createUser = new CreateUser(database.Connection());
        //var bookingMenu = new BookingMenu(database.Connection());
        
        //await bookingMenu.BookingsMenu();

        //int addressId = await createUser.AddAdress();
        //await createUser.AddUser(addressId);
        
        //MainMenu mainmenu = new MainMenu();
        //MainMenu.Menu();

        // Accommodation accommodation = new(database.Connection());
        // var accommodationMenu = new AccommodationMenu(accommodation);
        // await accommodationMenu.Menu();
        
        //int addressId = await createUser.AddAdress();
        //await createUser.AddUser(addressId);
        //await createUser.AddGuest();
    }
    
}