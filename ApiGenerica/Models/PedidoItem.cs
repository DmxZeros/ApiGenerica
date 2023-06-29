using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiGenerica.Models
{
    public class PedidoItem
    {
        [Key]
        public int PedidoItemId { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
