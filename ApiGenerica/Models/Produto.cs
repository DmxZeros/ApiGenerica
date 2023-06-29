using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGenerica.Models
{
    public class Produto
    {
        public Produto()
        {
            PedidoItems = new Collection<PedidoItem>();
        }

        [Key]
        public int ProdutoId { get; set; }

        [StringLength(30)]
        public string Nome { get; set; }

        public decimal? Preco { get; set; }
        
        [StringLength(100)]
        public string Descricao { get; set; }
        
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public ICollection<PedidoItem> PedidoItems { get; set; }
    }
}
