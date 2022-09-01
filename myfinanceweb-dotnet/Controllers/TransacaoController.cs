using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        public TransacaoController(ILogger<TransacaoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transacao = new Transacao();
            ViewBag.List = transacao.ListaTransacoes();
            return View();
        }

        [HttpGet]
        public IActionResult CriarTransacao(int? id)
        {
            if (id != null)
            {
                var transacao = new Transacao().CarregarTransacaoPorId(id);
                ViewBag.Registro = transacao;
            }

            ViewBag.ListaPlanoContas = new PlanoConta().ListaPlanoContas();
            return View();
        }
        [HttpPost]
        public IActionResult CriarTransacao(TransacaoModel formulario)
        {
            var transacao = new Transacao();

            if (formulario.Id == null) transacao.Inserir(formulario);
            else transacao.Atualizar(formulario);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirTransacao(int id)
        {
            new Transacao().Excluir(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}