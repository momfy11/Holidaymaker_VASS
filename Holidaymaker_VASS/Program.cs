using Npgsql;

namespace app;

   public class Program
   {
       static async Task Main(string[] args)
       {
           // Initialize the database connection
           Database database = new Database();
           var dataSource = database.Connection(); // Get the NpgsqlDataSource object
   
          
           await MainMenu.Menu(dataSource);
   
           Console.WriteLine("Program ended.");
       }
   } 

