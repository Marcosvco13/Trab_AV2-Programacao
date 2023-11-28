using Trab_AV2.Model.Models;
using Trab_AV2.Models;

namespace Trab_AV2.VM
{
    public class VendaVM
    {
        public int CodigoVenda { get; set; }
        public string NomeCliente { get; set; }
        public string? CodigoCliente { get; set; }
        public DateTime? DataDaVenda { get; set; }

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
                CodigoCliente = venda.IdUser,
                NomeCliente = db.AspNetUsers.Find(venda.IdUser).Email,
                DataDaVenda = venda.DataVenda,
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
                    CodigoCliente = item.IdUser,
                    DataDaVenda = item.DataVenda,
                    NomeCliente = db.AspNetUsers.Find(item.IdUser).Email,
                    ListaProdutos = listaProdutos
                };
                listaRetorno.Add(vendaVm);
            }
            return listaRetorno;

        }
    }
}

