using PapelariaApp.Data;
using System.Windows;

namespace PapelariaApp.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            txtUsuario.Text = "admin";
            txtSenha.Password = "admin";
            this.Title += " — Usuário: admin | Senha: admin";
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsuario.Text.Trim();
            var password = txtSenha.Password;

            using var db = new PapelariaDbContext();
            var usuario = db.Usuarios.SingleOrDefault(u => u.Login == username);

            if (usuario != null && usuario.Senha == password)
            {
                new MainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.");
            }
        }
    }
}   