using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trab_AV2.Model.Models;
using Trab_AV2.Model.Services;
using Trab_AV2.VM;

namespace Trab_AV2.Controllers
{
    public class ProdutoController : Controller
    {
        private ServiceProduto _ServiceProduto;
        public ProdutoController()
        {
            _ServiceProduto = new ServiceProduto();
        }

        public void CarregarVeiwBag()
        {
            ViewData["Disponivel"] = new SelectList(_ServiceProduto.oRepositorySimNao.SelecionarTodos(), "Id", "Descricao");
        }

        public IActionResult Index()
        {
            return View(ProdutoVM.ListarProdutos());
        }

        public IActionResult Detail(int id)
        {
            var produto = ProdutoVM.SelecionaProduto(id);
            return View(produto);
        }

        public IActionResult Create()
        {
            CarregarVeiwBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoSalvo = await _ServiceProduto.oRepositoryProduto.IncluirAsync(produto);
                return View(produtoSalvo);
            }
            else
            {
                return View(produto);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(id);
            CarregarVeiwBag();
            return View(produto);
        }

        public async Task<IActionResult> Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                var produtoSalvo = await _ServiceProduto.oRepositoryProduto.AlterarAsync(produto);
                CarregarVeiwBag();
                return View(produtoSalvo);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var produto = ProdutoVM.SelecionaProduto(id);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProdutoVM produtoVM)
        {
            var produto = await _ServiceProduto.oRepositoryProduto.SelecionarPkAsync(produtoVM.IDProduto);
            await _ServiceProduto.oRepositoryProduto.ExcluirAsync(produto);
            return RedirectToAction("Index");
        }
    }
}
