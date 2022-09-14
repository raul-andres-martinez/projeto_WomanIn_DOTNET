using Microsoft.EntityFrameworkCore;
using WomanInAPI.Src.Models;

namespace WomanInAPI.Src.Context
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsável por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
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
