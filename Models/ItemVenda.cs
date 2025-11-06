using System.ComponentModel.DataAnnotations.Schema;

namespace PapelariaApp.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }

        // FK Venda
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }

        // FK Produto
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public int Quantidade { get; set; }

        public double PrecoUnitario { get; set; }

        [NotMapped]
        public double Subtotal => Quantidade * PrecoUnitario;
    }
}
