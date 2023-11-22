namespace Domain_Models;

public class Review
{
    public int reviewId { get; set; }
    public string reviewText { get; set; }
    public int rating { get; set; }
    public DateTime dateMade { get; set; }

    public void createReview(int reviewId, string reviewText, int rating, DateTime dateMade, int userId, int sellerId)
    {

        reviewId = reviewId;
        reviewText = reviewText;
        rating = rating;
        dateMade = dateMade;
        userId = userId;
        sellerId = sellerId;
        

    }
}
