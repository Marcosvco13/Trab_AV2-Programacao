using Trab_AV2.Data;
using Trab_AV2.Model.Models;

namespace Trab_AV2.VM
{
    public class ProdutoVM
    {
        public int IDProduto { get; set; }
        public string? Usuario {  get; set; }
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
                    join Autentica in db.AspNetUsers on Produto.IdUser equals Autentica.Id
                    select new ProdutoVM
                    {
                        IDProduto = Produto.Id,
                        Usuario = Autentica.Email,
                        NomeProduto = Produto.NmProduto,
                        Quantidade = Produto.Qtd,
                        ValorProduto = Produto.Valor,
                        Disponivel = SimNao.Descricao,
                    }).ToList();
        }

        public static ProdutoVM SelecionaProduto(int id)
        {
            var db = new PADARIA_AV2Context();
            var produto = db.Produtos.Find(id);
            return new ProdutoVM()
            {
                IDProduto = produto.Id,
                Usuario = db.AspNetUsers.Find(produto.IdUser).Email,
                NomeProduto = produto.NmProduto,
                Quantidade = produto.Qtd,
                ValorProduto = produto.Valor,
                Disponivel = db.SimNaos.Find(produto.Disp).Descricao,
            };
        }
    }
}
