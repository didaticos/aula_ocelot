using Microsoft.AspNetCore.Mvc;

using modelos;

namespace backend02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CashbackController : ControllerBase
    {

        private readonly ILogger<CashbackController> _logger;

        public CashbackController(ILogger<CashbackController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Registrar")]
        public RespostaCashback Registrar([FromBody] RequisicaoCashBack model)
        {
            return new RespostaCashback
            {
                Valor = model.Valor,
                Id = Guid.NewGuid(),
                Status = new Random().Next(minValue:0, maxValue: 3) != 1 ? "Sucesso" : "Falha",
            };
        }


    }
}