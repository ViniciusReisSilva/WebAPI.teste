using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.teste.Models;

namespace WebAPI.teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private List<Cliente> _Clientes;

        public ClienteController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            _Clientes = new List<Cliente>();

            _Clientes.Add(new Cliente(1, "Vinicius", new DateTime(3000, 5, 20), 1000.10, "M"));
            _Clientes.Add(new Cliente(2, "Gustavo", new DateTime(2006, 2, 8), 1000.32, "M"));
            _Clientes.Add(new Cliente(3, "Sarah", new DateTime(2001, 2, 19), 90000.30, "F"));

         }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Clientes);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var cliente = _Clientes.Where(a => a.Id == id).FirstOrDefault();
            
            if (cliente == null)
            {
                return NotFound();
            }
            
            return Ok(cliente);
        }

        [HttpGet("{nome}")]
        public IActionResult GetByNome(string nome)
        {
            var cliente = _Clientes.Where(a => a.Nome.Contains(nome)).ToList();
            
            if (cliente == null)
            {
                return NotFound();
            }
            
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Cliente model)
        {
            if (string.IsNullOrEmpty(model.Sexo) || model.Sexo != "F" && model.Sexo != "M")
            {           
                return BadRequest("Campo Sexo não pode ser diferente de F ou M");
            }
            
            if (model.Datanascimento > DateTime.Now)
            {
                return BadRequest("Data de nascimento não pode ser uma data futura");
            }

            return Created("/Cliente", model);
            
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var cliente = _Clientes.Where(a => a.Id == id).FirstOrDefault();

            if (cliente == null) 
            {
                return NotFound(new {message = "Cliente informado não existe", id = id});
            }

            if (cliente.Salario > 10000) 
            {
                return BadRequest("não é possi­vel deletar este cliente");
            }
            return Ok("cliente excluido com sucesso.");
            
        }

        
    }
}
