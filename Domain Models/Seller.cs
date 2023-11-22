﻿namespace Domain_Models;

public class Seller : User
{
    public List<GameListing> listings { get; set; }
    public float rating { get; set; }
    public List<review> reviews { get; set; }
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

    public void editListing(int listingId, string condition, float price, List<string> pictures, string title)
    {
        foreach(GameListing listing in listings)
        {
            if(listing.listingId == listingId)
            {
                listing.condition = condition;
                listing.price = price;
                listing.pictures = pictures;
                listing.title = title;
            }
            }
    }

    public void createLising(GameListing listing)
    {
        if(listing != null)
        {
            listings.Add(listing);
        }

    }

}
