using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposProject.Entidades
{
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdVenda { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public int IdProduto { get; set; }
        [ForeignKey("IdProduto")]
        public Produto Produto { get; set; }
        public int QtdVenda { get; set; }
        public float VlrUnitarioVenda { get; set; }
        public DateTime DthVenda { get; set; }
        public float VlrTotalVenda { get; set; }
    }
}
