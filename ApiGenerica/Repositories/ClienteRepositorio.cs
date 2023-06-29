using ApiGenerica.Context;
using ApiGenerica.Interfaces;
using ApiGenerica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGenerica.Repositories
{
    public class ClienteRepositorio: Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(ContextoDb contextoDb) :base(contextoDb)
        {

        }
    }
}
