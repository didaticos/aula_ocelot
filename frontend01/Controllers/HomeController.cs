using frontend01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Flurl.Http;
using modelos;

namespace frontend01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string _url = "https://localhost:9000";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ListarPedidos()
        {
            var listaPedidos = await $"{_url}/listar-pedidos".GetJsonAsync<List<Pedidos>>();
            return View("index", listaPedidos);
        }


        public IActionResult RegistrarCashBack()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarCashBack([Bind("Valor")] modelos.RequisicaoCashBack req)
        {
            var listaPedidos = await $"{_url}/registrar-cashback"
                .PostJsonAsync(req)
                .ReceiveJson<modelos.RespostaCashback>();
            return View("RegistrarCashBack", listaPedidos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}