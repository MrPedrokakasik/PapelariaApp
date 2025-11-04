using Microsoft.EntityFrameworkCore;
using PapelariaApp.Models;
using System;
using System.IO;

namespace PapelariaApp.Data
{
    public class PapelariaDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Venda> Vendas { get; set; } = null!;
        public DbSet<ItemVenda> ItensVenda { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usa um arquivo SQLite dentro de LocalApplicationData\PapelariaApp\papearia.db
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PapelariaApp");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            var dbPath = Path.Combine(folder, "papelaria.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cliente -> Vendas (one-to-many)
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Vendas)
                .WithOne(v => v.Cliente)
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Venda -> Itens (one-to-many)
            modelBuilder.Entity<Venda>()
                .HasMany(v => v.Itens)
                .WithOne(i => i.Venda)
                .HasForeignKey(i => i.VendaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Produto -> ItensVenda (one-to-many)
            modelBuilder.Entity<Produto>()
                .HasMany(p => p.ItensVendidos)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Constraints / defaults
            modelBuilder.Entity<Produto>()
                .Property(p => p.PrecoUnitario)
                .HasDefaultValue(0.0);

            modelBuilder.Entity<Venda>()
                .Property(v => v.DataVenda)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
