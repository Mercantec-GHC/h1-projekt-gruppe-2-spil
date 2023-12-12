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
        foreach (GameListing listing in listings)
        {
            if (listing.listingId == listingId)
            {
                listings.Remove(listing);
            }
        }
    }

    public void editListing(int listingId, string condition, decimal price, List<string> pictures, string title)
    {
        foreach (GameListing listing in listings)
        {
            if (listing.listingId == listingId)
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


        /*insert into ajsdkjas (gameName, .....)*/
        createGame(listing.game);
        listing.game.id = 6;
        int userId = 1;
        int isSold = 0;
        //SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO GameListing (seller_id, game_id, title, condition, datemade, sold) VALUES ('{userId}', '{listing.game.id}', '{listing.title}', '{listing.condition}', '{listing.dateMade}', '{listing.isSold}');");
        string sqlcommnd = new string($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES ({userId}, {listing.game.id}, {listing.title}, {listing.condition}, {listing.dateMade}, {listing.isSold}, {listing.price});");
        //string sqlcommnd = new string($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES (1, 6, '3', 'this was made with blazor', GETDATE(), 0, 100);");

        DataBaseConnection.DataBaseConnect(sqlcommnd);


        if (listing != null)
        {
            //listings.Add(listing);
        }


    }


    public void createGame(Game game)
    {
        /*insert into ajsdkjas (gameName, .....)*/
        //SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO Game (gameName, genre, platform, publisher, developer, releaseDate, description) VALUES ('5', '5', '{game.developer}', '{game.releaseDate}', '{game.description}', '{game.ageRating}', '{game.numPlayers}', '{game.minimumRequirements}', '{game.recommendedRequirements}');");
        string sqlcommnd = new string($"INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES ({game.name}, {game.publisher}, {game.developer}, {game.releaseDate}, {game.description}, {game.ageRating}, {game.numPlayers});");
        DataBaseConnection.DataBaseConnect(sqlcommnd);
        sqlcommnd = new string($"INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES ('AAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH', 1, 1, 'a', 12, 1, GETDATE(), 1, 2, 2);");
        DataBaseConnection.DataBaseConnect(sqlcommnd);
    }

}
