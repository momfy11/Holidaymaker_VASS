using Npgsql;

namespace app;

   public class Program
   {
       static async Task Main(string[] args)
       {
          
           Database database = new Database();
           var dataSource = database.Connection();
   
          
           await MainMenu.Menu(dataSource);
   
           Console.WriteLine("Program ended.");
       }
   } 

