
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WomanInAPI.Src.Utilities;

namespace WomanInAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsável por representar tb_Users no banco de dados.</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
    [Table("tb_Users")]
    public class User
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
        
        [Required]
        public UserType Type { get; set; }

        [JsonIgnore, InverseProperty("Creator")]
        public List<Post> MyPosts { get; set; }


        #endregion
    }
}
