using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PapelariaApp.Models;
using PapelariaApp.Data;
using PapelariaApp.Shared;

namespace PapelariaApp.ViewModels
{
    public class VendaViewModel : INotifyPropertyChanged
    {
        // Puxa os produtos cadastrados dinamicamente
        public ObservableCollection<Produto> Produtos => AppData.Produtos;

        private Produto? produtoSelecionado;
        public Produto? ProdutoSelecionado
        {
            get => produtoSelecionado;
            set
            {
                produtoSelecionado = value;
                PrecoUnitario = value?.Preco ?? 0;
                OnPropertyChanged();
            }
        }

        private int quantidade;
        public int Quantidade
        {
            get => quantidade;
            set { quantidade = value; OnPropertyChanged(); }
        }

        private double precoUnitario;
        public double PrecoUnitario
        {
            get => precoUnitario;
            set { precoUnitario = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Venda> Vendas { get; set; } = new();

        public void Add(Venda venda) => Vendas.Add(venda);

        public void Delete(int id)
        {
            var venda = Vendas.FirstOrDefault(v => v.Id == id);
            if (venda != null)
                Vendas.Remove(venda);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
