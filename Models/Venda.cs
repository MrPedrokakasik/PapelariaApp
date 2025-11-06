using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PapelariaApp.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public DateTime DataVenda { get; set; } = DateTime.Now;

        // FK Cliente
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Total calculado
        public double ValorTotal { get; set; }

        // Itens
        public ICollection<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    }
}
