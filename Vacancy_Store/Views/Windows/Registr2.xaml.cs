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
using Vacancy_Store.Models;
using Vacancy_Store.Services;

namespace Vacancy_Store.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr2 : Window
    {
        public Company _context;
        public Registr2()
        {
            InitializeComponent();
            _context = new Company();
        }


        private async void OK_Click(object sender, RoutedEventArgs e)
        {
            _context.Login = Login.Text;
            _context.Password = Password.Text;
            _context.NameCompany = CompanyName.Text;
            _context.Salt = "a";
            _context.AboutCompany = AboutCompany.Text;
            _context.Img = "a";
            UserService userService = new UserService();
            await userService.AddNewCompany(_context);

            this.Close();
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
