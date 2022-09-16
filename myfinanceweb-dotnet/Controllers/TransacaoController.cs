using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinanceweb_dotnet.Domain;
using myfinanceweb_dotnet.Models;

namespace myfinanceweb_dotnet.Controllers
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
            var model = new TransacaoModel();
            if (id != null)
            {
                var transacao = new Transacao().CarregarTransacaoPorId(id);
                model = transacao;
            }

            model.PlanoContas = new PlanoConta().ListaSelectItemPlanoContas();
            return View(model);
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
    }
}
