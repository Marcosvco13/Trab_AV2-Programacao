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

        public List<ItensVendaProduto> ListaProdutos { get; set; }

        public VendaVM()
        {

        }

        public static VendaVM SelecionarVenda(int codVenda)
        {
            var db = new PADARIA_AV2Context();
            var venda = db.Venda.Find(codVenda);

            var listaProdutos = new List<ItensVendaProduto>();
            listaProdutos = ItensVendaProduto.ListaProdutosVenda(codVenda);
            return new VendaVM
            {
                CodigoVenda = venda.Id,
                CodigoProduto = venda.IdProduto,
                CodigoCliente = db.AspNetUsers.Find(venda.IdUser).Email,
                DataDaVenda = venda.DataVenda,
                ValorDaVenda = venda.ValorVenda,
                ListaProdutos = listaProdutos
            };
        }


        public static List<VendaVM> ListarTodasVendas()
        {
            var db = new PADARIA_AV2Context();
            var venda = db.Venda.ToList();
            var listaRetorno = new List<VendaVM>();
            foreach(var item  in venda)
            {
                var listaProdutos = new List<ItensVendaProduto>();
                listaProdutos = ItensVendaProduto.ListaProdutosVenda(item.Id);
                var vendaVm = new VendaVM
                {
                    CodigoVenda = item.Id,
                    CodigoProduto = item.IdProduto,
                    CodigoCliente = item.IdUser,
                    DataDaVenda = item.DataVenda,
                    ValorDaVenda = item.ValorVenda,
                    ListaProdutos = listaProdutos
                };
                listaRetorno.Add(vendaVm);
            }
            return listaRetorno;

        }
    }
}

