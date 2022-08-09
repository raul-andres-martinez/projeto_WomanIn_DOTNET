using Microsoft.EntityFrameworkCore;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Context
{
    public class WomanInContext : DbContext
    {
        #region Atributos
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        #endregion
        #region Construtores
        public WomanInContext(DbContextOptions<WomanInContext> opt) : base(opt)
        {
        }
        #endregion
    }

}
