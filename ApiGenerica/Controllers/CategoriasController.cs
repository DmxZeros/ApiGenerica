using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGenerica.Interfaces;
using ApiGenerica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGenerica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriasRepositorio;

        public CategoriasController(ICategoriaRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _categoriasRepositorio.PegarTodos().ToListAsync();
        }

        // GET api/<CategoriasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaPeloId(int id)
        {
            Categoria categoria = await _categoriasRepositorio.PegarPeloId(id);

            if(categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            return categoria;
        }

        // POST api/<CategoriasController>
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            await _categoriasRepositorio.Inserir(categoria);

            return Ok(new {
                mensagem = "Categoria criada com sucesso"
            });
        }

        // PUT api/<CategoriasController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest("Registro não encontrado");
            }

            if(ModelState.IsValid)
            {
                await _categoriasRepositorio.Atualizar(categoria);

                return Ok(new 
                {
                    mensagem = $"Categoria {categoria.CategoriaId} atualizada com sucesso"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<CategoriasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = await _categoriasRepositorio.PegarPeloId(id);

            if(categoria == null)
            {
                return NotFound();
            }

            await _categoriasRepositorio.Excluir(id);

            return Ok(new
            {
                mensagem = $"Registro {categoria.Nome} excluída com sucesso"
            });
        }
    }
}
