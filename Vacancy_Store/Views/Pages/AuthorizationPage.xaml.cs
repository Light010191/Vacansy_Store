using System.Windows;
using Vacancy_Store.Models;
using Vacancy_Store.Services;
using Vacancy_Store.ViewModels;
using Vacancy_Store.Views.Windows;
using Wpf.Ui.Common.Interfaces;

namespace Vacancy_Store.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class AuthorizationPage : INavigableView<ViewModels.AuthorizationViewModel>
    {
        private UserService userService;
        public ViewModels.AuthorizationViewModel ViewModel
        {
            get;
           
        }

        public AuthorizationPage(ViewModels.AuthorizationViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
            userService = new UserService();
        }

        private void Reg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var sel = new Select();
            sel.Show();

        }  
        private async void Ok_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(Log.Text != "" && Pass.Text != "")

            {
                if (Pred.IsChecked == true)
                {
                   var company= await userService.GetCompany(Log.Text, Pass.Text);
                    if (company != null)
                    {
                        MessageBox.Show("Добро пожаловать " + company.NameCompany);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                }
                if (hanter.IsChecked == true)
                {
                   var employee= await userService.GetEmployee(Log.Text, Pass.Text);
                    if (employee!=null)
                    {
                        MessageBox.Show("Добро пожаловать " + employee.FirstName);
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                    
                }
                if (hanter.IsChecked == false && Pred.IsChecked == false)
                {
                    MessageBox.Show("Выберете категорию");
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль");
            }
        }
    }
}