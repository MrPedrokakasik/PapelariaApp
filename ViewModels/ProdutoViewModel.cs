using PapelariaApp.Data;
using PapelariaApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace PapelariaApp.ViewModels
{
    public class ProdutoViewModel : BaseViewModel
    {
        public ObservableCollection<Produto> Produtos { get; } = new ObservableCollection<Produto>();

        public ProdutoViewModel()
        {
            Load();
        }

        public void Load()
        {
            Produtos.Clear();
            using var db = new PapelariaDbContext();
            var list = db.Produtos.OrderBy(p => p.Nome).ToList();
            foreach (var p in list) Produtos.Add(p);
        }

        public void Add(Produto p)
        {
            using var db = new PapelariaDbContext();
            db.Produtos.Add(p);
            db.SaveChanges();
            Load();
        }

        public void Update(Produto p)
        {
            using var db = new PapelariaDbContext();
            db.Produtos.Update(p);
            db.SaveChanges();
            Load();
        }

        public void Delete(int id)
        {
            using var db = new PapelariaDbContext();
            var item = db.Produtos.Find(id);
            if (item != null)
            {
                db.Produtos.Remove(item);
                db.SaveChanges();
            }
            Load();
        }
    }
}
