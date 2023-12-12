using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        }

        public void EditReview(int newReviewId, string newReviewText, int newRating, string newTitle)
        {
            for(int i = 0; i < reviews.Count; i++)
            {
                if (reviews[i].ReviewId == newReviewId)
                {
                    reviews[i].ReviewText = newReviewText;
                    reviews[i].Rating = newRating;
                    reviews[i].Title = newTitle;
                }
            }
        }
    }
}
