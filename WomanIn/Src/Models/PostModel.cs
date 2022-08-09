using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomanInAPI.Src.Models
{
    [Table("tb_Posts")]
    public class PostModel
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PostDate { get; set; }

        [ForeignKey("FK_Creator")]
        public UserModel Creator { get; set; }

        [ForeignKey("FK_Category")]
        public CategoryModel Category { get; set; }
        #endregion
    }

}
