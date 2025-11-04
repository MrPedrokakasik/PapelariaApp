using System.Windows;
using PapelariaApp.Models;
using PapelariaApp.ViewModels;

namespace PapelariaApp.Views
{
    public partial class ClientesView : Window
    {
        private readonly ClienteViewModel vm = new();

        public ClientesView()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            // Cria um novo cliente (você pode ajustar os valores conforme necessário)
            var novoCliente = new Cliente();
            vm.Add(novoCliente);
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is Cliente cliente)
                vm.Delete(cliente.Id);
        }
    }
}
