using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using Vacancy_Store.Models;
using Wpf.Ui.Common.Interfaces;

namespace Vacancy_Store.ViewModels
{
    public partial class ResumeViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        //[ObservableProperty]
        //private IEnumerable<DataColor> _colors;

        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }

        public void OnNavigatedFrom()
        {
        }

        private void InitializeViewModel()
        {
            
            _isInitialized = true;
        }
    }
}
