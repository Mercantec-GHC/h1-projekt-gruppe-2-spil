﻿using Domain_Models.DataBase;
using Microsoft.Data.SqlClient;

namespace Domain_Models;

public class Review
{
    public int ReviewId { get; set; }
    public string ReviewText { get; set; }
    public int Rating { get; set; }
    public DateTime DateMade { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
    public int SellerId { get; set; }

    public void createReview(int reviewId, string reviewText, int rating, DateTime dateMade, string title, int userId, int sellerId)
    {

        reviewId = ReviewId;
        reviewText = ReviewText;
        rating = Rating;
        dateMade = DateMade;
        title = Title;
        userId = UserId;
        sellerId = SellerId;

        string connectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string sql = "INSERT INTO review (UserId, seller_id, title, rating, description, DateMade, ReviewId) values @UserId, @seller_id, @title, @rating, @description, @DateMade, @ReviewId";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("UserId", userId);
                command.Parameters.AddWithValue("seller_id", sellerId);
                command.Parameters.AddWithValue("title", title);
                command.Parameters.AddWithValue("rating", rating);
                command.Parameters.AddWithValue("description", reviewText);
                command.Parameters.AddWithValue("DateMde", dateMade);
                command.Parameters.AddWithValue("ReviewId", reviewId);

                command.ExecuteNonQuery();
            }
        }
       
        {

        }
        //DataBaseConnection.DataBaseConnect();

        SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO review (UserId, seller_id, title, rating, description, DateMade, ReviewId) VALUES ({userId}, {sellerId}, {reviewText}, {rating}, {dateMade}, {reviewId});");

        //SqlCommand sqlcommnd = new SqlCommand($"INSERT INTO review (ID, seller_id, title, rating, description) VALUES ();");
        

       // DataBaseConnection.DataBaseConnect(sqlcommnd);

    }
}
