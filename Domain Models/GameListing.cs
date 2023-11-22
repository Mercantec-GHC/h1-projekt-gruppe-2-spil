namespace Domain_Models;

public class GameListing
{
    int sellerID { get; set; }
    int listingId { get; set; }
    string condition { get; set; }
    DateTime dateMade { get; set; }
    bool isSold { get; set; }
    string title { get; set; }
    float price { get; set; }
    List<string> pictures { get; set; }
}
