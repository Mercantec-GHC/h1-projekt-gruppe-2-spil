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

    public List<GameListing> GetGameListings(string searchTerm, int year, string genre)
    {
        List<GameListing> listings = new List<GameListing>();
        string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string getgameID = @"SELECT listingID, sellerID, price, condition, title FROM GameListing
                                INNER JOIN Users on Users.id = GameListing.sellerID 
                                INNER JOIN Game on GameListing.gameID = Game.id
                                INNER JOIN assignGenreToGame on GameListing.gameID = assignGenreToGame.gameID 
                                INNER JOIN Genre on Genre.id = assignGenreToGame.genreID 
                                WHERE GameListing.title LIKE @title AND YEAR(Game.releaseDate) >= @year AND Genre.GenreName LIKE @genre";
            using (SqlCommand command = new SqlCommand(getgameID, connection))
            {
                command.Parameters.AddWithValue("@title", "%" + searchTerm + "%");
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@genre", "%" + genre + "%");

                SqlDataReader reader = command.ExecuteReader();
                    
                while (reader.Read())
                {
                    bool skip = false;
                    GameListing listing = new GameListing();

                    listing.listingId = (int)reader["listingID"];
                    listing.sellerID = (Int32)reader["sellerID"];
                    listing.price = (decimal)reader["price"];
                    listing.condition = reader["condition"].ToString();
                    listing.title = reader["title"].ToString();

                    foreach (GameListing listingOnList in listings)
                    {
                        if (listingOnList.listingId == listing.listingId)
                        {
                            skip = true;
                            break;
                        }
                    }
                    if (skip == false)
                    {
                        listings.Add(listing);
                    }
                }
            }
        }
        return listings;
    }
}


