using Npgsql;
namespace app;


    public class SearchRoomByDate
    {
        private readonly NpgsqlDataSource _database;
       
    
        public SearchRoomByDate(NpgsqlDataSource database)
        {
            _database = database;
            
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
}