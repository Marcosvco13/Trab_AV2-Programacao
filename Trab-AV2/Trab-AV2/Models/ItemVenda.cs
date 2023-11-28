using System.ComponentModel.DataAnnotations.Schema;

namespace Trab_AV2.Model.Models
{
    public class ItemVenda
    {
        public int Id { get; set; } // ou o nome correto da propriedade de identificação

        public int VendaId { get; set; } // Chave estrangeira para a venda associada
        public int ProdutoId { get; set; } // Chave estrangeira para o produto associado

        [ForeignKey("VendaId")]
        public virtual Venda Venda { get; set; } // Referência à venda associada

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; } // Referência ao produto associado

        // Outras propriedades dos itens da venda, se houver
    }
}
