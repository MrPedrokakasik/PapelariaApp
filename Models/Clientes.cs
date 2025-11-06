using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PapelariaApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        // Navegação
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
