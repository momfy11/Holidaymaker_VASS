using Npgsql;

namespace app;

public class SearchRoomByCentrum
{
    private readonly NpgsqlDataSource _database;


    public SearchRoomByCentrum(NpgsqlDataSource database)
    {
        _database = database;
    }


    public async Task SortCentrumSearch()
    {
        bool showMenu = true;

        while (showMenu)
        {
            Console.WriteLine("Sort by Options:");
            Console.WriteLine("1)Sort By Distance:");
            Console.WriteLine("2) Sort by Price");
            Console.WriteLine("3) Sort by Rating");
            Console.WriteLine("9) Return");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await SortByCentrum("a.distance_beach ASC");
                    break;
                case "2":
                    await SortByCentrum("rooms.price ASC");
                    break;
                case "3":
                    await SortByCentrum("avg_rating DESC");
                    break;
                case "9":
                    showMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select 1, 2, or 9.");
                    break;
            }
        }
    }

    public async Task SortByCentrum(string orderByOption)
    {
        Console.WriteLine("You must first enter a date to se avalible rooms by distance to centrum.\n");

        Console.WriteLine("Enter start date (YYYY-MM-DD):");
        string startDateInput = Console.ReadLine();

        Console.WriteLine("Enter end date (YYYY-MM-DD):");
        string endDateInput = Console.ReadLine();

        Console.WriteLine("Enter distance to centrum to search by:");
        string distanceInput = Console.ReadLine();


        if (!DateTime.TryParse(startDateInput, out DateTime startDate) ||
            !DateTime.TryParse(endDateInput, out DateTime endDate) ||
            !double.TryParse(distanceInput, out double distance))
        {
            Console.WriteLine("Invalid date format. Please try again.");
            return;
        }


        startDate = startDate.Date.AddHours(15);
        endDate = endDate.Date.AddHours(10);


        string query =
            "SELECT a.name AS accommodation,a.distance_centrum , rooms.size, rooms.capacity, rooms.beds, rooms.price, " +
            "COALESCE(ROUND(AVG(r.rating), 1),0) AS avg_rating " +
            "FROM public.rooms " +
            "JOIN public.accommodation a ON rooms.accommodation = a.id " +
            "LEFT JOIN public.bookings b ON rooms.id = b.room " +
            "LEFT JOIN public.ratings r ON r.accommodation = a.id " +
            "WHERE a.distance_centrum <= $1 " +
            "AND NOT ($2::TIMESTAMP < b.booking_end AND $3::TIMESTAMP > b.booking_start) " +
            "GROUP BY a.id, a.name, a.distance_centrum, a.name, rooms.size, rooms.capacity, rooms.beds, rooms.price, rooms.id, rooms.size, rooms.capacity, rooms.beds, rooms.price " +
            "ORDER BY " + orderByOption;


        await using var cmd = _database.CreateCommand(query);
        {
            cmd.Parameters.AddWithValue(distance);
            cmd.Parameters.AddWithValue(startDate);
            cmd.Parameters.AddWithValue(endDate);

            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                bool roomsFound = false;

                while (await reader.ReadAsync())
                {
                    roomsFound = true;
                    Console.WriteLine($"Accommodation: {reader["accommodation"]}");
                    Console.WriteLine($"Rating: {reader["avg_rating"]}, Distance to Centrum: {reader["distance_centrum"]} m");
                    Console.WriteLine($"Room Size: {reader["size"]}, Capacity: {reader["capacity"]}, Beds: {reader["beds"]}, Price: {reader["price"]}\n");
                }

                if (!roomsFound)
                {
                    Console.WriteLine(
                        "There are no free rooms for current period, please try again whit different date\\n");
                }
            }
        }
    }
}