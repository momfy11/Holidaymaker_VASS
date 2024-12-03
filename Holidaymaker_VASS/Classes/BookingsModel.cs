namespace app.Classes;

public class BookingsModel
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public DateTime booking_start { get; set; }
    public DateTime booking_end { get; set; }
    public int AccountId { get; set; }
    public int total_price { get; set; }
}