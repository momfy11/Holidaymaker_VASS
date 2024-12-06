using Npgsql;

namespace app;

public class SearchRoomByAccommodation
{
    private readonly NpgsqlDataSource _database;

    public SearchRoomByAccommodation(NpgsqlDataSource database)
    {
        _database = database;
    }

    public async Task<(int? AccommodationId, DateTime StartDate, DateTime EndDate)> ShowAccommodationByRating()
    {
        Console.WriteLine("You must first enter a date to see available accommodations.\n");

        Console.WriteLine("Enter start date (YYYY-MM-DD):");
        string startDateInput = Console.ReadLine();

        Console.WriteLine("Enter end date (YYYY-MM-DD):");
        string endDateInput = Console.ReadLine();

        if (!DateTime.TryParse(startDateInput, out DateTime startDate) ||
            !DateTime.TryParse(endDateInput, out DateTime endDate))
        {
            Console.WriteLine("Invalid date format. Please try again.");
            return (null, DateTime.MinValue, DateTime.MinValue);
        }

        startDate = startDate.Date.AddHours(15);
        endDate = endDate.Date.AddHours(10);

        string query =
            "SELECT a.name AS accommodation, a.id AS accommodation_id, " +
            "COALESCE(ROUND(AVG(r.rating), 1), 0) AS avg_rating " +
            "FROM public.accommodation a " +
            "LEFT JOIN public.ratings r ON r.accommodation = a.id " +
            "LEFT JOIN public.rooms rooms ON rooms.accommodation = a.id " +
            "LEFT JOIN public.bookings b ON rooms.id = b.room " +
            "WHERE NOT ($1::TIMESTAMP < b.booking_end AND $2::TIMESTAMP > b.booking_start) " +
            "OR b.room IS NULL " +
            "GROUP BY a.id, a.name " +
            "ORDER BY avg_rating DESC";

        await using var cmd = _database.CreateCommand(query);
        cmd.Parameters.AddWithValue(startDate);
        cmd.Parameters.AddWithValue(endDate);

        var accommodations = new List<(int Id, string Name, decimal Rating)>();

        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                accommodations.Add((
                    Id: (int)reader["accommodation_id"],
                    Name: (string)reader["accommodation"],
                    Rating: (decimal)reader["avg_rating"]
                ));
            }
        }

        if (accommodations.Any())
        {
            Console.WriteLine("\nAccommodations (sorted by rating):");
            for (int i = 0; i < accommodations.Count; i++)
            {
                var acc = accommodations[i];
                Console.WriteLine($"{i + 1}. {acc.Name} (Rating: {acc.Rating})");
            }

            Console.WriteLine("\nEnter the number of the accommodation to view its free rooms:");
            if (int.TryParse(Console.ReadLine(), out int selectedIndex) &&
                selectedIndex > 0 && selectedIndex <= accommodations.Count)
            {
                int selectedAccommodationId = accommodations[selectedIndex - 1].Id;
                return (selectedAccommodationId, startDate, endDate);
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }
        else
        {
            Console.WriteLine("No accommodations available for this date.");
        }

        return (null, DateTime.MinValue, DateTime.MinValue);
    }


    public async Task ShowFreeRoomsByAccommodation(int accommodationId, DateTime startDate, DateTime endDate)
    {
        string query =
            "SELECT rooms.id, rooms.size, rooms.capacity, rooms.beds, rooms.price " +
            "FROM public.rooms " +
            "LEFT JOIN public.bookings b ON rooms.id = b.room " +
            "WHERE rooms.accommodation = $1 " +
            "AND (b.room IS NULL OR NOT ($2::TIMESTAMP < b.booking_end AND $3::TIMESTAMP > b.booking_start))" + 
            "ORDER BY price ";

        await using var cmd = _database.CreateCommand(query);
        cmd.Parameters.AddWithValue(accommodationId);
        cmd.Parameters.AddWithValue(startDate);
        cmd.Parameters.AddWithValue(endDate);

        Console.WriteLine("\nFree rooms:");

        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            bool roomsFound = false;

            while (await reader.ReadAsync())
            {
                roomsFound = true;
                Console.WriteLine(
                    $"Room ID: {reader["id"]}, Size: {reader["size"]}, Capacity: {reader["capacity"]}, Beds: {reader["beds"]}, Price: {reader["price"]}");
               
            }
            Console.WriteLine("\n");
            
            if (!roomsFound)
            {
                Console.WriteLine("No free rooms available for this accommodation.");
            }
        }
    }
}    