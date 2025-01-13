using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;

namespace Domain.Aggregates.CategoryAggregate.Repositories
{
    public interface IFilterGroupRepository
    {
        Task<List<FilterGroup>> GetAllFilterGroupsAsync();
        Task<FilterGroup?> GetFilterGroupByIdAsync(Guid idFilterGroup);
        Task<List<FilterGroup>> GetFilterGroupBySubcategoryIdAsync(Guid idSubcategory);
        Task<Result> AddFilterGroupAsync(FilterGroup filterGroup);
        Task<Result> UpdateFilterGroupAsync(FilterGroup filterGroup);
        Task<Result> DeleteFilterGroupAsync(Guid idFilterGroup);
        Task<IEnumerable<object>> GetFilterGroupsBySubcategoryIdAsync(Guid idSubcategory);
    }
}
