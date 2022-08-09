using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WomanInAPI.Src.Models
{
    [Table("tb_Users")]
    public class UserModel
    {
        #region Atributos
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Area { get; set; }

        [JsonIgnore, InverseProperty("Creator")]
        public List<PostModel> MyPosts { get; set; }


        #endregion
    }
}
