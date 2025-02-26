using System.Linq;
using System.Windows;
using StationeryStore.Entities;

namespace StationeryStore.Windows
{
    public partial class ProductManagementWindow : Window
    {
        private readonly StationeryStoreDbContext _context = new StationeryStoreDbContext();

        public ProductManagementWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            ProductsDataGrid.ItemsSource = _context.Products.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newProductWindow = new ProductEditorWindow();
            if (newProductWindow.ShowDialog() == true)
            {
                _context.Products.Add(newProductWindow.Product);
                _context.SaveChanges();
                LoadProducts();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                var editWindow = new ProductEditorWindow(selectedProduct);
                if (editWindow.ShowDialog() == true)
                {
                    _context.SaveChanges();
                    LoadProducts();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                _context.Products.Remove(selectedProduct);
                _context.SaveChanges();
                LoadProducts();
            }
        }
    }
}
