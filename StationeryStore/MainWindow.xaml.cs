using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StationeryStore.Entities;
using StationeryStore.Windows;

namespace StationeryStore
{
    public partial class MainWindow : Window
    {
        private readonly User _currentUser;
        private readonly bool _isAdmin;
        private List<Product> _selectedProducts = new List<Product>();



        public MainWindow(User? user, bool isAdmin)
        {
            InitializeComponent();
            _currentUser = user;
            _isAdmin = isAdmin;
            LoadProducts();
            DisplayUserInfo();

            if (user == null)
            {
                // Гостевой режим
                isAdmin = false;
                MessageBox.Show("Вы вошли как гость.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LoadProducts()
        {
            using (var context = new StationeryStoreDbContext())
            {
                var products = context.Products.ToList();
                ProductItemsControl.ItemsSource = products;
            }
        }

        private void DisplayUserInfo()
        {
            if (_currentUser != null)
            {
                UserNameTextBlock.Text = $"{_currentUser.UserSurname} {_currentUser.UserName} {_currentUser.UserPatronymic}";
            }
            else
            {
                UserNameTextBlock.Text = "Гость";
            }

            AdminPanelButton.Visibility = _isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void AddToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button)?.DataContext as Product;
            if (product != null)
            {
                _selectedProducts.Add(product);
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow(_selectedProducts);
            orderWindow.ShowDialog();
        }

        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if(_isAdmin)
            {
                ProductManagementWindow managementWindow = new ProductManagementWindow();
                managementWindow.Show(); 

                OrderManagementWindow orderManagementWindow = new OrderManagementWindow();
                orderManagementWindow.Show();  

                LoadProducts();
            }
        }
    }
}
