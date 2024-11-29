namespace app.Classes;

public class ratingsModel
{
    public int AccommodationId {get; set; }
    public int AccountId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public int RatingsId { get; set; }
    
    public AccommodationModel AccommodationModel { get; set; }
    public accountModel AccountModel { get; set; }
}