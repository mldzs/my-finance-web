using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinanceweb_dotnet.Domain;
using myfinanceweb_dotnet.Models;

namespace myfinanceweb_dotnet.Controllers
{
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var planoContas = new PlanoConta();
            ViewBag.list = planoContas.ListaPlanoContas();
            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id != null)
            {
                var planoConta = new PlanoConta().CarregarPlanoContaPorId(id);
                ViewBag.PlanoConta = planoConta;
            }

            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel formulario)
        {
            var planoConta = new PlanoConta();

            if (formulario.Id == null) planoConta.Insert(formulario);
            else planoConta.Atualizar(formulario);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            new PlanoConta().Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
