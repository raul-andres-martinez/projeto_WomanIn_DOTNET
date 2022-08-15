using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    public interface IPost
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task NewCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
