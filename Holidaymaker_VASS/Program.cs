namespace app;

public class Program
{
    static async Task Main(string[] args)
    {
        Database database = new Database();
        var createUser = new CreateUser(database.Connection());
        
        Accommodation accommodation = new(database.Connection());
        var accommodationMenu = new AccommodationMenu(accommodation);
        
        //int addressId = await createUser.AddAdress();
        //await createUser.AddUser(addressId);
            
        await accommodationMenu.Menu();
    }
    
}