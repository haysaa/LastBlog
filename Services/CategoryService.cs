using Blogb.Data;
using Blogb.Data.Entities;
using Blogb.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogb.Services
{
    public class CategoryService
    {
        private readonly BlogContext _context;

        public CategoryService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
            await _context.Categories
            .AsNoTracking()
            .ToListAsync();

        public async Task<MethodResult> SaveCategoryAsync(Category model)
        {
            try
            {
                if (model.Id > 0)
                {
                    // update category
                    _context.Categories.Update(model);
                }
                else
                {
                    // create category
                    model.Slug = model.Slug.Slugify();
                    await _context.Categories.AddAsync(model);
                }
                await _context.SaveChangesAsync();
                return MethodResult.Succes();
            }
            catch (Exception ex)
            {
                // log exception
                return MethodResult.Failure(ex.Message);
            }
        }


    }
}