using System.Threading.Tasks;
using WomanInAPI.Src.Models;
namespace WomanInAPI.Src.Services
{
    /// <summary>
    /// <para>Resumo: Interface Responsavel por representar ações de autenticação</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
    public interface IAuthentication
    {
        string EncodePassword(string password);
        Task CreateNoDuplicateUserAsync(User user);
        string GenerateToken(User user);
    }
}
