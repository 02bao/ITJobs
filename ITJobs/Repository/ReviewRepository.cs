using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository;

public class ReviewRepository(DataContext _context) : IReviewRepository
{
    public bool CreateNewReview(long UserId, string CompanyName, Review_Create News)
    {
        User user = _context.Users.SingleOrDefault( s => s.Id == UserId );
        if (user == null) { return false; }
        Company companies = _context.Companies.SingleOrDefault(s => s.Name == CompanyName);
        if (companies == null) { return false; }
        Review NewReview = new Review()
        { 
           Title = News.Title,
           Comment = News.Comment,
           Like = 0,
           Rating = News.Rating,
           Dislike = 0,
           Timestamp = DateTime.UtcNow,
           Users = user,
           Companies = companies
        };
        _context.Reviews.Add(NewReview);
        _context.SaveChanges();
        return true;
    }

    public bool Delete(long Id)
    {
        throw new NotImplementedException();
    }

    public ICollection<Review> GetAll()
    {
        return _context.Reviews.ToList();
    }

    public Review GetById(long Id)
    {
        return _context.Reviews.SingleOrDefault(s => s.Id == Id);
    }

    public List<Review> GetByUserId(long UserId)
    {
        List<Review> respone = new List<Review>();
        var user = _context.Reviews.Where(s => s.Users.Id == UserId).ToList();
        if(user == null) { return respone; }
        foreach(var item in user)
        {
            respone.Add(new Review() 
            { 
                Title = item.Title,
                Comment = item.Comment,
                Like = item.Like,
                Dislike = item.Dislike,
                Rating = item.Rating,
                Timestamp = item.Timestamp,
            });
        }
        return respone;
    }

    public bool Update(Review NewReview)
    {
        throw new NotImplementedException();
    }
}
