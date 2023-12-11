namespace Domain_Models;

public class GameListing
{
    public int sellerID { get; set; }
    public int listingId { get; set; }
    public string condition { get; set; }
    public DateTime dateMade { get; set; }
    public bool isSold { get; set; }
    public string title { get; set; }
    public decimal price { get; set; }
    public List<string> pictures { get; set; }
    internal Game game { get; set; }
}
