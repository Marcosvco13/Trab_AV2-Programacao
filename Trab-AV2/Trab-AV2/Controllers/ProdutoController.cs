using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(ProdutoVM.ListarProdutos());
        }
    }
}
