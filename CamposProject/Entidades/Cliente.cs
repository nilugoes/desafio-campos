using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CamposProject.Entidades
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonPropertyName("idCliente")]
        public int IdCliente { get; set; }
        [JsonPropertyName("nmCliente")]
        public string NmCliente { get; set; }
        public string Cidade { get; set; }
        [InverseProperty("Cliente")]
        public List<Venda> Vendas { get; set; }
    }
}
