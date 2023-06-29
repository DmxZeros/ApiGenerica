using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGenerica.Models;
using ApiGenerica.Interfaces;
using ApiGenerica.Context;

namespace ApiGenerica.Repositories
{
    public class CategoriaRepositorio: Repositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(ContextoDb contextoDb): base(contextoDb)
        {

        }
    }
}
