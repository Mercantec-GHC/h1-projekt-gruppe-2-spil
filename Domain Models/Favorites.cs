using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    internal class Favorites
    {
        public int customerID;
        public List<GameListing> favoritedItems;
        public void UpdateFavorites(int CustomerID, List<GameListing> GameListings)
        {
            customerID = CustomerID;
            favoritedItems = GameListings;
            SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO gameListing (customerID, FacoritedITems) VALUES ( {customerID}, {favoritedItems})");
        }
    }
}
   
