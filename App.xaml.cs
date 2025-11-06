using System.Windows;
using PapelariaApp.Data;
using Microsoft.EntityFrameworkCore;
using PapelariaApp.Models;
using PapelariaApp.Views;

namespace PapelariaApp
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            using (var db = new PapelariaDbContext())
            {
                // Garante que o arquivo e o schema existam
                db.Database.EnsureCreated();

                // Se não houver nenhum usuário, cria um padrão para testes
                if (!db.Usuarios.Any())
                {
                    db.Usuarios.Add(new Usuario
                    {
                        Login = "admin",
                        Senha = "admin",
                        Nome = "Administrador"
                    });
                    db.SaveChanges();
                }
            }

            var login = new LoginView();
            login.Show();
        }
    }
}
