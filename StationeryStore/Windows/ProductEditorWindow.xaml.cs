using System;
using System.Windows;
using StationeryStore.Entities;

namespace StationeryStore.Windows
{
    public partial class ProductEditorWindow : Window
    {
        public Product Product { get; private set; }

        public ProductEditorWindow(Product product = null)
        {
            InitializeComponent();
            Product = product ?? new Product();

            if (product != null)
            {
                NameTextBox.Text = product.ProductName;
                DescriptionTextBox.Text = product.ProductDescription;
                ManufacturerTextBox.Text = product.ProductManufacturer;
                DiscountTextBox.Text = product.ProductDiscountAmount.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Product.ProductName = NameTextBox.Text;
            Product.ProductDescription = DescriptionTextBox.Text;
            Product.ProductManufacturer = ManufacturerTextBox.Text;
            Product.ProductDiscountAmount = decimal.TryParse(DiscountTextBox.Text, out var discount) ? (int?)discount : null;


            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
