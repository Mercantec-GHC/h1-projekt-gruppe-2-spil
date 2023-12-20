using Domain_Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Domain_Models
{
    public enum genre
    {
        Action,
        Adventure,
        Arcade,
        BeatEmAll,
        CloudGaming,
        Coaching,
        Cooperation,
        CrossPlatformMultiplayer,
        EarlyAccess,
        FPS,
        Fighting,
        FreetoPlay,
        Indies,
        LocalCoOp,
        MMO,
        Management,
        Multiplayer,
        OnlineCoOp,
        OnlinePVP,
        Platforms,
        RPG,
        Racing,
        RemotePlayTogether,
        ShootEmUp,
        Simulation,
        Singleplayer,
        Sport,
        Strategy,
        VR,
        VROnly,
        WarGame,
    }
    public enum gamePlatform
    {
        PC,
        Nintendo,
        Xbox,
        Playstaion,
    }
    public class Game
    {

        public int id {get; set;}
        public string name {get; set;}
        public string publisher {get; set;}
        public string developer {get; set;}
        public string description {get; set;}

        public string? condition { get; set;}

        public decimal? price { get; set;}
        public int numPlayers {get; set;}
        public int ageRating {get; set;}
        public DateTime releaseDate {get; set;}
        //public List<genre> genres;
        public string genres {get; set;}
        //public List<gamePlatform> gamePlatforms;
        public string gamePlatforms {get; set;}
        public Requirements minimumRequirements {get; set;}
        public Requirements recommendedRequirements {get; set;}

       

        public void UpdateGameData(string Name,
                                   string Publisher,
                                   string Developer,
                                   string Description,
                                   int NumPlayers,
                                   int AgeRating,
                                   DateTime ReleaseDate,
                                   string Genres,
                                   string GamePlatforms)
        {
            name = Name;
            publisher = Publisher;
            developer = Developer;
            description = Description;
            numPlayers = NumPlayers;
            ageRating = AgeRating;
            releaseDate = ReleaseDate;
            genres = Genres;
            gamePlatforms = GamePlatforms;

          
        }


        public Game getGame(int listingId){
            Game game = new Game() {};
            string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();


                string getgameID = @"select g.name, g.description, gl.condition, g.releaseDate, g.numberOfPlayers,
                g.ageRating, p.publisherName, dev.developerName, ge.genreName, gl.price, mingr.os as minOS, mingr.cpu as minCPU, mingr.ram as minRAM, 
                mingr.gpu as minGPU, mingr.storage as minStorage, mingr.directX as minDirectX, maxgr.os as maxOS, maxgr.cpu as maxCPU, maxgr.ram as maxRam, maxgr.gpu as maxGPU, maxgr.storage as maxStorage, 
                maxgr.directX as maxDirectX from [dbo].[GameListing] as gl 
                inner join [dbo].[Game] as g on gl.gameID = g.id 
                inner join [dbo].[Publisher] as p on g.publisher = p.id 
                inner join [dbo].[GameRequirements] as mingr on g.minRequirementsID = mingr.id 
                inner join [dbo].[GameRequirements] as maxgr on g.maxRequirementsID = maxgr.id 
                inner join [dbo].[assignGenreToGame] as ag on g.id = ag.gameID 
                inner join [dbo].[Genre] as ge on ag.genreID = ge.id 
                inner join [dbo].[assignDeveloperToGame] as asdev on g.id = asdev.gameID 
                inner join [dbo].[Developer] as dev on asdev.developerID = dev.id 
                where gl.listingID = @listingid";
                using (SqlCommand command = new SqlCommand(getgameID, connection))
                {
                    command.Parameters.AddWithValue("@listingid", listingId);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        game.name = (string)reader["name"];
                        game.description = (string)reader["description"];
                        game.condition = reader["condition"].ToString();
                        game.price = (decimal)reader["price"];
                        game.releaseDate = (DateTime)reader["releaseDate"];
                        game.numPlayers = (int)reader["numberOfPlayers"];
                        game.ageRating = (int)reader["ageRating"];
                        game.publisher = (string)reader["publisherName"];
                        game.developer = (string)reader["developerName"];
                        game.genres = (string)reader["genreName"];
                        game.minimumRequirements = new Requirements((string)reader["minOS"], (string)reader["minCPU"], (int)reader["minRAM"], (string)reader["minGPU"], (int)reader["minStorage"], (string)reader["minDirectX"]);
                        game.recommendedRequirements = new Requirements((string)reader["maxOS"], (string)reader["maxCPU"], (int)reader["maxRAM"], (string)reader["maxGPU"], (int)reader["maxStorage"], (string)reader["maxDirectX"]);
                    }
                }
            }
            return game;
        }
    }
}
        
    

