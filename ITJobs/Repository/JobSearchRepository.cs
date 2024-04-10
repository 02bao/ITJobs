using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class JobSearchRepository : IJobSearchRepository
    {
        private readonly DataContext _context;

        public JobSearchRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<JobSearch> GetAll()
        {
            return _context.JobSearches.ToList();
        }

        public JobSearch GetById(long id)
        {
            return _context.JobSearches.SingleOrDefault(s => s.Id == id);
        }

        public List<JobSearch> GetJobDesired(long userid, JobDesired job)
        {
            List<JobSearch> response = new List<JobSearch>();
            var NewDate = DateTime.Parse(job.Timestamp.ToString()).ToUniversalTime();
            var user = _context.Users.SingleOrDefault(s => s.Id == userid);
            if (user == null)
            {
                return response;
            }

            var NewJobs = new JobSearch()
            {
                Position = job.Position,
                Location = job.Location,
                Filed = job.Filed,
                Salary_Range = job.Salary_Range,
                Experience_Level = job.Experience_Level,
                Timestamp = NewDate,
                Users = user,
                Companies = null,
            };
            response.Add(NewJobs);
            return response;
        }

        public List<CompanyPost> SearchForUser(long userid, JobDesired job)
        {
            List<JobSearch> Desiredes = GetJobDesired(userid, job);
            List<CompanyPost> posts = new List<CompanyPost>();
            List<JobSearch> MatchingDesired = new List<JobSearch>();
            foreach (var desired in Desiredes)
            {
                string position = desired.Position;
                string location = desired.Location;
                string Filed = desired.Filed;
                string Salary = desired.Salary_Range;
                string Experiences = desired.Experience_Level;

                foreach (var post in _context.CompanyPosts)
                {
                    int matching = 0;
                    if (!string.IsNullOrEmpty(position) && post.Position.ToLower().Contains(position.ToLower()))
                    {
                        matching++;
                    }
                    if (!string.IsNullOrEmpty(location) && post.Location.ToLower().Contains(location.ToLower()))
                    {
                        matching++;

                    }
                    if (!string.IsNullOrEmpty(Filed) && post.Field.ToLower().Contains(Filed.ToLower()))
                    {
                        matching++;
                    }
                    if (!string.IsNullOrEmpty(Salary) && post.Salary.ToLower().Contains(Salary.ToLower()))
                    {
                        matching++;
                    }
                    if (!string.IsNullOrEmpty(Experiences) && post.Experience.ToLower().Contains(Experiences.ToLower()))
                    {
                        matching++;
                    }

                    if (matching >= 2)
                    {
                        posts.Add(post);

                        var Desired = new JobSearch
                        {
                            Location = post.Location,
                            Position = post.Position,
                            Filed = post.Field,
                            Salary_Range = post.Salary,
                            Experience_Level = post.Experience,
                        };
                        MatchingDesired.Add(Desired);
                    }
                }
            }
            _context.JobSearches.AddRange(MatchingDesired);
            _context.SaveChanges();
            return posts;
        }
    }
}
