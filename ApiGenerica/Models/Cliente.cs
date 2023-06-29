using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ApiGenerica.Models
{
    public class Cliente
    {
        public Cliente()
        {
            Pedidos = new Collection<Pedido>();
        }

        [Key]
        public int ClienteId { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [StringLength(1)]
        public string Sexo { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
