using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trab_AV2.Model.Models;
using Trab_AV2.Model.Services;
using Trab_AV2.VM;

namespace Trab_AV2.Controllers
{
    public class VendaController : Controller
    {
        private ServiceVenda _ServiceVenda;

        public VendaController()
        {
            _ServiceVenda = new ServiceVenda();
        }
        public IActionResult Index()
        {
            return View();
        }

        public void CarregarViewBag()
        {
            ViewData["CodigoProduto"] =  new SelectList(_ServiceVenda.oRepositoryProduto.SelecionarTodos(), "Id", "NmProduto");
            ViewBag.listaProdutos = _ServiceVenda.oRepositoryVwEstoque.SelecionarTodos();
        }

        [HttpGet]
        public IActionResult Manter()
        {
            CarregarViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Manter(VendaVM vendaVM)
        {
            CarregarViewBag();
            return View();
        }
    }
}
