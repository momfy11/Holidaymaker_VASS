namespace app;

public class Program
{
    static async Task Main(string[] args)
    {
        
       
        
        Database database = new Database();
        var connection = database.Connection();
        var createUser = new CreateUser(database.Connection());
       
       
        MainMenu mainmenu = new MainMenu();
        await MainMenu.Menu(createUser, connection );
        
    }
    
}