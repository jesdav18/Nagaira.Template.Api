using Nagaira.Template.Api.Features.Categories.Domain.Entities;

namespace Nagaira.Template.Api.Features.Categories.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(int categoryId);
        Task<Category> GetCategoryByDescription(string description);
        Task<List<Category>> GetActiveCategories();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task SaveChangesAsync();
    }
}
