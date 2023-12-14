using Domain_Models.DataBase;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
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
        string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
        int userId = 1;
        
        //insert into ajsdkjas (gameName, .....)
        createGame(listing.game, ConnectionString);
        /*//SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO GameListing (seller_id, game_id, title, condition, datemade, sold) VALUES ('{userId}', '{listing.game.id}', '{listing.title}', '{listing.condition}', '{listing.dateMade}', '{listing.isSold}');");


        //SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES ('{userId}', '{listing.game.id}', '{listing.title}', '{listing.condition}', '{listing.dateMade}', '{listing.isSold}, {listing.price}');");
        string sqlcommnd = new string($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES (1, 6, '3', 'this was made with blazor', GETDATE(), 0, 100);");

        //string sqlcommnd = new string($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES ('{userId}', '{listing.game.id}', '{listing.title}', '{listing.condition}', '{listing.dateMade}', '{listing.isSold}, {listing.price}');");

        //string sqlcommnd = new string($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES ({userId}, {listing.game.id}, {listing.title}, {listing.condition}, {listing.dateMade}, {listing.isSold}, {listing.price});");

        //string sqlcommnd = new string($"INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES (1, 6, '3', 'this was made with blazor', GETDATE(), 0, 100);");f32fcd06b05ed4401db3d560e0adfa4c72b8858a

        DataBaseConnection.DataBaseConnect(sqlcommnd);


        if (listing != null)
        {
            //listings.Add(listing);
        }
        */
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string sql = "INSERT INTO GameListing (sellerID, gameID, title, condition, createdAt, sold, price) VALUES (@sellerID, @gameID, @title, @condition, @createdAt, @sold, @price);";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@sellerID", userId);
                command.Parameters.AddWithValue("@gameID", listing.game.id);
                command.Parameters.AddWithValue("@title", listing.title);
                command.Parameters.AddWithValue("@condition", listing.condition);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);
                command.Parameters.AddWithValue("@sold", listing.isSold);
                command.Parameters.AddWithValue("@price", listing.price);

                command.ExecuteNonQuery();
            }
        }

    }


    public void createGame(Game game, string connectionString)
    {
        int genres = 1;
        int publisher = 1;
        int developer = 1;

        createRequirement(game.minimumRequirements, connectionString);
        createRequirement(game.recommendedRequirements, connectionString);
        /*insert into ajsdkjas (gameName, .....)*/
        //SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO Game (gameName, genre, platform, publisher, developer, releaseDate, description) VALUES ('5', '5', '{game.developer}', '{game.releaseDate}', '{game.description}', '{game.ageRating}', '{game.numPlayers}', '{game.minimumRequirements}', '{game.recommendedRequirements}');");
        /*string sqlcommnd = new string($"INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES ({game.name}, {game.publisher}, {game.developer}, {game.releaseDate}, {game.description}, {game.ageRating}, {game.numPlayers});");
        DataBaseConnection.DataBaseConnect(sqlcommnd);
        sqlcommnd = new string($"INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES ('AAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH', 1, 1, 'a', 12, 1, GETDATE(), 1, 2, 2);");
        DataBaseConnection.DataBaseConnect(sqlcommnd);*/

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES (@name, @publisher, @developer, @description, @rating, @numPlayers, @releaseDate, @genreID, @minReqID, @recReqID);";


            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", game.name);
                command.Parameters.AddWithValue("@publisher", game.publisher);
                command.Parameters.AddWithValue("@developer", game.developer);
                command.Parameters.AddWithValue("@description", game.description);
                command.Parameters.AddWithValue("@rating", game.ageRating);
                command.Parameters.AddWithValue("@numPlayers", game.numPlayers);
                command.Parameters.AddWithValue("@releaseDate", DateTime.Now);
                command.Parameters.AddWithValue("@genreID", game.genres);
                command.Parameters.AddWithValue("@minReqID", game.minimumRequirements.id);
                command.Parameters.AddWithValue("@recReqID", game.recommendedRequirements.id);

                command.ExecuteNonQuery();
            }
            string getgameID = "SELECT MAX(id) FROM Game;";
            using (SqlCommand command = new SqlCommand(getgameID, connection))
            {
                game.id = (Int32) command.ExecuteScalar();
                Debug.WriteLine(game.id);
            }
        }
    }
    public void createRequirement(Requirements requirements, string connectionString)
    {
        /*insert into ajsdkjas (gameName, .....)*/
        //SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO Game (gameName, genre, platform, publisher, developer, releaseDate, description) VALUES ('5', '5', '{game.developer}', '{game.releaseDate}', '{game.description}', '{game.ageRating}', '{game.numPlayers}', '{game.minimumRequirements}', '{game.recommendedRequirements}');");
        /*string sqlcommnd = new string($"INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES ({game.name}, {game.publisher}, {game.developer}, {game.releaseDate}, {game.description}, {game.ageRating}, {game.numPlayers});");
        DataBaseConnection.DataBaseConnect(sqlcommnd);
        sqlcommnd = new string($"INSERT INTO Game (name, publisher, developer, description, rating, numberOfPlayers, releaseDate, genre, minRequirementsID, maxRequirementsID) VALUES ('AAAAAAAAHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH', 1, 1, 'a', 12, 1, GETDATE(), 1, 2, 2);");
        DataBaseConnection.DataBaseConnect(sqlcommnd);*/

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "INSERT INTO GameRequirements (os, cpu, ram, gpu, storage, directx) VALUES (@os, @cpu, @ram, @gpu, @storage, @directx);";


            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@os", requirements.os);
                command.Parameters.AddWithValue("@cpu", requirements.cpu);
                command.Parameters.AddWithValue("@ram", requirements.ram);
                command.Parameters.AddWithValue("@gpu", requirements.gpu);
                command.Parameters.AddWithValue("@storage", requirements.diskStorage);
                command.Parameters.AddWithValue("@directx", requirements.directX);

                command.ExecuteNonQuery();
            }
            string getRequirementsID = "SELECT MAX(id) FROM GameRequirements;";
            using (SqlCommand command = new SqlCommand(getRequirementsID, connection))
            {
                requirements.id = (Int32)command.ExecuteScalar();
                Debug.WriteLine(requirements.id);
            }
        }
    }

}
