using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vacancy_Store.Models;
using Wpf.Ui.Common.Interfaces;

namespace Vacancy_Store.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataPage : INavigableView<ViewModels.DataViewModel>
    {
        public ObservableCollection<Vacancy> Vacansys { get; set; }
        public ViewModels.DataViewModel ViewModel
        {
            get;
        }

        public DataPage(ViewModels.DataViewModel viewModel)
        {
            ViewModel = viewModel;
            List<Vacancy> temp = new List<Vacancy>()
            {
                new Vacancy() {Id = 1, NameVacancy = "Програмист", RequiredWorkExperience = "3", Salary = "500000 $", AboutVacansy = "Тестовый текст"}
            };
            Vacansys = new ObservableCollection<Vacancy>(temp);

            InitializeComponent();
        }
    }
}
