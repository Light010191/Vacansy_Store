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

        public ResumePage(ViewModels.ResumeViewModel viewModel)
        {
            ViewModel = viewModel;

            InitializeComponent();
        }
    }
}
