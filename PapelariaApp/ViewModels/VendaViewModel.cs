using PapelariaApp.Data;
using PapelariaApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PapelariaApp.ViewModels
{
    public class VendaViewModel : BaseViewModel
    {
        public ObservableCollection<Venda> Vendas { get; } = new ObservableCollection<Venda>();

        public Venda NovaVenda { get; set; } = new Venda();

        public VendaViewModel() => Load();

        public void Load()
        {
            Vendas.Clear();
            using var db = new PapelariaDbContext();
            var list = db.Vendas
                         .OrderByDescending(v => v.DataVenda)
                         .ToList();
            foreach (var v in list) Vendas.Add(v);
        }

        public void Add(Venda v)
        {
            using var db = new PapelariaDbContext();
            db.Vendas.Add(v);
            db.SaveChanges();
            Load();
        }

        public void Update(Venda v)
        {
            using var db = new PapelariaDbContext();
            db.Vendas.Update(v);
            db.SaveChanges();
            Load();
        }

        public void Delete(int id)
        {
            using var db = new PapelariaDbContext();
            var item = db.Vendas.Find(id);
            if (item != null)
            {
                db.Vendas.Remove(item);
                db.SaveChanges();
            }
            Load();
        }
    }
}
