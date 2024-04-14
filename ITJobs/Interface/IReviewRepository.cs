using ITJobs.Models;

namespace ITJobs.Interface;

public interface IReviewRepository
{
    ICollection<Review> GetAll();
    bool CreateNewReview(long UserId, string CompanyName, Review_Create News);
}
