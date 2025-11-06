using PapelariaApp.Models;
using System.Collections.ObjectModel;

namespace PapelariaApp.Shared
{
    public static class AppData
    {
        public static ObservableCollection<Produto> Produtos { get; set; } = new();

    }
}
