﻿using Domain_Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

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
        public int numPlayers {get; set;}
        public int ageRating {get; set;}
        public DateTime releaseDate {get; set;}
        //public List<genre> genres;
        public string genres {get; set;}
        //public List<gamePlatform> gamePlatforms;
        public string gamePlatforms {get; set;}
        public Requirements minimumRequirements {get; set;}
        public Requirements recommendedRequirements {get; set;}

        // public Game(string Name,
        //             string Publisher,
        //             string Developer,
        //             string Description,
        //             int NumPlayers,
        //             int AgeRating,
        //             DateTime ReleaseDate,
        //             string Genres,
        //             string GamePlatforms)
        // {
        //     name = Name;
        //     publisher = Publisher;
        //     developer = Developer;
        //     description = Description;
        //     numPlayers = NumPlayers;
        //     ageRating = AgeRating;
        //     releaseDate = ReleaseDate;
        //     genres = Genres;
        //     gamePlatforms = GamePlatforms;
        // }

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

            /*try
            {

              
                //DataBaseConnection.DataBaseConnect();
                using (SqlConnection connection = new SqlConnection(connectionString: DataBaseConnection.ConnectionString))
                {
                    connection.Open();

                    // Check if the specified 'id' exists in the 'dbo.game' table
                    string checkQuery = $"SELECT COUNT(*) FROM dbo.game WHERE id = {id}";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        // ExecuteScalar retrieves the count of tables with the given 'id'
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        // If the table exists, update it; otherwise, insert a new table
                        if (existingCount > 0)
                        {
                            // Construct and execute the UPDATE query
                            string updateQuery = $"UPDATE dbo.game SET name = @Name, publisher = @Publisher, developer = @Developer, description = @Description, numPlayers = @NumPlayers, ageRating = @AgeRating, releaseDate = @ReleaseDate WHERE id = @ID";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                // Set parameters for the UPDATE query
                                updateCommand.Parameters.AddWithValue("@ID", id);
                                updateCommand.Parameters.AddWithValue("@Name", name);
                                updateCommand.Parameters.AddWithValue("@Publisher", publisher);
                                updateCommand.Parameters.AddWithValue("@Developer", developer);
                                updateCommand.Parameters.AddWithValue("@Description", description);
                                updateCommand.Parameters.AddWithValue("@NumPlayers", numPlayers);
                                updateCommand.Parameters.AddWithValue("@AgeRating", ageRating);
                                updateCommand.Parameters.AddWithValue("@ReleaseDate", releaseDate);

                                // Execute the UPDATE query
                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Construct and execute the INSERT query
                            string insertQuery = "INSERT INTO dbo.game (name, publisher, developer, description, numPlayers, ageRating, releaseDate) VALUES (@Name, @Publisher, @Developer, @Description, @NumPlayers, @AgeRating, @ReleaseDate)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                // Set parameters for the INSERT query
                                insertCommand.Parameters.AddWithValue("@Name", name);
                                insertCommand.Parameters.AddWithValue("@Publisher", publisher);
                                insertCommand.Parameters.AddWithValue("@Developer", developer);
                                insertCommand.Parameters.AddWithValue("@Description", description);
                                insertCommand.Parameters.AddWithValue("@NumPlayers", numPlayers);
                                insertCommand.Parameters.AddWithValue("@AgeRating", ageRating);
                                insertCommand.Parameters.AddWithValue("@ReleaseDate", releaseDate);

                                // Execute the INSERT query
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }*/
        }


        public Game getGame(int listingId){
            Game game = new Game() {};
            string ConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
//                 case
// when g.numberOfPlayers = 1 then 'Single Player'
// when g.numberOfPlayers > 1 then 'Multi Player'
// end as 

                string getgameID = @"select g.name, g.description, g.releaseDate, g.numberOfPlayers,
                g.ageRating, p.publisherName, dev.developerName, ge.genreName, mingr.os, mingr.cpu, mingr.ram, 
                mingr.gpu, mingr.storage, mingr.directX, maxgr.os, maxgr.cpu, maxgr.ram, maxgr.gpu, maxgr.storage, 
                maxgr.directX from [dbo].[GameListing] as gl 
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
                        game.releaseDate = (DateTime)reader["releaseDate"];
                        game.numPlayers = (int)reader["numberOfPlayers"];
                        game.ageRating = (int)reader["ageRating"];
                        game.publisher = (string)reader["publisherName"];
                        game.developer = (string)reader["developerName"];
                        game.genres = (string)reader["genreName"];
                        game.minimumRequirements = new Requirements((string)reader["os"], (string)reader["cpu"], (string)reader["ram"], (string)reader["gpu"], (string)reader["storage"], (string)reader["directX"]);
                        game.recommendedRequirements = new Requirements((string)reader["os1"], (string)reader["cpu1"], (string)reader["ram1"], (string)reader["gpu1"], (string)reader["storage1"], (string)reader["directX1"]);
                    }
                }
            }
            return game;
        }
    }
}
        
    

