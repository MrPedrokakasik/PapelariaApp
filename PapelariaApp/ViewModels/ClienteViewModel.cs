using PapelariaApp.Data;
using PapelariaApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PapelariaApp.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        public ObservableCollection<Cliente> Clientes { get; } = new ObservableCollection<Cliente>();

        public ClienteViewModel() => Load();

        public void Load()
        {
            Clientes.Clear();
            using var db = new PapelariaDbContext();
            foreach (var c in db.Clientes.OrderBy(c => c.Nome)) Clientes.Add(c);
        }

        public void Add(Cliente c)
        {
            using var db = new PapelariaDbContext();
            db.Clientes.Add(c);
            db.SaveChanges();
            Load();
        }

        public void Update(Cliente c)
        {
            using var db = new PapelariaDbContext();
            db.Clientes.Update(c);
            db.SaveChanges();
            Load();
        }

        public void Delete(int id)
        {
            using var db = new PapelariaDbContext();
            var item = db.Clientes.Find(id);
            if (item != null)
            {
                db.Clientes.Remove(item);
                db.SaveChanges();
            }
            Load();
        }
    }
}
