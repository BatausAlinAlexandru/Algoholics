using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;
using Domain.Aggregates.CategoryAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SubcategoryRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<Result> UpdateSubcategoryAsync(Subcategory subcategory)
        {
            var existingSubcategory = await _applicationDbContext.Subcategories.FindAsync(subcategory.Id);

            if (existingSubcategory == null)
                throw new InvalidOperationException("Subcategory not found.");

            existingSubcategory.UpdateName(subcategory.Name);

            foreach (var filter in subcategory.FiltersGroups)
            {
                if (!existingSubcategory.FiltersGroups.Any(f => f.Id == filter.Id))
                    existingSubcategory.AddFilterGroup(filter.Name);
            }

            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }


        public async Task<List<Subcategory>> GetAllSubcategoriesAsync()
        {
            return await _applicationDbContext.Subcategories.ToListAsync();
        }

        public async Task<List<Subcategory>> GetSubcategoriesByCategoryIdAsync(Guid idCategory)
        {
            return await _applicationDbContext.Subcategories
                .Where(c => c.IdCategory == idCategory)
                .ToListAsync();
        }

        public async Task<Subcategory?> GetSubcategoryByIdAsync(Guid idCategory)
        {
            var subcategory = await _applicationDbContext.Subcategories
                .Include(c => c.FiltersGroups)
                .FirstOrDefaultAsync(c => c.Id == idCategory);

            return subcategory;
        }

        public async Task<Subcategory?> GetSubcategoryByNameAsync(string nameSubcategory)
        {
            var subcategory = await _applicationDbContext.Subcategories
                .Include(c => c.FiltersGroups)
                .FirstOrDefaultAsync(c => c.Name == nameSubcategory);

            return subcategory;
        }


        public async Task<Result> AddFilterGroup(Guid idSubcategory, string filterGroupName)
        {
            var subcategory = await _applicationDbContext.Subcategories.FindAsync(idSubcategory);

            if (subcategory == null)
                return Result.Failure("Subcategory is null.");

            subcategory.AddFilterGroup(filterGroupName);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }
        public async Task<Result> RemoveFilterGroup(Guid idSubcategory, string filterGroupName)
        {
            var subcategory = await _applicationDbContext.Subcategories.FindAsync(idSubcategory);

            if (subcategory == null)
                return Result.Failure("Subcategory is null.");

            subcategory.RemoveFilterGroup(filterGroupName);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> AddSubcategoryAsync(Subcategory subcategory)
        {
            await _applicationDbContext.Subcategories.AddAsync(subcategory);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> DeleteSubcategoryAsync(Guid idSubcategory)
        {
            var subcategory = await _applicationDbContext.Subcategories.FindAsync(idSubcategory);

            if (subcategory is not null)
            {
                _applicationDbContext.Subcategories.Remove(subcategory);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            return Result.Failure("Error added subcategory");
        }

        public async Task<Subcategory?> GetSubcategoryByCategoryIdAsync(Guid idSubcategory)
        {
            return await _applicationDbContext.Subcategories.FindAsync(idSubcategory).AsTask();
        }

    }
}
