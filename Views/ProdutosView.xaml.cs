using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using PapelariaApp.Data;
using PapelariaApp.Models;
using PapelariaApp.Shared;

namespace PapelariaApp.Views
{
    public partial class ProdutosView : Window, INotifyPropertyChanged
    {
        private Produto _novoProduto = new Produto();
        public Produto NovoProduto
        {
            get => _novoProduto;
            set { _novoProduto = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Produto> Produtos { get; set; }

        public ProdutosView()
        {
            InitializeComponent();

            // Produtos locais exibem a mesma coleção compartilhada do AppData
            Produtos = AppData.Produtos;

            // caso queira iniciar com alguns dados de teste (opcional)
            // if (Produtos.Count == 0) Produtos.Add(new Produto { Nome = "Exemplo", Categoria = "Geral", Preco = 1.0m, QuantidadeEstoque = 10 });

            DataContext = this;
        }

        private void Adicionar_Click(object sender, RoutedEventArgs e)
        {
            // validação simples
            if (string.IsNullOrWhiteSpace(NovoProduto.Nome))
            {
                MessageBox.Show("Informe o nome do produto.", "Atenção", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // clona os dados para não manter referência ao mesmo objeto ligado ao formulário
            var produto = new Produto
            {
                Nome = NovoProduto.Nome,
                Categoria = NovoProduto.Categoria,
                Preco = NovoProduto.Preco,
                Quantidade = NovoProduto.Quantidade
            };

            // adiciona na coleção compartilhada (AppData) que é a fonte do DataGrid e do ComboBox de vendas
            Produtos.Add(produto);

            // limpa o formulário
            NovoProduto = new Produto();
            // DataContext permanece this; OnPropertyChanged já atualiza bindings
        }

        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            var produto = ((FrameworkElement)sender).DataContext as Produto;
            if (produto != null && Produtos.Contains(produto))
            {
                Produtos.Remove(produto);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
