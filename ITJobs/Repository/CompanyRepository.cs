﻿using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateNewCompany(Company company, long userid)
        {
            User user = _context.Users.SingleOrDefault( s => s.Id == userid);
            if(user == null)
            {
                return false;
            }
            var EmailCompany = _context.Companies.SingleOrDefault( s => s.Email == company.Email);
            if(EmailCompany != null)
            {
                return false;
            }
            var Companies = new Company()
            {
                Name = company.Name,
                Email = company.Email,
                Phone = company.Phone,
                Description = company.Description,
                Location = company.Location,
                Industry = company.Industry,
                Website = company.Website,
                size = company.size,
                User = user,
            };
            _context.Companies.Add( Companies );
            _context.SaveChanges();
            return true;
        }

        public ICollection<Company> GetAll()
        {
            return _context.Companies.ToList();
        }

        public Company GetById(long companyid)
        {
            throw new NotImplementedException();
        }

        public User GetByUserId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
