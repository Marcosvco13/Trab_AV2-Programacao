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
            return View(VendaVM.ListarTodasVendas());
        }

        public IActionResult Detail(int id)
        {
            var venda = VendaVM.SelecionarVenda(id);
            return View(venda);
        }

        public void CarregarViewBag()
        {
            ViewData["Produto"] = new SelectList(_ServiceVenda.oRepositoryProduto.SelecionarTodos(), "Id", "NmProduto");
            ViewBag.listaProdutos = _ServiceVenda.oRepositoryVwEstoque.SelecionarTodos();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregarViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venda venda)
        {
            if (ModelState.IsValid)
            {
                var vendaEfetuada = await _ServiceVenda.oRepositoryVenda.IncluirAsync(venda);
                return View(vendaEfetuada);
            }
            else
            {
                return View(venda);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var venda = await _ServiceVenda.oRepositoryVenda.SelecionarPkAsync(id);
            CarregarViewBag();
            return View(venda);
        }

        public async Task<IActionResult> Edit(Venda venda)
        {
            if (!ModelState.IsValid)
            {
                var vendaEfetuada = await _ServiceVenda.oRepositoryVenda.AlterarAsync(venda);
                CarregarViewBag();
                return View(venda);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceVenda.oRepositoryVenda.ExcluirAsync(id);
            return RedirectToAction("Index");
        }
    }
}
