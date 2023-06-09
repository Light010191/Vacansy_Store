﻿using Microsoft.EntityFrameworkCore;
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
        private UserService userService;
        public Registr2()
        {
            InitializeComponent();
            userService = new UserService();
        }


        private async void OK_Click(object sender, RoutedEventArgs e)
        {
            //_context.Login = Login.Text;
            //_context.Password = Password.Text;
            //_context.NameCompany = CompanyName.Text;
            //_context.Salt = "a";
            //_context.AboutCompany = AboutCompany.Text;
            //_context.Img = "a";
            await userService.AddNewCompany(new Company
            {
                Login = Login.Text,
                Password = Password.Text,
                NameCompany = CompanyName.Text,
                Salt = "a",
                AboutCompany = AboutCompany.Text,
                Img = "a"
            });

            this.Close();            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
