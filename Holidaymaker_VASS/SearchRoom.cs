using Npgsql;
namespace app;

public class SearchRoom
{
    private readonly NpgsqlDataSource _database;
    private readonly SearchRoomByAccommodation searchRoomByAccommodation;
    private readonly SearchRoomByDate searchRoomByDate;
    private readonly SearchRoomByCentrum searchRoomByCentrum;
    private readonly SearchRoomByBeach searchRoomByBeach;
    
    public SearchRoom(NpgsqlDataSource database)
    {
        _database = database;
        searchRoomByAccommodation = new SearchRoomByAccommodation(_database);
        searchRoomByDate = new SearchRoomByDate(_database);
        searchRoomByBeach = new SearchRoomByBeach(_database);
        searchRoomByCentrum = new SearchRoomByCentrum(_database);
    }
    public async Task RoomMenu()
    {
        bool showMenu = true;
    
        while (showMenu)
        {
           
            
            Console.WriteLine("Room Menu!");
            Console.WriteLine("1) Search by Date");
            Console.WriteLine("2) Search by Accommodation Rating ");
            Console.WriteLine("3) Search by Distance to Centrum");
            Console.WriteLine("4) Search by Distance to Beach");
            Console.WriteLine("9) Return");
            
            string option = Console.ReadLine();
    
            switch (option)
            {
                case "1":
                    await searchRoomByDate.SearchByDate();
                    break;
                case "2":
                    var (accommodationId, startDate, endDate) = await searchRoomByAccommodation.ShowAccommodationByRating();
                    if (accommodationId != null)
                    {
                        await searchRoomByAccommodation.ShowFreeRoomsByAccommodation(accommodationId.Value, startDate, endDate);
                    }
                    break;
                case "3":
                    await searchRoomByCentrum.SortCentrumSearch();
                    break;
                case "4":
                    await searchRoomByBeach.SortBeachSearch();
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
   
    
    

    
   

}


