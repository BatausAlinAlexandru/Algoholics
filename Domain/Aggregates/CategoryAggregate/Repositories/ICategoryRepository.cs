using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;

namespace Domain.Aggregates.CategoryAggregate.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(Guid idCategory);
        Task<Result> AddCategoryAsync(Category category);
        Task<Result> UpdateCategoryAsync(Category category);
        Task<Result> DeleteCategoryAsync(Guid idCategory);
    }
}
