using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PapelariaApp.Shared;
using PapelariaApp.Data;


namespace PapelariaApp.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string? Categoria { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public double PrecoUnitario { get; set; }

        [NotMapped]
        public double Subtotal => Quantidade * PrecoUnitario;

        // Navegação
        public ICollection<ItemVenda> ItensVendidos { get; set; } = new List<ItemVenda>();
        public double Preco { get; internal set; }

        internal static void Add(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
