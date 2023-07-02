using Vacancy_Store.Helpers;
using Vacancy_Store.Models;
using Vacancy_Store.Services;
using Vacancy_Store.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace Vacancy_Store.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class ResumePage : INavigableView<ViewModels.ResumeViewModel>
    {
        public ViewModels.ResumeViewModel ViewModel
        {
            get;
        }
        
        public  ResumePage(ResumeViewModel viewModel)
        {
           
           
            ViewModel = viewModel;

            InitializeComponent();
        }
        
    }
}
