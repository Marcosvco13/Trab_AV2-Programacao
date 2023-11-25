using System.ComponentModel.DataAnnotations;
using Trab_AV2.Data;
using Trab_AV2.Model.Models;

namespace Trab_AV2.VM
{
    public class ProdutoVM
    {
        [Display(Name = "Cód. Produto")]
        public int IDProduto { get; set; }
        [Display(Name = "Usuário Cadastrante")]
        public string? Usuario {  get; set; }
        [Display(Name = "Produto")]
        public string? NomeProduto { get; set; }
        public string? Quantidade { get; set; }
        [Display(Name = "Valor do Produto")]
        public decimal? ValorProduto { get; set; }
        [Display(Name = "Disponível")]
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
