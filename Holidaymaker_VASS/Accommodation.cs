using System.Data;
using app.Classes;
using Npgsql;
namespace app;
using Classes;

public class Accommodation
{
    private NpgsqlDataSource _database;

    public Accommodation(NpgsqlDataSource database)
    {
        _database = database;
    }
    
    public async Task<List<AccommodationModel>> SearchAllAccommodationsAsync()
    {
        var accommodations = new List<AccommodationModel>();
        var addresses = new Dictionary<int, AddressModel>();
        var ratingsByAccomodations = new Dictionary<int, List<ratingsModel>>();
        try
        {
            await using (var addressCMD = _database.CreateCommand("SELECT * FROM adresses"))
            await using (var addressReader = await addressCMD.ExecuteReaderAsync())
            {
                while (await addressReader.ReadAsync())
                {
                    var address = new AddressModel
                    {
                        AddressId = addressReader.GetInt32(0),
                        Street = addressReader.GetString(1),
                        StreetNr = addressReader.GetInt32(2),
                        Zipcode = addressReader.GetInt32(3),
                        City = addressReader.GetString(4),
                        Country = addressReader.GetString(5)
                    };

                    addresses[address.AddressId] = address;
                }
            }

            await using (var accomodationCMD = _database.CreateCommand("SELECT * FROM accommodation"))
            await using (var accomodationReader = await accomodationCMD.ExecuteReaderAsync())
            {
                while (await accomodationReader.ReadAsync())
                {
                    var accommodation = new AccommodationModel
                    {
                        Id = accomodationReader.GetInt32(0),
                        Name = accomodationReader.GetString(1),
                        DistanceToBeach = accomodationReader.GetDouble(2),
                        DistanceToCentrum = accomodationReader.GetDouble(3),
                        HasPool = accomodationReader.GetBoolean(4),
                        HasEveningEntertainment = accomodationReader.GetBoolean(5),
                        HasKidsClub = accomodationReader.GetBoolean(6),
                        HasResturant = accomodationReader.GetBoolean(7),
                        HasGym = accomodationReader.GetBoolean(9),
                        AddressId = accomodationReader.GetInt32(8)
                    };

                    if (addresses.TryGetValue(accommodation.AddressId, out var address))
                    {
                        accommodation.Address = address;
                    }

                    accommodations.Add(accommodation);
                }
            }
            
            await using (var ratingsCMD = _database.CreateCommand("SELECT * FROM ratings"))
            await using (var ratingsReader = await ratingsCMD.ExecuteReaderAsync())
            {
                while (await ratingsReader.ReadAsync())
                {
                    var rating = new ratingsModel
                    {
                        AccommodationId = ratingsReader.GetInt32(0),
                        AccountId = ratingsReader.GetInt32(1),
                        Rating = ratingsReader.GetInt32(2),
                        Comment = ratingsReader.GetString(3),
                        RatingsId = ratingsReader.GetInt32(4)
                    };

                    if (!ratingsByAccomodations.ContainsKey(rating.AccommodationId))
                    {
                        ratingsByAccomodations[rating.AccommodationId] = new List<ratingsModel>();
                    }
                    
                    ratingsByAccomodations[rating.AccommodationId].Add(rating);
                }
            }
            
        }
        catch (NpgsqlException npgException)
        {
            Console.WriteLine($"Error: {npgException}");
        }

        foreach (var accommodation in accommodations)
        {
            if (ratingsByAccomodations.TryGetValue(accommodation.Id, out var ratings))
            {
                accommodation.Ratings = ratings;
            }
        }

        return accommodations;
    }

    public void PrintAccommondationDetails(List<AccommodationModel> accommodationModels)
    {
        foreach (var accommodationModel in accommodationModels)
        {
            Console.WriteLine($"ID: {accommodationModel.Id}, Name: {accommodationModel.Name}");
            Console.WriteLine($" - Distance To Beach: {accommodationModel.DistanceToBeach} m");
            Console.WriteLine($" - Distance To Centrum: {accommodationModel.DistanceToCentrum} m");
            Console.WriteLine($" - Has Pool: {(accommodationModel.HasPool ? "Yes" : "No")}");
            Console.WriteLine($" - Has Gym: {(accommodationModel.HasGym ? "Yes" : "No")}");
            Console.WriteLine($" - Has a Resturant: {(accommodationModel.HasResturant ? "Yes" : "No")}");
            Console.WriteLine($" - Has a Kids Club: {(accommodationModel.HasKidsClub ? "Yes" : "No")}");
            Console.WriteLine($" - Has Evening Entertainment: {(accommodationModel.HasEveningEntertainment ? "Yes" : "No")}");

            if (accommodationModel.Address != null)
            {
                Console.WriteLine(" - Adress:");
                Console.WriteLine($"    Street: {accommodationModel.Address.Street} {accommodationModel.Address.StreetNr}");
                Console.WriteLine($"    City: {accommodationModel.Address.City}");
                Console.WriteLine($"    Zipcode: {accommodationModel.Address.Zipcode.ToString()}");
                Console.WriteLine($"    Country: {accommodationModel.Address.Country}");
            }
            else
            {
                Console.WriteLine(" - Adress: Not Available");
            }

            if (accommodationModel.Ratings.Any())
            {
                Console.WriteLine(" - Ratings:");
                foreach (var rating in accommodationModel.Ratings)
                {
                    Console.WriteLine($" - Rating ID: {rating.RatingsId}");
                    Console.WriteLine($" - User Account ID: {rating.AccountId}");
                    Console.WriteLine($" - Score: {rating.Rating}");
                    Console.WriteLine($" - Comment: {rating.Comment}");
                }
            }
            else
            {
                Console.WriteLine(" - Ratings: No Ratings for this accommodation exists.");
            }
        }
    }

    public void PrintRatingsByAccommodationId(int accommodationId, List<AccommodationModel> accommodationModels)
    {
        var accommodation = accommodationModels.FirstOrDefault(a => a.Id == accommodationId);

        if (accommodation == null)
        {
            Console.WriteLine($"No Accommodation found with ID: {accommodationId}");
            return;
        }
        
        Console.WriteLine($"\nRatings for Accommodation: {accommodation.Name} (ID: {accommodation.Id})");

        if (accommodation.Ratings.Any())
        {
            foreach (var rating in accommodation.Ratings)
            {
                Console.WriteLine($" - User Account ID: {rating.AccountId}");
                Console.WriteLine($" - Score: {rating.Rating}");
                Console.WriteLine($" - Comment: {rating.Comment}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No ratings available for this Accommodation.");
        }
    }
    
    public void PrintAccommondationDetailsDistance(List<AccommodationModel> accommodationModels)
    {
        foreach (var accommodationModel in accommodationModels)
        {
            Console.WriteLine($"ID: {accommodationModel.Id}, Name: {accommodationModel.Name}, Distance To Beach: {accommodationModel.DistanceToBeach}, Distance To Centrum: {accommodationModel.DistanceToCentrum}");
        }
    }

    public void PrintAccommondationFeatures(List<AccommodationModel> accommodationModels)
    {
        foreach (var accommodationModel in accommodationModels)
        {
            Console.WriteLine($"ID: {accommodationModel.Id}, Name: {accommodationModel.Name}");
            
            if(accommodationModel.HasPool)
                Console.WriteLine(" - Pool: Yes");
            if(accommodationModel.HasGym)
                Console.WriteLine(" - Gym: Yes");
            if(accommodationModel.HasResturant)
                Console.WriteLine(" - Resturant: Yes");
            if(accommodationModel.HasKidsClub)
                Console.WriteLine(" - Kids Club: Yes");
            if(accommodationModel.HasEveningEntertainment)
                Console.WriteLine(" - Evening Entertainment: Yes");

            if (!accommodationModel.HasPool
                && !accommodationModel.HasGym
                && !accommodationModel.HasResturant
                && !accommodationModel.HasKidsClub
                && !accommodationModel.HasEveningEntertainment)
            {
                Console.WriteLine(" - Has special feature available.");
            }
        }
    }
    
    public void PrintAccommondationDTB(List<AccommodationModel> accommodationModels)
    {
        foreach (var accommodationModel in accommodationModels)
        {
            Console.WriteLine($"ID: {accommodationModel.Id}, Name: {accommodationModel.Name}, Distance To Beach: {accommodationModel.DistanceToBeach}");
        }
    }
    
    public void PrintAccommondationDTC(List<AccommodationModel> accommodationModels)
    {
        foreach (var accommodationModel in accommodationModels)
        {
            Console.WriteLine($"ID: {accommodationModel.Id}, Name: {accommodationModel.Name}, Distance To Centrum: {accommodationModel.DistanceToCentrum}");
        }
    }
    
    public async Task SearchByBool()
    {
        var accommodations = await SearchAllAccommodationsAsync();
        
        #region Search By Boolean
        Console.WriteLine("Enter a feature you want to search for (e.g., 'Pool', 'Gym', 'Resturant')");
        string feature = Console.ReadLine()?.Trim().ToLower();

        List<AccommodationModel>? filteredAccommodations = feature switch
        {
            "pool" => accommodations.Where(a => a.HasPool).ToList(),
            "gym" => accommodations.Where(a => a.HasGym).ToList(),
            "resturant" => accommodations.Where(a => a.HasResturant).ToList(),
            "kids club" => accommodations.Where(a => a.HasKidsClub).ToList(),
            "evening entertainment" => accommodations.Where(a => a.HasEveningEntertainment).ToList(),
            _ => null
        };

        if (filteredAccommodations == null)
        {
            Console.WriteLine("Invalid feature entered. Please try again with a valid Option. ( pool, gym, resturant, kids club, evening entertainment )");
        }
        else if (filteredAccommodations.Any())
        {
            PrintAccommondationDetails(filteredAccommodations);
        }
        else
        {
            Console.WriteLine("No Accommondations found with the specified feature.");
        }
         

        #endregion
    }

    public async Task SearchByDistanceToBeach()
    {
        var accommodations = await SearchAllAccommodationsAsync();

        #region Distance to Beach Search

        Console.WriteLine("Enter the maximum distance to the beach: ");
        if (double.TryParse(Console.ReadLine(), out double maxDistanceToBeach))
        {
            var filteredAccommondations = accommodations.Where(a => a.DistanceToBeach <= maxDistanceToBeach).ToList();
        
            if (filteredAccommondations.Any())
            {
                PrintAccommondationDTB(filteredAccommondations);
            }
            else
            {
                Console.WriteLine("No accommondations found within the specified distance");
        
            }
        }
        else
        {
            Console.WriteLine("Invalid Input. Please enter a valid Number.");
        }

        #endregion
    }

    public async Task SearchByDistanceToCentrum()
    {
        var accommodations = await SearchAllAccommodationsAsync();

        #region Distance to Centrum Search
        Console.WriteLine("Enter the maximum distance to the Centrum: ");
        if (double.TryParse(Console.ReadLine(), out double maxDistanceToCentrum))
        {
            var filteredAccommondations = accommodations.Where(a => a.DistanceToCentrum <= maxDistanceToCentrum).ToList();
        
            if (filteredAccommondations.Any())
            {
                PrintAccommondationDTC(filteredAccommondations);
            }
            else
            {
                Console.WriteLine("No accommondations found within the specified distance");
        
            }
        }
        else
        {
            Console.WriteLine("Invalid Input. Please enter a valid Number.");
        }

        #endregion
    }
}

