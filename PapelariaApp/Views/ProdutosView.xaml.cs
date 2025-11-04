using System.Windows;
using PapelariaApp.Models;
using PapelariaApp.ViewModels;

namespace PapelariaApp.Views
{
    public partial class ProdutosView : Window
    {
        private readonly ProdutoViewModel vm = new();

        public ProdutosView()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            // Crie um novo Produto e adicione usando o método Add do ViewModel
            var novoProduto = new Produto();
            vm.Add(novoProduto);
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is Produto produto)
                vm.Delete(produto.Id);
        }
    }
}
