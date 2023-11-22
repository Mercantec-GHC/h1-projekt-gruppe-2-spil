namespace Domain_Models;

public class Seller
{
    public List<GameListing> listings { get; set; }
    public float rating { get; set; }
    public List<string> reviews { get; set; }
    public string addressLine { get; set; }

    public void deleteListing(int listingId)
    {
        foreach(GameListing listing in listings)
        {
            if(listing.listingId == listingId)
            {
                listings.Remove(listing);
            }
        }
    }

    public void editListing(int listingId)
    {
        Console.WriteLine("Enter new price: ");
    }

    public void createLising(GameListing listing)
    {
        if(listing != null)
        {
            listings.Add(listing);
        }

    }

}
