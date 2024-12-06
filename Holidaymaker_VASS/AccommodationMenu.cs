using Npgsql;
namespace app;

public class AccommodationMenu
{
    private readonly Accommodation _accommodationService;

    public AccommodationMenu(Accommodation accommodationService)
    {
        _accommodationService = accommodationService;
    }

    public async Task Menu()
    {
        bool isRunning = true;
        var accommodations = await _accommodationService.SearchAllAccommodationsAsync();
        while (isRunning)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Find all Accommodations");
            Console.WriteLine("2. Find all Accommodation by Distance");
            Console.WriteLine("3. Find all Accommodation with Features");
            Console.WriteLine("4. Find Accommodation Ratings");
            Console.WriteLine("5. Search Accommodations by Booleans");
            Console.WriteLine("6. Search Accommodations by Entering Distance to Beach");
            Console.WriteLine("7. Search Accommodations by Entering Distance to Centrum");
            Console.WriteLine("9. Return to Main Menu");

            string mainOption = Console.ReadLine();
            switch (mainOption)
            {
                case "1":
                    _accommodationService.PrintAccommondationDetails(accommodations);
                    break;
                case "2":
                    _accommodationService.PrintAccommondationDetailsDistance(accommodations);
                    break;
                case "3":
                    _accommodationService.PrintAccommondationFeatures(accommodations);
                    break;
                
                case "4":
                    Console.WriteLine("Enter the Accommodation to find Ratings: ");
                    if (int.TryParse(Console.ReadLine(), out int accommodationId))
                    {
                        _accommodationService.PrintRatingsByAccommodationId(accommodationId, accommodations);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please try again with a valid Number.");
                    }
                    break;
                
                case "5":
                    Console.WriteLine("Enter a feature you want to search for (e.g., 'Pool', 'Gym', 'Resturant')");
                    var input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("No feature entered. Please try again.");
                        break;
                    }
                    
                    string[]? feature = input
                        ?.Split(',')
                        .Select(f => f.Trim().ToLower())
                        .ToArray();

                    if (feature == null || feature.Length == 0)
                    {
                        Console.WriteLine("No feature entered. Please try again.");
                    }

                    var filteredByBool = accommodations
                        .Where(a =>
                            (feature.Contains("pool") && a.HasPool) ||
                            (feature.Contains("gym") && a.HasGym) ||
                            (feature.Contains("resturant") && a.HasResturant) ||
                            (feature.Contains("kids club") && a.HasKidsClub) ||
                            (feature.Contains("evening entertainment") && a.HasEveningEntertainment))
                        .ToList();

                    if (filteredByBool.Any())
                    {
                        _accommodationService.PrintAccommondationFeatures(filteredByBool);
                    }
                    else
                    {
                        Console.WriteLine("No Accommondations found with the specified feature.");
                    }
                    break;
                case "6":
                    Console.WriteLine("Enter the maximum distance to the beach: ");
                    if (double.TryParse(Console.ReadLine(), out double maxDistanceToBeach))
                    {
                        var filteredAccommondations = accommodations.Where(a => a.DistanceToBeach <= maxDistanceToBeach).ToList();
        
                        if (filteredAccommondations.Any())
                        {
                            _accommodationService.PrintAccommondationDTB(filteredAccommondations);
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
                    break;
                case "7":
                    Console.WriteLine("Enter the maximum distance to the Centrum: ");
                    if (double.TryParse(Console.ReadLine(), out double maxDistanceToCentrum))
                    {
                        var filteredAccommondations = accommodations.Where(a => a.DistanceToCentrum <= maxDistanceToCentrum).ToList();
                    
                        if (filteredAccommondations.Any())
                        {
                            _accommodationService.PrintAccommondationDTC(filteredAccommondations);
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
                    break;
                case "9":
                    Console.WriteLine("Disable Accommodations Menu.");
                    isRunning = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid option. Please select a valid number (1-3).");
                    break;
            }
        }
    }
}