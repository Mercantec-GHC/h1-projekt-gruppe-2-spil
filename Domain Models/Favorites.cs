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
    internal class Favorites
    {
        public int customerID;
        public List<GameListing> favoritedItems;
        public void UpdateFavorites(GameListing listing, int CustomerID, List<GameListing> GameListings)
        {
            customerID = CustomerID;
            favoritedItems = GameListings;

            //DataBaseConnection.DataBaseConnect();
            SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO gameListing (seller_id, game_id, title, condition, datemade, sold) VALUES ({listing.game.id}, {listing.title}, {listing.condition}, {listing.dateMade}, {listing.isSold})");
            //DataBaseConnection.InsertListing(sqlcommnd);

        }
    }
}


