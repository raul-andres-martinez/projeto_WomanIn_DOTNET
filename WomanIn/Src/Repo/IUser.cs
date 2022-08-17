using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    public interface IUser
    {
        Task<User> GetUserByEmailAsync(string email);
        Task NewUserAsync(User user);
        Task UpdateUserAsync(User user); //possivel redundancia
        Task DeleteUserAsync(string email);
    }
}
