using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WomanInAPI.Src.Models
{
    [Table("tb_Categories")]
    public class Category
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore, InverseProperty("Category")]
        public List<Post> PostCategory { get; set; }

        #endregion
    }

}
