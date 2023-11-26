using Trab_AV2.Model.Models;

namespace Trab_AV2.Models
{
    public class ItensVendaProduto
    {
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal? Quantidade { get; set; }
        public decimal? ValorVenda { get; set; }

        public ItensVendaProduto() { 
        }

        public static List<ItensVendaProduto> ListaProdutosVenda(int codVenda)
        {
            var db = new PADARIA_AV2Context();
            var listaRetorno = new List<ItensVendaProduto>();
            var listaItens = db.ItensVenda.Where(x => x.ItvCodigoVenda == codVenda).ToList();
            foreach ( var item in listaItens )
            {
                listaRetorno.Add(new ItensVendaProduto
                {
                    CodigoVenda = codVenda,
                    CodigoProduto = item.ItvCodigoProduto,
                    NomeProduto = db.Produtos.Find(item.ItvCodigoProduto)!.NmProduto,
                    Quantidade = item.ItvQuantidade,
                    ValorVenda = item.ItvValorItem,
                });
            }
            return listaRetorno;
        }
    }
}
