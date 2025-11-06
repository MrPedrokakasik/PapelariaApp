using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PapelariaApp.Models;
using PapelariaApp.ViewModels;
using PapelariaApp.ViewModels;

namespace PapelariaApp.Views
{
    public partial class VendasView : Window
    {
        private readonly VendaViewModel vm = new();

        public VendasView()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void RegistrarVenda_Click(object sender, RoutedEventArgs e)
        {
            if (vm.ProdutoSelecionado == null || vm.Quantidade <= 0)
            {
                MessageBox.Show("Selecione um produto e informe a quantidade.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var item = new ItemVenda
            {
                ProdutoId = vm.ProdutoSelecionado.Id,
                Produto = vm.ProdutoSelecionado,
                Quantidade = vm.Quantidade,
                PrecoUnitario = vm.PrecoUnitario
            };

            var novaVenda = new Venda
            {
                Id = vm.Vendas.Count + 1,
                ClienteId = 1,
                DataVenda = DateTime.Now,
                ValorTotal = item.Quantidade * item.PrecoUnitario,
                Itens = new List<ItemVenda> { item }
            };

            vm.Add(novaVenda);
        }

        private void ExcluirVenda_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Venda venda)
                vm.Delete(venda.Id);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // opcional: lógica para seleção de venda
        }
    }
}
