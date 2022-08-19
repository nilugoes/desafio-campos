using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CamposProject.Entidades
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCliente { get; set; }
        public string NmCliente { get; set; }
        public string Cidade { get; set; }

        [InverseProperty("Cliente")]
        public List<Venda> Vendas { get; set; }
    }
}
