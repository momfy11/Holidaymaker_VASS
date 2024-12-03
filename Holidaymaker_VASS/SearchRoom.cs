using Npgsql;
namespace app;

public class SearchRoom
{
    private readonly NpgsqlDataSource _database;

    public SearchRoom(NpgsqlDataSource database)
    {
        _database = database;
    }
    // public static async Task Menu()
    // {
    //     bool showMenu = true;
    //
    //     while (showMenu)
    //     {
    //         
    //         /*
    //          * List 
    //             Filter Utilities
    //             
    //             
    //             Sort by
    //             Search
    //          */
    //         
    // //         Console.WriteLine("Room Menu!");
    // //         Console.WriteLine("1) Search by Date");
    // //         Console.WriteLine("2) Search by Accommodation ");
    // //         Console.WriteLine("3) Search by Distance to Centrum");
    // //         Console.WriteLine("4) Search by Distance to Beach");
    // //         Console.WriteLine("9) Return");
    // //         
    // //         string mainoption = Console.ReadLine();
    // //
    // //         switch (mainoption)
    // //         {
    // //             case "1":
    // //                 int addressId = await createUser.AddAdress();
    // //                 await createUser.AddUser(addressId);
    // //                 break;
    // //             case "2":
    // //                 //CreateBooking();
    // //                 Console.WriteLine("Creating a booking"); // ta bort när vi har en create booking method
    // //                 break;
    // //             case "3":
    // //                 //EditBooking();
    // //                 Console.WriteLine("editing a booking"); // ta bort när vi har en edit booking method
    // //                 break;
    // //             case "4":
    // //                 var viewBookings = new ViewBookings(dataSource);
    // //                 await viewBookings.ShowBookings();
    // //                 break;
    // //             case "5":
    // //                 //History();
    // //                 Console.WriteLine("Viewing history booking"); //ta bort när vi har en History method
    // //                 break;
    // //             case "9":
    // //                 showMenu = false;
    // //                 break;
    // //
    // //             default:
    // //                 Console.WriteLine("Invalid option");
    // //                 break;
    // //         }
    // //     }
    // // }

    
    
    public async Task SearchByDate()
    {
        await using (var cmd = _database.CreateCommand(
                         "SELECT a.name AS accommodation, rooms.size, rooms.capacity, rooms.beds, rooms.price " +
                         "FROM public.rooms " +
                         "JOIN public.accommodation a ON rooms.accommodation = a.id " +
                         "LEFT JOIN public.bookings b ON rooms.id = b.room " +
                         "WHERE NOT ('2024-12-20 10:47:45'::TIMESTAMP < b.booking_end AND '2024-12-31 10:47:45'::TIMESTAMP > b.booking_start) " +
                         "OR b.room IS NULL"))
        {
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Console.WriteLine($"Accommodation: {reader["accommodation"]}, Room Size: {reader["size"]}, Capacity: {reader["capacity"]}");
                    Console.WriteLine($"Beds: {reader["beds"]}, Price: {reader["price"]}\n");
                }
            }
        }
    }
    
}


