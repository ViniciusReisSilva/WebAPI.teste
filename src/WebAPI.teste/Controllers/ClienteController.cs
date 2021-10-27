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

            _Clientes.Add(new Cliente(1, "Vinicius", new DateTime(1997, 5, 20), "av prefeito joão solza lima"));
            _Clientes.Add(new Cliente(2, "Gustavo", new DateTime(2006, 2, 8), "av prefeito joão solza lima"));
            _Clientes.Add(new Cliente(3, "Sarah", new DateTime(2001, 2, 19), "av prefeito joão solza lima"));

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

        
    }
}
