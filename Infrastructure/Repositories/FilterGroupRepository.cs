
using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;
using Domain.Aggregates.CategoryAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class FilterGroupRepository : IFilterGroupRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public FilterGroupRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }


        public async Task<Result> AddFilterGroupAsync(FilterGroup filterGroup)
        {
            await _applicationDbContext.FilterGroups.AddAsync(filterGroup);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> DeleteFilterGroupAsync(Guid idFilterGroup)
        {
            var filterGroup = await _applicationDbContext.FilterGroups.FindAsync(idFilterGroup);
            if (filterGroup is not null)
            {
                _applicationDbContext.FilterGroups.Remove(filterGroup);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            return Result.Failure("FilterGroup not found.");
        }

        public async Task<List<FilterGroup>> GetAllFilterGroupsAsync()
        {
            return await _applicationDbContext.FilterGroups.ToListAsync();
        }

        public async Task<FilterGroup?> GetFilterGroupByIdAsync(Guid idFilterGroup)
        {
            return await _applicationDbContext.FilterGroups.FindAsync(idFilterGroup).AsTask();
        }

        public async Task<List<FilterGroup>> GetSubcategoriesBySubcategoryIdAsync(Guid idSubcategory)
        {
            return await _applicationDbContext.FilterGroups
                .Where(f => f.IdSubcategory == idSubcategory)
                .ToListAsync();
        }

        public async Task<Result> UpdateFilterGroupAsync(FilterGroup filterGroup)
        {
            var existingFilterGroup = await _applicationDbContext.FilterGroups.FindAsync(filterGroup.Id);

            if(existingFilterGroup is null)
                return Result.Failure("FilterGroup not found.");

            existingFilterGroup.UpdateName(filterGroup.Name);
            return Result.Success();
        }
    }
}
