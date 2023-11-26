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
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregarViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Venda venda, int[] produtosSelecionados)
        {
            if (ModelState.IsValid)
            {
                // Lógica para criar uma nova venda
                var novaVenda = new Venda
                {
                    // Defina os outros campos da venda conforme necessário
                    IdUser = venda.IdUser,
                    DataVenda = DateTime.Now,
                    // ...

                    // Adicione a lógica para calcular o valor total da venda, se necessário
                    ValorVenda = 0 // Por enquanto, vamos inicializar como 0
                };

                // Adicione a nova venda ao contexto
                await _ServiceVenda.oRepositoryVenda.IncluirAsync(novaVenda);

                // Agora, adicione os produtos selecionados à venda
                foreach (var idProduto in produtosSelecionados)
                {
                    var produto = _ServiceVenda.oRepositoryProduto.SelecionarPk(idProduto);

                    // Verifica se o produto existe e se está disponível
                    if (produto != null && produto.Disp > 0)
                    {
                        // Cria um novo item de venda associado ao produto
                        var itemVenda = new ItemVenda
                        {
                            VendaId = novaVenda.Id, // ID da nova venda criada
                            ProdutoId = produto.Id,
                            // Adicione outras propriedades do item de venda, se necessário
                        };

                        // Adicione o item de venda ao contexto
                        await _ServiceVenda.oRepositoryVenda.IncluirAsync(itemVenda);

                        // Atualize o valor total da venda ao adicionar o valor do produto
                        novaVenda.ValorVenda += produto.Valor;
                    }
                }

                // Atualize a venda com o valor total
                await _ServiceVenda.oRepositoryVenda.AlterarAsync(novaVenda);

                return RedirectToAction("Detail", new { id = novaVenda.Id });
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
