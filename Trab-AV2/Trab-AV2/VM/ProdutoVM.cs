using Trab_AV2.Model.Models;

namespace Trab_AV2.VM
{
    public class ProdutoVM
    {
        public int IDProduto { get; set; }
        public string? IDUsuario {  get; set; }
        public string? NomeProduto { get; set; }
        public string? Quantidade { get; set; }
        public decimal? ValorProduto { get; set; }
        public string? Disponivel { get; set; }

        public static List<ProdutoVM> ListarProdutos()
        {
            var db = new PADARIA_AV2Context();
            return (from Produto in db.Produtos
                    join SimNao in db.SimNaos on Produto.Disp
                    equals SimNao.Id
                    select new ProdutoVM
                    {
                        IDProduto = Produto.Id,
                        IDUsuario = Produto.IdUser,
                        NomeProduto = Produto.NmProduto,
                        Quantidade = Produto.Qtd,
                        ValorProduto = Produto.Valor,
                        Disponivel = SimNao.Descricao,
                    }).ToList();
        }
    }
}
