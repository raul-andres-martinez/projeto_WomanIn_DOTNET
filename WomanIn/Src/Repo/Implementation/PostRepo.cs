using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WomanInAPI.Src.Context;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Repo.Implementation {
    public class PostRepo : IPost {
        #region Attributes

        private readonly WomanInContext _context;

        #endregion

        #region Constructors

        public PostRepo(WomanInContext context) {
            _context = context;
        }

        #endregion


        #region Methods

        public async Task DeletePostAsync(int id) {
            _context.Posts.Remove(await GetPostByIdAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPostsAsync() {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id) {
            if (!IdExist(id)) throw new Exception("Id da postagem não encontrado");
            return await _context.Posts.FirstOrDefaultAsync(t => t.Id == id);

            // funções auxiliares
            bool IdExist(int id) {
                var aux = _context.Posts.FirstOrDefault(c => c.Id == id);
                return aux != null;

            }
        }

        public async Task NewPostAsync(Post post) {
            await _context.Posts.AddAsync(
                new Post {
                    Title = post.Title,
                    Description = post.Description,
                    PostDate = DateTime.Now,
                    Creator = _context.Users.FirstOrDefault(u => u.Id == post.Creator.Id),
                    Category = _context.Categories.FirstOrDefault(c => c.Id == post.Category.Id)
                });
            await _context.SaveChangesAsync();

        }

        public async Task UpdatePostAsync(Post post) {

            var postExist = await GetPostByIdAsync(post.Id);
            postExist.Id = post.Id;
            _context.Posts.Update(postExist);
            await _context.SaveChangesAsync();
        }

        #endregion

    }
}