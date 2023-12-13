using Domain_Models.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class Favorites
    {
        public int customerID;
        public List<GameListing> favoritedItems;
        public void addFavorites(GameListing listing, int CustomerID )
        {
            customerID = CustomerID;
            favoritedItems.Add(listing);
            
          

             string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using(SqlConnection _connection = new SqlConnection(connectionString)){
                 _connection.Open();
                string sqlcommnd = $"INSERT INTO dbo.Favorites (customerID, gameID) VALUES (@customerID, @gameID)";
                using(SqlCommand command = new SqlCommand(sqlcommnd, _connection))
                {
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@gameID", listing.listingId);
                    command.ExecuteNonQuery();
                }
                _connection.Close();
            }

        }
        public void deleteFavorites(GameListing listing, int CustomerID )
        {
            customerID = CustomerID;
            favoritedItems.Remove(listing);
            
          

             string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using(SqlConnection _connection = new SqlConnection(connectionString)){
                 _connection.Open();
                string sqlcommnd = $"DELETE FROM dbo.Favorites WHERE customerID = @customerID AND gameID = @gameID";
                using(SqlCommand command = new SqlCommand(sqlcommnd, _connection))
                {
                    command.Parameters.AddWithValue("@customerID", customerID);
                    command.Parameters.AddWithValue("@gameID", listing.listingId);
                    command.ExecuteNonQuery();
                }
                _connection.Close();
            }

        }
    }
}


