using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGenerica.Models
{
    public class Pedido
    {
        public Pedido()
        {
            PedidoItems = new Collection<PedidoItem>();
        }

        [Key]
        public int PedidoId { get; set; }
        
        public DateTime Data { get; set; }
        
        public int QuantidadeItens { get; set; }
        
        public decimal? Valor { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<PedidoItem> PedidoItems { get; set; }
    }
}
