using System.ComponentModel.DataAnnotations;

namespace PapelariaApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string Senha { get; set; } = string.Empty;

        public string? Nome { get; set; }
    }
}
