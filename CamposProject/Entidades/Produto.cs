using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CamposProject.Entidades
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonPropertyName("idProduto")]
        public int IdProduto { get; set; }
        [JsonPropertyName("dscProduto")]
        public string DscProduto { get; set; }
        [JsonPropertyName("vlrUnitario")]
        public float VlrProduto { get; set; }
        [InverseProperty("Produto")]
        public List<Venda> Vendas { get; set; }

    }
}
