using ITJobs.Models;

namespace ITJobs.Interface
{
    public interface ICategoryRepository
    {
        bool CreateNewCategory(long CompanyId, Category_Create category);
        ICollection<Category> GetAllCategories();
        Category GetById(long id);
        List<Category> GetByCompanyId(long companyId);
        bool Update(Category category);
        bool Delete(long id);   
    }
}
