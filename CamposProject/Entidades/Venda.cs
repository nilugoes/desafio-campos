using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CamposProject.Entidades
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonPropertyName("idVenda")]
        public int IdVenda { get; set; }
        [JsonPropertyName("idCliente")]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        [JsonPropertyName("idProduto")]
        public int IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }
        [JsonPropertyName("qtdVenda")]
        public int QtdVenda { get; set; }
        [JsonPropertyName("vlrUnitarioVenda")]
        public float VlrUnitarioVenda { get; set; }
        [JsonPropertyName("dthVenda")]
        [JsonConverter(typeof(JsonMicrosoftDateTimeConverter))]
        public DateTime DthVenda { get; set; }
        public float VlrTotalVenda { get; set; }
    }
}
