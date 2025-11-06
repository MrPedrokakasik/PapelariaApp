using System.Collections.ObjectModel;
using System.Windows;

namespace PapelariaApp.Views
{
    public partial class ClientesView : Window
    {
        public ObservableCollection<Cliente> Clientes { get; set; }
        public Cliente NovoCliente { get; set; }

        public ClientesView()
        {
            InitializeComponent();
            Clientes = new ObservableCollection<Cliente>();
            NovoCliente = new Cliente();

            DataContext = this;
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NovoCliente.Nome) &&
                !string.IsNullOrWhiteSpace(NovoCliente.Email) &&
                !string.IsNullOrWhiteSpace(NovoCliente.Telefone))
            {
                Clientes.Add(new Cliente
                {
                    Nome = NovoCliente.Nome,
                    Email = NovoCliente.Email,
                    Telefone = NovoCliente.Telefone
                });

                NovoCliente.Nome = "";
                NovoCliente.Email = "";
                NovoCliente.Telefone = "";

                DataContext = null;
                DataContext = this;
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as FrameworkElement)?.DataContext is Cliente cliente)
            {
                Clientes.Remove(cliente);
            }
        }
    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
