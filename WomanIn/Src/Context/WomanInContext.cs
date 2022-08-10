using Microsoft.EntityFrameworkCore;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Context
{
    public class WomanInContext : DbContext
    {
        #region Atributos
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        #endregion
        #region Construtores
        public WomanInContext(DbContextOptions<WomanInContext> opt) : base(opt)
        {
        }
        #endregion
    }

}
