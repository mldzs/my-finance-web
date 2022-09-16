using Microsoft.AspNetCore.Mvc;
using myfinanceweb_dotnet.Domain;

namespace myfinanceweb_dotnet.Controllers
{
    public class RelatorioPeriodoController : Controller
    {
        private readonly ILogger<RelatorioPeriodoController> _logger;

        public RelatorioPeriodoController(ILogger<RelatorioPeriodoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string DataInicio = "0001-1-1", string DataFim = "0001-1-1")
        {
            var relatorio = new RelatorioPeriodo();
            ViewBag.List = relatorio.ListaRelatorios(DataInicio, DataFim);

            return View();
        }
    }
}
