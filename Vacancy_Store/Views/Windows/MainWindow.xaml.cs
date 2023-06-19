using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Vacancy_Store.Data;
using Vacancy_Store.Models;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace Vacancy_Store.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INavigationWindow
    {
        public ViewModels.MainWindowViewModel ViewModel
        {
            get;
        }
        //
        private readonly AppDbContext _context;
        private readonly List<JobApplicant> jobApplicants = new List<JobApplicant>();
        public MainWindow(ViewModels.MainWindowViewModel viewModel,
            IPageService pageService,
            INavigationService navigationService,
            AppDbContext context)//
        {
            ViewModel = viewModel;
            DataContext = this;
            _context = context;
            InitializeComponent();
            SetPageService(pageService);
            jobApplicants.AddRange(_context.JobApplicants.ToArray());

            navigationService.SetNavigationControl(RootNavigation);
        }

        #region INavigationWindow methods

        public Frame GetFrame()
            => RootFrame;

        public INavigation GetNavigation()
            => RootNavigation;

        public bool Navigate(Type pageType)
            => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService)
            => RootNavigation.PageService = pageService;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        #endregion INavigationWindow methods

        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.
            Application.Current.Shutdown();
        }

        private void AutoSuggestBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //
                Users_ListView.ItemsSource = jobApplicants.Where(item => item.FirstName == AutoSuggest.Text || item.FirstName.Contains(AutoSuggest.Text)).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void RootFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}