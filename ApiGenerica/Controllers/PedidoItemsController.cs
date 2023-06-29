using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGenerica.Models;
using ApiGenerica.Interfaces;
using ApiGenerica.Context;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGenerica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItemsController : ControllerBase
    {
        private readonly IPedidoItemRepositorio _pedidoItemRepositorio;

        public PedidoItemsController(IPedidoItemRepositorio pedidoItemRepositorio)
        {
            _pedidoItemRepositorio = pedidoItemRepositorio;
        }

        // GET: api/<PedidoItemsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoItem>>> GetPedidoItems()
        {
            return await _pedidoItemRepositorio.PegarTodos().ToListAsync();
        }

        // GET api/<PedidoItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoItem>> GetPedidoItemPeloId(int id)
        {
            PedidoItem pedidoItem = await _pedidoItemRepositorio.PegarPeloId(id);

            if(pedidoItem == null)
            {
                return NotFound("Item não encontrado");
            }

            return pedidoItem;
        }

        // POST api/<PedidoItemsController>
        [HttpPost]
        public async Task<ActionResult<PedidoItem>> Post(PedidoItem pedidoItem)
        {
            await _pedidoItemRepositorio.Inserir(pedidoItem);

            return Ok(new 
            {
                mensagem = "Item cadastrado com sucesso"
            });
        }

        // PUT api/<PedidoItemsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoItem>> Put(int id, PedidoItem pedidoItem)
        {
            if( id != pedidoItem.PedidoItemId)
            {
                return BadRequest("Item não encontrado");
            }

            if(ModelState.IsValid)
            {
                await _pedidoItemRepositorio.Atualizar(pedidoItem);

                return Ok(new 
                {
                    mensagem = $"Item {pedidoItem.PedidoItemId} atualizado"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<PedidoItemsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoItem>> Delete(int id)
        {
            var pedidoItem = await _pedidoItemRepositorio.PegarPeloId(id);

            if (pedidoItem == null)
            {
                return NotFound($"Item {id} não encontrado");
            }

            await _pedidoItemRepositorio.Excluir(id);

            return Ok(new
            {
                mensagem = "Item excluído com sucesso"
            });
        }
    }
}
