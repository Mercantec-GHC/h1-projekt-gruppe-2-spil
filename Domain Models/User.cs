using Domain_Models.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    public class User
    {
        public int userId;
        public int phoneNumber;
        public int phoneExtension;
        public int zipCode;

        public string username;
        public string password;
        public string email;
        public string profilePicture;
        public string city;
        public string aboutMe;

        public List<string> permissions = new List<string>();
        public List<Review> reviews = new List<Review>();

        public bool isOnline;

        public void updatePicture(string pictureLocation)
        {
            profilePicture = pictureLocation;
        }

        public void updateProfile(int UserId,
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
            userId = UserId;
            phoneNumber = number;
            phoneExtension = extension;
            zipCode = ZipCode;
            username = Username;
            password = Password;
            email = Email;
            profilePicture = ProfilePicture;
            city = City;
            aboutMe = AboutMe;
            permissions = Permissions;
            isOnline = IsOnline;
           

            string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");

            using (SqlConnection _connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                
                string sqlcommnd = $"UPDATE dbo.user SET username = @username, password = @password, phoneNumber = @phoneNumber, phoneNumberExtention = @phoneExtension, zipCode = @zipCode, city = @city, aboutMe = @aboutMe, createdAt = @created WHERE ID = @userId";
                     using(SqlCommand command = new SqlCommand(sqlcommnd, _connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@zipCode", zipCode);
                        command.Parameters.AddWithValue("@city", city);
                        command.Parameters.AddWithValue("@aboutMe", aboutMe);
                        command.Parameters.AddWithValue("@created", DateTime.Now);
                        command.Parameters.AddWithValue("@userId", userId);
                        command.ExecuteNonQuery();
                    }
                _connection.Close();

            }

        }

        public void EditReview(int newReviewId, string newReviewText, int newRating, string newTitle)
        {
            string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");

            using(SqlConnection _connection = new SqlConnection(connectionString))
            {
                _connection.Open();
                string sqlcommnd = $"UPDATE dbo.review SET ReviewText = @ReviewText, Title = @newTitle, Rating = @newRating WHERE ID = @newReviewId";
                using(SqlCommand command = new SqlCommand(sqlcommnd, _connection))
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


    public User GetUser(int userId){
         User user = new User() {};
            string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();


                string getgameID = @"select username, city, zipcode, aboutMe from [dbo].[Users] where id = @userid";
                using (SqlCommand command = new SqlCommand(getgameID, connection))
                {
                    command.Parameters.AddWithValue("@userid", userId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.username = (string)reader["username"];
                        user.city = (string)reader["city"];
                        user.zipCode = (int)reader["zipcode"];
                        user.aboutMe = (string)reader["aboutMe"];
                    }
                }
            }
            return user;
    }

    }
}
