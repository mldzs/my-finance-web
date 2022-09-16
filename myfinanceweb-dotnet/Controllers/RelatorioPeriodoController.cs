using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IActionResult Index(string DataInicio = "1/1/0001", string DataFim = "1/31/0001")
        {
            var relatorio = new RelatorioPeriodo();
            ViewBag.List = relatorio.ListaRelatorios(DataInicio, DataFim);

            return View();
        }
    }
}
