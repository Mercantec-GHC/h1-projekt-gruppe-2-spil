using Domain_Models.DataBase;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
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
        
        
        createGame(listing.game, ConnectionString);
        
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
                command.Parameters.AddWithValue("@createdAt", listing.dateMade);
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
                command.Parameters.AddWithValue("@genreID", genres);
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
      
        string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");

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


    public List<Seller> GetSellers(string searchTerm)
    {
        List<Seller> sellers = new List<Seller>();
        Seller previousSeller = new Seller();
        string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string getgameID = "SELECT * FROM Users INNER JOIN AsignUserToGroup on Users.id = AsignUserToGroup.userID";
            using (SqlCommand command = new SqlCommand(getgameID, connection))
            {
                command.Parameters.AddWithValue("@title", "%" + searchTerm + "%");
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bool skip = false;
                    Seller seller = new Seller();

                    seller.userId = (Int32)reader["id"];
                    seller.username = reader["username"].ToString();
                    seller.city = reader["city"].ToString();
                    
                    foreach(Seller sellerOnList in sellers)
                    {
                        if(sellerOnList.userId == seller.userId)
                        {
                            skip = true;
                            break;
                        }
                    }
                    if(skip == false)
                    {
                        sellers.Add(seller);
                    }
                    previousSeller = seller;

                }
            }
        }
        return sellers;
    }
}
