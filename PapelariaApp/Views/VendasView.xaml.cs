using System.Windows;
using System.Windows.Controls;
using PapelariaApp.Models;
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

            var novaVenda = new Venda
            {
                ClienteId = 1, 
                DataVenda = DateTime.Now,
                ValorTotal = 100.0, 
                Itens = new List<ItemVenda>() 
            };

            if (novaVenda.ClienteId > 0 && novaVenda.ValorTotal > 0 && novaVenda.Itens != null && novaVenda.Itens.Count > 0)
                vm.Add(novaVenda);
            else
                MessageBox.Show("Preencha todos os campos corretamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ExcluirVenda_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Venda venda)
                vm.Delete(venda.Id);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
