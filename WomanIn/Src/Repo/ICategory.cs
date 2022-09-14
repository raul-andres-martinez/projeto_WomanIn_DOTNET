using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    public interface ICategory
    {
        /// <summary>
        /// <para>Resumo: Responsavel por representar ações de CRUD de Categorias</para>
        /// <para>Criado por: Equipe WomanIn (BdR)</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 13/09/2022</para>
        /// </summary>
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task NewCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}
