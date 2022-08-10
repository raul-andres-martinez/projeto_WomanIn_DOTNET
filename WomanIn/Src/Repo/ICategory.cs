using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    public interface ICategory
    {
        Task<List<Category>> PegarTodosTemasAsync();
        Task<Category> PegarTemaPeloIdAsync(int id);
        Task NovoTemaAsync(Category category);
        Task AtualizarTemaAsync(Category category);
        Task DeletarTemaAsync(int id);
    }
}
