using Microsoft.AspNetCore.Mvc;

using modelos;

namespace backend01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private static readonly string[] Dados = new[]
        {
            "Carne", "Frango", "Cerveja", "Refrigerante", "Peixe", "Farinha", "Limão", "Morango", "Ovos", "Macarrão"
        };

        private readonly ILogger<PedidosController> _logger;
        private IConfiguration _config;
        public PedidosController(ILogger<PedidosController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet(Name = "ListarPedidos")]
        public IEnumerable<Pedidos> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Pedidos
            {
                Data = DateTime.Now.AddDays(index),
                Id = Guid.NewGuid(),
                Dados = Dados[Random.Shared.Next(Dados.Length)], 
                Maquina = _config["MeuNome"]
            })
            .ToArray();
        }
        
    }
}