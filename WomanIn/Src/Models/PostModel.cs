using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomanInAPI.Src.Models
{
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
