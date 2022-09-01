using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class RelatorioPeriodoController : Controller
    {
        private readonly ILogger<RelatorioPeriodoController> _logger;

        public RelatorioPeriodoController(ILogger<RelatorioPeriodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string DataInicio = "1/1/0001", string DataFim = "1/31/0001")
        {
            var relatorio = new RelatorioPeriodo();
            ViewBag.List = relatorio.ListaRelatorios(DataInicio, DataFim);

            return View();
        }

        [HttpGet]
        public IActionResult GerarRelatorio()
        {
            var teste = new RelatorioPeriodo();


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}