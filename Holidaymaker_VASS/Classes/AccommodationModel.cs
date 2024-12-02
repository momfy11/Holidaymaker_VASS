namespace app.Classes;

public class AccommodationModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double DistanceToBeach { get; set; }
    public double DistanceToCentrum { get; set; }
    public bool HasPool { get; set; }
    public bool HasEveningEntertainment { get; set; }
    public bool HasKidsClub { get; set; }
    public bool HasResturant { get; set; }
    public bool HasGym { get; set; }
    public int AddressId { get; set; }
    
    public AddressModel Address { get; set; }
    public List<RatingsModel> Ratings { get; set; } = new List<RatingsModel>();
}