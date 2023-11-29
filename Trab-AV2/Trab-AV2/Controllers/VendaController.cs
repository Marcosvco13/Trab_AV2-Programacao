using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trab_AV2.Model.Models;
using Trab_AV2.Model.Services;
using Trab_AV2.VM;

namespace Trab_AV2.Controllers
{

    [Authorize]
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

        public void CarregarViewBag()
        {
            ViewData["CodigoProduto"] =  new SelectList(_ServiceVenda.oRepositoryProduto.SelecionarTodos(), "Id", "NmProduto");
            ViewBag.listaProdutos = _ServiceVenda.oRepositoryVwEstoque.SelecionarTodos();
        }

        public IActionResult Manter(int codVenda = 0)
        {
            CarregarViewBag();
            if (codVenda > 0)
            {
                return View(VendaVM.SelecionarVenda(codVenda));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Manter(VendaVM vendaVM)
        {
            try
            {
                var venda = new Venda();

                var listaItens = new List<ItensVenda>();

                if(vendaVM.CodigoVenda > 0)
                {
                    venda.Id = vendaVM.CodigoVenda;
                }

                venda.IdUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
                venda.DataVenda = vendaVM.DataDaVenda;

                foreach (var item in vendaVM.ListaProdutos)
                {
                    listaItens.Add(new ItensVenda
                    {
                        ItvCodigoProduto = item.CodigoProduto,
                        ItvQuantidade = (decimal)item.Quantidade,
                        ItvValorItem = (decimal)item.ValorVenda
                    });
                }
                venda.ItensVenda = listaItens;

                if (venda.Id > 0)
                {
                    await _ServiceVenda.oRepositoryVenda.AlterarAsync(venda, venda.ItensVenda.ToList());
                }
                else
                {
                    await _ServiceVenda.oRepositoryVenda.IncluirAsync(venda);
                }
                vendaVM.CodigoVenda = venda.Id;

                CarregarViewBag();
                return View();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
