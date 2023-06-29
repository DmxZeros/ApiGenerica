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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutosController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _produtoRepositorio.PegarTodos().ToListAsync();
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoPeloId(int id)
        {
            Produto produto = await _produtoRepositorio.PegarPeloId(id);

            if(produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            return produto;
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            await _produtoRepositorio.Inserir(produto);

            return Ok(new
            {
                mensagem = "Registro inserido com sucesso"
            });
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest("Produto não encontrado");
            }

            if(ModelState.IsValid)
            {
                await _produtoRepositorio.Atualizar(produto);

                return Ok(new
                {
                    mensagem = $"Registro {produto.ProdutoId} atualizado com sucesso"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = await _produtoRepositorio.PegarPeloId(id);

            if(produto == null)
            {
                return NotFound();
            }

            await _produtoRepositorio.Excluir(id);

            return Ok(new
            {
                mensagem = $"Registro {produto.Nome} excluído com sucesso"
            });
        }
    }
}
