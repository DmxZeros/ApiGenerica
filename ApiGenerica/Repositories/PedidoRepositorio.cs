using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGenerica.Interfaces;
using ApiGenerica.Models;
using ApiGenerica.Context;

namespace ApiGenerica.Repositories
{
    public class PedidoRepositorio: Repositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(ContextoDb contextoDb) :base(contextoDb)
        {

        }
    }
}
