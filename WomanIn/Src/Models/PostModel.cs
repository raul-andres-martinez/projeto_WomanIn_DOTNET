using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomanInAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsável por representar tb_Posts no banco de dados.</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
    [Table("tb_Posts")]
    public class Post
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }

        [ForeignKey("FK_Creator")]
        public User Creator { get; set; }

        [ForeignKey("FK_Category")]
        public Category Category { get; set; }
        #endregion
    }

}
