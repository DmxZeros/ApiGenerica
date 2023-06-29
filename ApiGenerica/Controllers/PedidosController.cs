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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidosController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _pedidoRepositorio.PegarTodos().ToListAsync();
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedidoPeloId(int id)
        {
            Pedido pedido = await _pedidoRepositorio.PegarPeloId(id);

            if(pedido == null)
            {
                return NotFound("Pedido não encontrado");
            }

            return pedido;
        }

        // POST api/<PedidosController>
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            await _pedidoRepositorio.Inserir(pedido);

            return Ok(new
            {
                mensagem = "Pedido inserido com sucesso"
            });
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Pedido>> Put(int id, Pedido pedido)
        {
            if(id != pedido.PedidoId)
            {
                return BadRequest("Pedido não encontrado");
            }

            if(ModelState.IsValid)
            {
                await _pedidoRepositorio.Atualizar(pedido);

                return Ok(new
                {
                    mensagem = $"Pedido {pedido.PedidoId} atualizado"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> Delete(int id)
        {
            var pedido = await _pedidoRepositorio.PegarPeloId(id);

            if(pedido == null)
            {
                return NotFound($"Pedido {id} não encontrado");
            }

            await _pedidoRepositorio.Excluir(id);

            return Ok(new 
            {
                mensagem = "Pedido excluído com sucesso"
            });
        }
    }
}
