using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de Postagens</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
    public interface IPost
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task NewPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}
