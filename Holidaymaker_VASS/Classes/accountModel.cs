namespace app.Classes;

public class accountModel
{
    public int AccountId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int AddressId { get; set; }
    
    public AddressModel Address { get; set; }
}