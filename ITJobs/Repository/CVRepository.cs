﻿using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class CVRepository : ICVRepository
    {
        private readonly DataContext _context;

        public CVRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewCV(long userid, CV cv)
        {
            User user = _context.Users.SingleOrDefault( s=> s.Id == userid );
            if(user == null)
            {
                return false;
            }
            UserProfiles userprofiles = _context.UserProfiles.SingleOrDefault( s=> s.User.Id ==  userid );
            CV NewCV = new CV()
            {
                Title = cv.Title,
                Educartion = cv.Educartion,
                Certifications = cv.Certifications,
                Experience = cv.Experience,
                Skill = cv.Skill,
                GitHubRepository = null,
                User = user,
                UserProfiles = userprofiles,
            };
            _context.Cv.Add( NewCV );
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long CvId)
        {
            throw new NotImplementedException();
        }

        public ICollection<CV> GetAll()
        {
            return _context.Cv.ToList();
        }

        public CV GetById(long CvId)
        {
            return _context.Cv.SingleOrDefault(s => s.Id == CvId);
        }

        public List<CV> GetByUserId(long UserId)
        {
            List<CV> response = new List<CV>();
            var users = _context.Cv.Where(s => s.User.Id ==  UserId).ToList();
            if(users == null)
            {
                return response;
            }
            foreach( var user in users )
            {
                response.Add(new CV()
                {
                    Title=user.Title,
                    Experience=user.Experience,
                    Skill=user.Skill,
                    GitHubRepository=user.GitHubRepository,
                    Certifications=user.Certifications,
                    Educartion=user.Educartion,
                });
            }
            return response;
        }

        public bool Update(CV cv)
        {
            var cvs = _context.Cv.SingleOrDefault(s => s.Id == cv.Id);
            if(cvs == null)
            {
                return false;
            }
            cvs.Title = cv.Title;
            cvs.Educartion = cv.Educartion;
            cvs.Certifications = cv.Certifications;
            cvs.Experience = cv.Experience;
            cvs.Skill = cv.Skill;
            cvs.GitHubRepository = cv.GitHubRepository;
            _context.SaveChanges();
            return true;
        }
    }
}
