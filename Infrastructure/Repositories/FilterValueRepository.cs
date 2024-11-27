using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;
using Domain.Aggregates.CategoryAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class FilterValueRepository : IFilterValueRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FilterValueRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Result> AddFilterValue(FilterValue filterValue)
        {
            await _applicationDbContext.FilterValues.AddAsync(filterValue);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> DeleteFilterValue(Guid idFilterValue)
        {
            var filterValue = await _applicationDbContext.FilterValues.FindAsync(idFilterValue);

            if (filterValue is not null)
            {
                _applicationDbContext.FilterValues.Remove(filterValue);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            return Result.Failure("FilterValue not found.");
        }

        public async Task<List<FilterValue>> GetAllFilterValues()
        {
            return await _applicationDbContext.FilterValues.ToListAsync();
        }

        public async Task<FilterValue> GetFilterValueById(Guid idFilterValue)
        {
            var filterValue = await _applicationDbContext.FilterValues.FindAsync(idFilterValue);
            return filterValue ?? throw new InvalidOperationException("FilterValue not found.");
        }

        public async Task<Result> UpdateFilterValue(FilterValue newFilterValue)
        {
            var existingFilterValue = await _applicationDbContext.FilterValues.FindAsync(newFilterValue.Id);
            if (existingFilterValue is not null)
            {
                existingFilterValue.UpdateName(newFilterValue.Name);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            return Result.Failure("FilterValue not found.");
        }
    }
}
