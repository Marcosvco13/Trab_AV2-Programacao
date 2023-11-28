using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
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
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregarViewBag();
            return View();
        }

        public async Task<IActionResult> Manter(VendaVM vendaVM)
        {
            try
            {
                var venda = new Venda();

                if (vendaVM.CodigoVenda > 0)
                {
                    // Se é uma venda existente, busca do banco de dados
                    venda = await _ServiceVenda.oRepositoryVenda.SelecionarPkAsync(vendaVM.CodigoVenda);
                }

                // Preenche os detalhes da venda com base nos dados recebidos da View
                venda.IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                venda.IdProduto = (int)vendaVM.CodigoProduto;
                venda.DataVenda = vendaVM.DataDaVenda;
                venda.ValorVenda = vendaVM.ValorDaVenda;

                // Lista para armazenar os itens da venda
                var listaItens = new List<ItemVenda>();

                foreach (var item in vendaVM.ListaProdutos)
                {
                    listaItens.Add(new ItemVenda
                    {
                        ProdutoId = item.CodigoProduto, // Ajuste conforme sua lógica de associação de produtos com itens de venda
                        ValorVenda = item.ValorVenda
                        // Aqui você pode preencher outras propriedades do item da venda, se necessário
                    });
                }

                // Define os itens da venda
                venda.ItemVenda = listaItens;

                if (venda.Id > 0)
                {
                    // Se a venda já existe, faz a alteração (atualização) no banco de dados
                    await _ServiceVenda.oRepositoryVenda.AlterarAsync(venda, venda.ItemVenda.ToList());
                }
                else
                {
                    // Caso contrário, é uma nova venda e deve ser incluída no banco de dados
                    await _ServiceVenda.oRepositoryVenda.IncluirAsync(venda);
                }

                vendaVM.CodigoVenda = venda.Id;

                CarregarViewBag();
                return View();
            }
            catch (Exception ex)
            {
                // Lida com exceções, se necessário
                throw;
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
