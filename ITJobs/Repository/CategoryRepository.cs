using ITJobs.Data;
using ITJobs.Interface;
using ITJobs.Models;

namespace ITJobs.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateNewCategory(long CompanyId, Category_Create category)
        {
            var company = _context.Companies.SingleOrDefault(s => s.Id == CompanyId);
            if(company == null)
            {
                return false;
            }
            var categoryId = _context.Categories.SingleOrDefault(s => s.Companies.Id == CompanyId);
            var NewCategory = new Category()
            {
                Name = category.Name,
                Description = category.Description,
                Companies = company,
            };
            _context.Categories.Add(NewCategory);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var categories = _context.Categories.SingleOrDefault( s => s.Id == id);
            if(categories == null)
            {
                return false;
            }
            _context.Categories.Remove(categories);
            _context.SaveChanges();
            return true;
        }

        public ICollection<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Category> GetByCompanyId(long companyId)
        {
            var companies = _context.Categories.Where(s => s.Companies.Id == companyId).ToList();
            List<Category> response = new List<Category>();
            foreach(var company in companies)
            {
                response.Add(new Category
                {
                    Id = company.Id,
                    Name = company.Name,
                    Description = company.Description,
                });
            }
            return response;

        }

        public Category GetById(long id)
        {
            return _context.Categories.SingleOrDefault(S => S.Id == id);
        }

        public bool Update(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return true;
        }
    }
}
