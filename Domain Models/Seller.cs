namespace Domain_Models;

public class Seller
{
    List<GameListing> listings { get; set; }
    float rating { get; set; }
    List<string> reviews { get; set; }
    string addressLine { get; set; }

    public void deleteListing(int listingId)
    {

    }

    public void editListing(int listingId)
    {

    }

    public void createLising(GameListing listing)
    {

    }

}
