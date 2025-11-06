using System.Windows;
using PapelariaApp.Views;

namespace PapelariaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AbrirClientes(object sender, RoutedEventArgs e)
        {
            new ClientesView().ShowDialog();
        }

        private void AbrirProdutos(object sender, RoutedEventArgs e)
        {
            new ProdutosView().ShowDialog();
        }

        private void AbrirVendas(object sender, RoutedEventArgs e)
        {
            new VendasView().ShowDialog();
        }

        private void FecharApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
