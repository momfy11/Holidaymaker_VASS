namespace app;

public class Program
{
    static async Task Main(string[] args)
    {
        Database database = new Database();
        var createUser = new CreateUser(database.Connection());
        var bookingMenu = new BookingMenu(database.Connection());
        var searchBooking = new SearchBookingToEdit(database.Connection());
        
        // MainMenu mainmenu = new MainMenu();
        // mainmenu.Menu();

    }
    
}