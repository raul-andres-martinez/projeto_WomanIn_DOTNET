using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de usuários</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
    public interface IUser
    {
        Task<User> GetUserByEmailAsync(string email);
        Task NewUserAsync(User user);
        Task UpdateUserAsync(User user); //possivel redundancia
        Task DeleteUserAsync(string email);
    }
}
