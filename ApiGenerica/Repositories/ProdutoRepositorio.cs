using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGenerica.Context;
using ApiGenerica.Interfaces;
using ApiGenerica.Models;

namespace ApiGenerica.Repositories
{
    public class ProdutoRepositorio: Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(ContextoDb contextoDb): base(contextoDb)
        {

        }
    }
}
