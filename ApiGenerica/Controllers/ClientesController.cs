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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClientesController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
            return await _clienteRepositorio.PegarTodos().ToListAsync();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClientePeloId(int id)
        {
            Cliente cliente = await _clienteRepositorio.PegarPeloId(id);

            if(cliente  == null)
            {
                return NotFound("Resgistro não encontrado");
            }

            return cliente;
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            await _clienteRepositorio.Inserir(cliente);

            /*retornar o registro inserido*/

            return Ok(new
            {
                mensagem = "Registro inserido com sucesso"
            });
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Put(int id, Cliente cliente)
        {
            if(id != cliente.ClienteId)
            {
                return BadRequest("Registro não encontrado");
            }

            if (ModelState.IsValid)
            {
                await _clienteRepositorio.Atualizar(cliente);

                return Ok(new
                {
                    mensagem = $"Registro {cliente.ClienteId} atualizado com sucesso"
                });
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var cliente = await _clienteRepositorio.PegarPeloId(id);

            if(cliente == null)
            {
                return NotFound();
            }

            await _clienteRepositorio.Excluir(id);

            return Ok(new
            {
                mensagem = $"Registro {cliente.Nome} excluído com sucesso"
            });
        }
    }
}
