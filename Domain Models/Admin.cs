using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class Admin : User
    {
        public int AdminId;
        public List<Review> reviews;
        public List<User> users;
        public List<GameListing> listings;
        

        
       

        public void editAnyListing(int listingId, string condition, decimal price, List<string> pictures, string title)
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


        public void editUser(int UserId,
                                  int number,
                                  int extension,
                                  int ZipCode,
                                  string Username,
                                  string Password,
                                  string Email,
                                  string ProfilePicture,
                                  string City,
                                  string AboutMe,
                                  List<string> Permissions,
                                  bool IsOnline)
        {
            
            users[UserId].phoneNumber = number;
            users[UserId].phoneExtension = extension;
            users[UserId].zipCode = ZipCode;
            users[UserId].username = Username;
            users[UserId].password = Password;
            users[UserId].email = Email;
            users[UserId].profilePicture = ProfilePicture;
            users[UserId].city = City;
            users[UserId].aboutMe = AboutMe;
            users[UserId].permissions = Permissions;
            users[UserId].isOnline = IsOnline;
        }

       

        public void editAnyReview(int newReviewId, string newReviewText, int newRating, string newTitle)
        {
            for (int i = 0; i < reviews.Count; i++)
            {
                if (reviews[i].ReviewId == newReviewId)
                {
                    reviews[i].ReviewText = newReviewText;
                    reviews[i].Rating = newRating;
                    reviews[i].Title = newTitle;
                }
            }

            string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                string sqlcommnd = $"UPDATE dbo.review SET ReviewText = @ReviewText, Title = @newTitle, Rating = @newRating WHERE ID = @newReviewId";
                using (SqlCommand command = new SqlCommand(sqlcommnd, _connection))
                {
                    command.Parameters.AddWithValue("@ReviewText", newReviewText);
                    command.Parameters.AddWithValue("@newTitle", newTitle);
                    command.Parameters.AddWithValue("@newRating", newRating);
                    command.Parameters.AddWithValue("@newReviewId", newReviewId);
                    command.ExecuteNonQuery();
                }
                _connection.Close();
            }
        }
    }
}
