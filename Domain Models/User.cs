using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Models
{
    internal class User
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

        public List<string> permissions;

        public bool isOnline;

        public void updatePicture(string pictureLocation)
        {
            profilePicture = pictureLocation;
        }


    }
}

/*
+userId: int
+username: string
+password: string
+email: string
+phoneNumber: int
+phoneExtension: int
+profilePicture: string(?)
+city: string
+zipCode: int
+aboutMe: string
+permissions: List
+isOnline: bool

+updatePicture()
+updateProfile()
+editReview()
+createReview()
*/
