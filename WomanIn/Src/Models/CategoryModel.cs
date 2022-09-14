using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WomanInAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsável por representar tb_Categories no banco de dados.</para>
    /// <para>Criado por: Equipe WomanIn (BdR)</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 13/09/2022</para>
    /// </summary>
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
