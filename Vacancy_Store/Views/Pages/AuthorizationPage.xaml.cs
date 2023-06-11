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
    }
}