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
    public class ProdutoController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private List<Produto> _Produtos;

        public ProdutoController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            _Produtos = new List<Produto>();

            _Produtos.Add(new Produto(1, "Chave", 3.99, "Chave de Fenda Comum"));
            _Produtos.Add(new Produto(2, "Porca", 1.99, "Porca de parafuso tamanho 1 7/8"));
            _Produtos.Add(new Produto(3, "Parafuso", 2.99, "Parafuso tamanho 1 7/8"));
            _Produtos.Add(new Produto(4, "mangueira", 7.99, "mangueira 5 metros"));
            _Produtos.Add(new Produto(5, "Cone", 5.99, "Cone de transito laranjado"));

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Produtos);
        }
        
    }
}
