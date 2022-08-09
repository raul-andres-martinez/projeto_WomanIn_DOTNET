using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WomanInAPI.Src.Models
{
    [Table("tb_usuarios")]
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

        #endregion
    }
}
