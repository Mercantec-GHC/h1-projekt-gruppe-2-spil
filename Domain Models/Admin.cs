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
        

        
       

        public void editAnyListing(int listingId, string condition, float price, List<string> pictures, string title)
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

       

        public void editAnyReview(int ReviewId, string newReviewText, int newRating, string newTitle)
        {
            for (int i = 0; i < reviews.Count; i++)
            {
                if (reviews[i].reviewId == ReviewId)
                {
                    reviews[i].reviewText = newReviewText;
                    reviews[i].rating = newRating;
                    reviews[i].title = newTitle;
                }
            }
        }
    }
}
