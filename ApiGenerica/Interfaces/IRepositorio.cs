using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGenerica.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        IQueryable<TEntity> PegarTodos();

        Task<TEntity> PegarPeloId(int id);

        Task Inserir(TEntity entity);
        Task Inserir(List<TEntity> entity);

        Task Atualizar(TEntity entity);

        Task Excluir(TEntity entity);
        Task Excluir(int id);


    }
}
