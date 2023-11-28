using Trab_AV2.Model.Models;
using Trab_AV2.Models;

namespace Trab_AV2.VM
{
    public class VendaVM
    {
        public int CodigoVenda { get; set; }
        public int? CodigoProduto { get; set; }

        public string? CodigoCliente { get; set; }

        public DateTime? DataDaVenda { get; set; }

        public decimal? ValorDaVenda { get; set; }

        public List<ItemVenda> ListaProdutos { get; set; }
        public VendaVM()
        {

        }

        public static VendaVM SelecionarVenda(int codVenda)
        {
            var db = new PADARIA_AV2Context();
            var venda = db.Venda.Find(codVenda);
            var vendaVm = new VendaVM();

            vendaVm.CodigoVenda = venda.Id;
            vendaVm.CodigoProduto = venda.IdProduto;
            vendaVm.CodigoCliente = db.AspNetUsers.Find(venda.IdUser).Email;
            vendaVm.DataDaVenda = venda.DataVenda;
            vendaVm.ValorDaVenda = venda.ValorVenda;
            return vendaVm;
        }


        public static List<VendaVM> ListarTodasVendas()
        {
            var db = new PADARIA_AV2Context();
            return (from venda in db.Venda
                    select new VendaVM
                    {
                        CodigoVenda = venda.Id,
                        CodigoProduto = venda.IdProduto,
                        CodigoCliente = venda.IdUser,
                        DataDaVenda = venda.DataVenda,
                        ValorDaVenda = venda.ValorVenda,
                    }).ToList();
        }
    }
}

