using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using StationeryStore.Entities;

namespace StationeryStore.Windows
{
    public partial class OrderManagementWindow : Window
    {
        private readonly StationeryStoreDbContext _context = new StationeryStoreDbContext();

        public OrderManagementWindow()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _context.Orders
                .Join(_context.OrderProducts, o => o.OrderID, op => op.OrderID, (o, op) => new { o, op })
                .Join(_context.Products, op => op.op.ProductArticleNumber, p => p.ProductArticleNumber, (op, p) => new { op.o, p })
                .GroupBy(x => x.o.OrderID)
                .Select(g => new OrderViewEntity
                {
                    OrderID = g.Key,
                    OrderStatus = g.First().o.OrderStatus,
                    OrderDeliveryDate = g.First().o.OrderDeliveryDate,
                    OrderDate = g.First().o.OrderDeliveryDate,
                    TotalAmount = g.Sum(x => x.p.ProductCost),
                    TotalDiscount = g.Sum(x => x.p.ProductDiscountAmount ?? 0),
                    ProductCount = g.Count(),
                    AvailableProductCount = g.Count(x => x.p.ProductQuantityInStock > 0),
                    FullyAvailable = g.All(x => x.p.ProductQuantityInStock >= 3)
                }).ToList();

            OrdersDataGrid.ItemsSource = orders;
        }


        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedIndex == 0)
            {
                OrdersDataGrid.ItemsSource = ((System.Collections.IEnumerable)OrdersDataGrid.ItemsSource)
                    .Cast<OrderViewEntity>().OrderBy(o => o.TotalAmount).ToList();
            }
            else
            {
                OrdersDataGrid.ItemsSource = ((System.Collections.IEnumerable)OrdersDataGrid.ItemsSource)
                    .Cast<OrderViewEntity>().OrderByDescending(o => o.TotalAmount).ToList();
            }
        }




        private void OrdersDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var order = e.Row.Item as OrderViewEntity; 
            if (order != null)
            {
                if (order.ProductCount > order.AvailableProductCount)
                {
                    e.Row.Background = new SolidColorBrush(Color.FromRgb(255, 140, 0)); // #ff8c00
                }
                else if (order.FullyAvailable)
                {
                    e.Row.Background = new SolidColorBrush(Color.FromRgb(32, 178, 170)); // #20b2aa
                }
            }
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
