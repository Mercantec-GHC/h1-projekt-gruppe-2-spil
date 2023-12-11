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
    enum genre
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
    enum gamePlatform
    {
        PC,
        Nintendo,
        Xbox,
        Playstaion,
    }
    internal class Game
    {

        public int id;
        public string name;
        public string publisher;
        public string developer;
        public string description;
        public int numPlayers;
        public int ageRating;
        public DateTime releaseDate;
        public List<genre> genres;
        public List<gamePlatform> gamePlatforms;

        public void UpdateGameData(string Name,
                                   string Publisher,
                                   string Developer,
                                   string Description,
                                   int NumPlayers,
                                   int AgeRating,
                                   DateTime ReleaseDate,
                                    List<genre> Genres,
                                    List<gamePlatform> GamePlatforms)
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


            try
            {

                // Open the connection
                DataBaseConnection.DataBaseConnect();
                using (SqlConnection connection = new SqlConnection(connectionString: DataBaseConnection.ConnectionString))
                {
                    connection.Open();

                    // Check if the game with the given ID already exists in the database
                    string checkQuery = $"SELECT COUNT(*) FROM dbo.game WHERE id = {id}";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        int existingCount = (int)checkCommand.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            // Update the existing record
                            string updateQuery = $"UPDATE dbo.game SET name = @Name, publisher = @Publisher, developer = @Developer, description = @Description, numPlayers = @NumPlayers, ageRating = @AgeRating, releaseDate = @ReleaseDate WHERE id = @ID";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@ID", id);
                                updateCommand.Parameters.AddWithValue("@Name", name);
                                updateCommand.Parameters.AddWithValue("@Publisher", publisher);
                                updateCommand.Parameters.AddWithValue("@Developer", developer);
                                updateCommand.Parameters.AddWithValue("@Description", description);
                                updateCommand.Parameters.AddWithValue("@NumPlayers", numPlayers);
                                updateCommand.Parameters.AddWithValue("@AgeRating", ageRating);
                                updateCommand.Parameters.AddWithValue("@ReleaseDate", releaseDate);

                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Insert a new record
                            string insertQuery = "INSERT INTO dbo.game (name, publisher, developer, description, numPlayers, ageRating, releaseDate) VALUES (@Name, @Publisher, @Developer, @Description, @NumPlayers, @AgeRating, @ReleaseDate)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@Name", name);
                                insertCommand.Parameters.AddWithValue("@Publisher", publisher);
                                insertCommand.Parameters.AddWithValue("@Developer", developer);
                                insertCommand.Parameters.AddWithValue("@Description", description);
                                insertCommand.Parameters.AddWithValue("@NumPlayers", numPlayers);
                                insertCommand.Parameters.AddWithValue("@AgeRating", ageRating);
                                insertCommand.Parameters.AddWithValue("@ReleaseDate", releaseDate);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}





