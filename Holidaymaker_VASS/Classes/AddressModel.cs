namespace app.Classes;

public class AddressModel
{
    public int AddressId { get; set; }
    public string Street { get; set; }
    public int StreetNr { get; set; }
    public int Zipcode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}