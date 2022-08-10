using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WomanInAPI.Src.Context;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo.Implementation
{
    public class CategoryRepo : ICategory
    {
        #region Attributes

        private readonly WomanInContext _context;

        #endregion

        #region Constructors

        public CategoryRepo(WomanInContext context)
        {
            _context = context;
        }

        #endregion


        #region Methods

        public async Task DeleteCategoryAsync(int id)
        {
            _context.Categories.Remove(await GetCategoryByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            if (!IdExist(id)) throw new Exception("Id da categoria não encontrado");
            return await _context.Categories.FirstOrDefaultAsync(t => t.Id == id);

            // funções auxiliares
            bool IdExist(int id)
            {
                var aux = _context.Categories.FirstOrDefault(c => c.Id == id);
                return aux != null;

            }
        }

        public async Task NewCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(
                new Category
                {
                    Name = category.Name
                });
            await _context.SaveChangesAsync();

        }

        public async Task UpdateCategoryAsync(Category category)
        {

            var categoryExist = await GetCategoryByIdAsync(category.Id);
            categoryExist.Name = category.Name;
            _context.Categories.Update(categoryExist);
            await _context.SaveChangesAsync();
        }

        #endregion

    }
}
