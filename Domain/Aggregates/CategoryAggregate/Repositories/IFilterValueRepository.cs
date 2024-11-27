using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;

namespace Domain.Aggregates.CategoryAggregate.Repositories
{
    public interface IFilterValueRepository
    {
        Task<List<FilterValue>> GetAllFilterValues();
        Task<FilterValue> GetFilterValueById(Guid idFilterValue);
        Task<Result> AddFilterValue(FilterValue filterValue);
        Task<Result> UpdateFilterValue(FilterValue newFilterValue);
        Task<Result> DeleteFilterValue(Guid idFilterValue);
    }
}
