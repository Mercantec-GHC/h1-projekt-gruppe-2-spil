using Microsoft.Data.SqlClient;

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
    public List<string?> pictures { get; set; }
    public Game game { get; set; }

    public List<GameListing> GetGameListings(string searchTerm)
    {
        List<GameListing> listings = new List<GameListing>();
        string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string getgameID = "SELECT * FROM GameListing INNER JOIN Users on Users.id = GameListing.sellerID WHERE GameListing.title LIKE @title";
            using (SqlCommand command = new SqlCommand(getgameID, connection))
            {
                command.Parameters.AddWithValue("@title", "%" + searchTerm + "%");
                SqlDataReader reader = command.ExecuteReader();
                    
                while (reader.Read())
                {
                    GameListing listing = new GameListing();

                    listing.listingId = (int)reader["listingID"];
                    listing.sellerID = (Int32)reader["sellerID"];
                    listing.price = (decimal)reader["price"];
                    listing.condition = reader["condition"].ToString();
                    listing.title = reader["title"].ToString();

                    listings.Add(listing);
                }
            }
        }
        return listings;
    }
}


