using CSharpFunctionalExtensions;
using Domain.Aggregates.CategoryAggregate.Entities;
using Domain.Aggregates.CategoryAggregate.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _applicationDbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid idCategory)
        {
            return await _applicationDbContext.Categories
                .Include(c => c.Subcategories)
                .ThenInclude(sc => sc.FiltersGroups)
                .FirstOrDefaultAsync(c => c.Id == idCategory);
        }

        public async Task<Result> AddCategoryAsync(Category category)
        {
            await _applicationDbContext.Categories.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> UpdateCategoryAsync(Category category)
        {
            _applicationDbContext.Categories.Update(category);
            await _applicationDbContext.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result> DeleteCategoryAsync(Guid idCategory)
        {
            var category = await _applicationDbContext.Categories.FindAsync(idCategory);
            if (category != null)
            {
                _applicationDbContext.Categories.Remove(category);
                await _applicationDbContext.SaveChangesAsync();
                return Result.Success();
            }
            return Result.Failure("Category not found.");
        }
    }

}
