using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposProject.Entidades
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProduto { get; set; }
        public string DscProduto { get; set; }
        public float VlrProduto { get; set; }
    }
}
