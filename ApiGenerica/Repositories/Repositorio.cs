using ApiGenerica.Context;
using ApiGenerica.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGenerica.Repositories
{
    public class Repositorio<Tentity>: IRepositorio<Tentity> where Tentity: class
    {
        private readonly ContextoDb _contextoDb;

        public Repositorio(ContextoDb contextoDb)
        {
            _contextoDb = contextoDb;
        }

        public async Task Atualizar(Tentity entity)
        {
            try
            {
                var registro = _contextoDb.Set<Tentity>().Update(entity);
                registro.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _contextoDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(Tentity entity)
        {
            try
            {
                _contextoDb.Set<Tentity>().Remove(entity);
                await _contextoDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                var registro = await PegarPeloId(id);
                _contextoDb.Set<Tentity>().Remove(registro);
                await _contextoDb.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Inserir(Tentity entity)
        {
            try
            {
                await _contextoDb.AddAsync(entity);
                await _contextoDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Inserir(List<Tentity> entity)
        {
            try
            {
                await _contextoDb.AddRangeAsync(entity);
                await _contextoDb.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Tentity> PegarPeloId(int id)
        {
            try
            {
                var registro = await _contextoDb.Set<Tentity>().FindAsync(id);
                return registro;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<Tentity> PegarTodos()
        {
            try
            {
                return _contextoDb.Set<Tentity>().AsNoTracking();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
