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

    public void createReview(int reviewId, string reviewText, int rating, DateTime dateMade, int userId, int sellerId)
    {

        reviewId = ReviewId;
        reviewText = ReviewText;
        rating = Rating;
        dateMade = DateMade;
        userId = UserId;
        sellerId = SellerId;

        
        //DataBaseConnection.DataBaseConnect();
        string sqlcommnd = new string($"INSERT INTO review (UserId, seller_id, title, rating, description, DateMade, ReviewId) VALUES ({userId}, {sellerId}, {reviewText}, {rating}, {dateMade}, {reviewId});");
        DataBaseConnection.DataBaseConnect(sqlcommnd);

    }
}
