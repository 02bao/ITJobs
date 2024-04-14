using ITJobs.Models;

namespace ITJobs.Interface;

public interface IReviewRepository
{
    ICollection<Review> GetAll();
    bool CreateNewReview(long UserId, string CompanyName, Review_Create News);
    Review GetById(long Id);
    List<Review> GetByUserId(long UserId);
    bool Update(Review NewReview);
    bool Delete(long Id);
}
