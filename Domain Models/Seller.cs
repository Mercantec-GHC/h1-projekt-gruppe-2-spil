using System.Data.Common;
using Microsoft.Data.SqlClient;
using Domain_Models.DataBase;
namespace Domain_Models;
public class Seller : User
{
    public List<GameListing> listings { get; set; }
    public float rating { get; set; }
    public List<Review> reviews { get; set; }
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


    public void createListing(GameListing listing)
    { 
        DataBaseConnection.DataBaseConnect();
        
        
        /*insert into ajsdkjas (gameName, .....)*/
        
        SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO gameListing (seller_id, game_id, title, condition, datemade, sold) VALUES ({userId}, {listing.game.id}, {listing.title}, {listing.condition}, {listing.dateMade}, {listing.isSold})");
        DataBaseConnection.InsertListing(sqlcommnd);
        if(listing != null)
        {
            listings.Add(listing);
        }


    }

}
