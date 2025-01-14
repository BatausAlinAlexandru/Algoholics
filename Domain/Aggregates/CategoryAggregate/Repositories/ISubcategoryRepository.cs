using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;

namespace Domain.Aggregates.CategoryAggregate.Repositories
{
    public interface ISubcategoryRepository
    {
        Task<List<Subcategory>> GetAllSubcategoriesAsync();
        Task<Subcategory?> GetSubcategoryByIdAsync(Guid idSubcategory);
        Task<List<Subcategory>> GetSubcategoriesByCategoryIdAsync(Guid idCategory);

        Task<Subcategory?> GetSubcategoryByCategoryIdAsync(Guid idSubcategory);

        Task<Result> AddSubcategoryAsync(Subcategory subcategory);
        Task<Result> UpdateSubcategoryAsync(Subcategory updatedSubcategory);
        Task<Result> DeleteSubcategoryAsync(Guid idSubcategory);
       
    }
}
