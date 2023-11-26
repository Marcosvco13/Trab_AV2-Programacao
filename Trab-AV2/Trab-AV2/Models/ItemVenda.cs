using Trab_AV2.Model.Models;

namespace Trab_AV2.Controllers
{
    internal class ItemVenda : Venda
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
    }
}