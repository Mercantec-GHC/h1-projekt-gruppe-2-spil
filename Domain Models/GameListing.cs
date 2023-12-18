﻿using Microsoft.Data.SqlClient;

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

    public List<GameListing> GetGameListings()
    {
        List<GameListing> listings = new List<GameListing>();
        string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            string getgameID = "SELECT * FROM GameListing";
            using (SqlCommand command = new SqlCommand(getgameID, connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GameListing listing = new GameListing();

                    listing.price = (decimal)reader["price"];

                    listings.Add(listing);
                }
            }
        }
        return listings;
    }
}
