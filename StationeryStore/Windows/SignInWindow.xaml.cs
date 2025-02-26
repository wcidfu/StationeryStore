using Microsoft.EntityFrameworkCore;
using StationeryStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StationeryStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {

        private readonly StationeryStoreDbContext _context = new StationeryStoreDbContext();

        public SignInWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            var user = _context.Users.FirstOrDefault(u => u.UserLogin == login && u.UserPassword == password);

            if (user != null)
            {
                bool isAdmin = user.UserRole == 2; // id Admin
                MainWindow mainWindow = new MainWindow(user, isAdmin);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignInGuestButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(null,false);
            mainWindow.Show();
            this.Close();
        }
    }
}
    