using Npgsql;
namespace app;

public class SearchRoom
{
    private readonly NpgsqlDataSource _database;

    public SearchRoom(NpgsqlDataSource database)
    {
        _database = database;
    }
    public async Task RoomMenu()
    {
        bool showMenu = true;
    
        while (showMenu)
        {
           
            
            Console.WriteLine("Room Menu!");
            Console.WriteLine("1) Search by Date");
            Console.WriteLine("2) Search by Accommodation ");
            Console.WriteLine("3) Search by Distance to Centrum");
            Console.WriteLine("4) Search by Distance to Beach");
            Console.WriteLine("5) Search by utilitys");
            Console.WriteLine("9) Return");
            
            string roomoption = Console.ReadLine();
    
            switch (roomoption)
            {
                case "1":
                    await SearchByDate();
                    break;
                case "2":
                    await SearchRoomByAccommodation();
                    break;
                case "3":
                    Console.WriteLine("WIP");
                    break;
                case "4":
                    Console.WriteLine("WIP");
                    break;
                case "5":
                    Console.WriteLine("WIP");
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
   
    
    public async Task SearchByDate()
    {
        
        Console.WriteLine("Enter start date (YYYY-MM-DD):");
        string startDateInput = Console.ReadLine();

        Console.WriteLine("Enter end date (YYYY-MM-DD):");
        string endDateInput = Console.ReadLine();

       
        if (!DateTime.TryParse(startDateInput, out DateTime startDate) || !DateTime.TryParse(endDateInput, out DateTime endDate))
        {
            Console.WriteLine("Invalid date format. Please try again.");
            return;
        }

       
        startDate = startDate.Date.AddHours(13); 
        endDate = endDate.Date.AddHours(10);

       
        await using (var cmd = _database.CreateCommand(
                         "SELECT a.name AS accommodation, rooms.size, rooms.capacity, rooms.beds, rooms.price " +
                         "FROM public.rooms " +
                         "JOIN public.accommodation a ON rooms.accommodation = a.id " +
                         "LEFT JOIN public.bookings b ON rooms.id = b.room " +
                         "WHERE NOT ($1::TIMESTAMP < b.booking_end AND $2::TIMESTAMP > b.booking_start) " +
                         "OR b.room IS NULL"))
        {
            
            cmd.Parameters.AddWithValue(startDate);
            cmd.Parameters.AddWithValue(endDate);

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

    
    public async Task SearchRoomByAccommodation()
{
    
    var accommodationManager = new Accommodation(_database);
    var accommodations = await accommodationManager.SearchAllAccommodationsAsync();

    Console.WriteLine("Available Accommodations:");
    foreach (var accommodation in accommodations)
    {
        Console.WriteLine($"ID: {accommodation.Id}, Name: {accommodation.Name}");
    }

   
    Console.WriteLine("Enter the ID of the accommodation you want to search:");
    if (!int.TryParse(Console.ReadLine(), out int selectedAccommodationId))
    {
        Console.WriteLine("Invalid input. Please enter a valid accommodation ID.");
        return;
    }

    
    var selectedAccommodation = accommodations.FirstOrDefault(a => a.Id == selectedAccommodationId);
    if (selectedAccommodation == null)
    {
        Console.WriteLine("No accommodation found with the specified ID.");
        return;
    }

    
    await using (var cmd = _database.CreateCommand(
                     "SELECT rooms.id, rooms.size, rooms.capacity, rooms.beds, rooms.price " +
                     "FROM public.rooms " +
                     "LEFT JOIN public.bookings b ON rooms.id = b.room " +
                     "WHERE rooms.accommodation = $1 " +
                     "AND (b.room IS NULL OR NOT (CURRENT_TIMESTAMP < b.booking_end AND CURRENT_TIMESTAMP > b.booking_start))"))
    {
        cmd.Parameters.AddWithValue(selectedAccommodation.Id);

        Console.WriteLine($"Free rooms in {selectedAccommodation.Name}:");

        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            bool roomsFound = false;

            while (await reader.ReadAsync())
            {
                Console.WriteLine($"Room ID: {reader["id"]}, Size: {reader["size"]}, Capacity: {reader["capacity"]}");
                Console.WriteLine($"Beds: {reader["beds"]}, Price: {reader["price"]}\n");
                roomsFound = true;
            }

            if (!roomsFound)
            {
                Console.WriteLine("No free rooms available for this accommodation.");
            }
        }
    }
}

}


