using System.Linq;
using System.Windows;
using StationeryStore.Entities;

namespace StationeryStore.Windows
{
    public partial class OrderWindow : Window
    {
        private readonly StationeryStoreDbContext _context = new StationeryStoreDbContext();

        public OrderWindow(List<Product> selectedProducts)
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _context.Products.ToList();
            OrderListView.ItemsSource = products;
        }

        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProducts = OrderListView.SelectedItems.Cast<Product>().ToList();
            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один товар для оформления заказа.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }

            decimal totalAmount = selectedProducts.Sum(p => p.ProductCost * (1 - (p.ProductDiscountAmount ?? 0) / 100m));

            MessageBox.Show($"Заказ оформлен на сумму: {totalAmount:C2}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Тут можно добавить логику сохранения заказа в базу данных.
        }
    }
}
