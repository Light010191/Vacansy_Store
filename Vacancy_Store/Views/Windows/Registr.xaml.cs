using Microsoft.EntityFrameworkCore;
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
    public partial class Registr : Window
    {
       private UserService userService;
       
        public Registr()
        {
            InitializeComponent();
            userService = new UserService();
        }


        private async void OK_Click(object sender, RoutedEventArgs e)
        {
            //_context.Login = Login.Text;
            //_context.Password = Password.Text;
            //_context.FirstName = FirstName.Text;
            //_context.LastName = LastName.Text;
            //_context.Patronymic = Patronymic.Text;
            //_context.Email = Email.Text;
            //_context.PhoneNumber = PhoneNumber.Text;
            //_context.Age = Age.Text;
            //_context.Salt = "a";
            

            await userService.AddNewEmployee(new JobApplicant
            {
                Login = Login.Text,
                Password = Password.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Patronymic = Patronymic.Text,
                Email = Email.Text,
                PhoneNumber = PhoneNumber.Text,
                Age = Age.Text,
                Salt = "a"
            });
            this.Close();  
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
