using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vacancy_Store.Models;
using Vacancy_Store.ViewModels;
using Vacancy_Store.Views.Windows;
using Wpf.Ui.Common.Interfaces;

namespace Vacancy_Store.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : INavigableView<ViewModels.DashboardViewModel>
    {

        public ObservableCollection<Resume> Resumes { get; set; }
        public ViewModels.DashboardViewModel ViewModel
        {
            get;
        }

        public DashboardPage(ViewModels.DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            List<Resume> temp = new List<Resume>()
            {
                new Resume() {Id = 1, VacancyName="Программист", AboutMe=" Рассказ о программисте", LastPlaceOfWork="Слесарь", DesiredSalary="300000", Img="test1"},
                new Resume() {Id = 2, VacancyName="Слесарь", AboutMe=" Рассказ о Слесаря", LastPlaceOfWork="Слесарь", DesiredSalary="50000", Img="test2"},
                new Resume() {Id = 3, VacancyName="Фермер", AboutMe=" Рассказ о Фермере", LastPlaceOfWork="Слесарь", DesiredSalary="40000", Img="test3"}
            };
            Resumes = new ObservableCollection<Resume>(temp);
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var ResumeWindow = new GRUDResumeWindow();
            ResumeWindow.Show();
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            var ResumeWindow = new GRUDResumeWindow();
            ResumeWindow.Show();
        }

    }
}