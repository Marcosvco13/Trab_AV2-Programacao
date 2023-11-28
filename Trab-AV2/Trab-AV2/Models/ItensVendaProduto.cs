using System.Collections.Generic;
using System.Linq;
using Trab_AV2.Model.Models;

namespace Trab_AV2.Models
{
    public class ItensVendaProduto
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorVenda { get; set; }

        public static List<ItensVendaProduto> ListaProdutosVenda(int codVenda)
        {
            using (var db = new PADARIA_AV2Context())
            {
                var listaRetorno = new List<ItensVendaProduto>();

                var listaItens = db.ItemVenda.Where(x => x.VendaId == codVenda).ToList();

                foreach (var item in listaItens)
                {
                    var produto = db.Produtos.Find(item.ItvCodigoProduto);
                    if (produto != null)
                    {
                        listaRetorno.Add(new ItensVendaProduto
                        {
                            VendaId = codVenda,
                            ProdutoId = item.ItvCodigoProduto,
                            Produto = produto.ProDescricao,
                            Quantidade = item.ItvQuantidade,
                            ValorVenda = item.ItvValorItem
                        });
                    }
                }

                return listaRetorno;
            }
        }
    }
}
