using System.Collections.Generic;
using System.Threading.Tasks;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo
{
    public interface IPost
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task NewPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
    }
}
