using Npgsql;
namespace app;

public class SearchRoomByAccommodation
{
  
    
    private readonly NpgsqlDataSource _database;

    public SearchRoomByAccommodation(NpgsqlDataSource database)
    {
        _database = database;
    }
    
     public async Task SearchByAccommodation()
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
                roomsFound = true;
                Console.WriteLine($"Room ID: {reader["id"]}, Size: {reader["size"]}, Capacity: {reader["capacity"]}");
                Console.WriteLine($"Beds: {reader["beds"]}, Price: {reader["price"]}\n");
                
            }

            if (!roomsFound)
            {
                Console.WriteLine("No free rooms available for this accommodation.");
            }
        }
    }
}
}