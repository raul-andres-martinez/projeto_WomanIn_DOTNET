using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomanInAPI.Src.Models
{
    [Table("tb_posts")]
    public class PostModel
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("FK_Creator")]
        public string FK_Creator { get; set; }
        [ForeignKey("FK_Category")]
        public string FK_Category { get; set; }
        public string PostDate { get; set; }

        #endregion
    }

}
