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
        public ViewModels.AuthorizationViewModel ViewModel
        {
            get;
        }

        public AuthorizationPage(ViewModels.AuthorizationViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }

        private void Reg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var sel = new Select();
            sel.Show();

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }
    }
}