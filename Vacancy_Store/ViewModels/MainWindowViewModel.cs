using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using Vacancy_Store.Models;
using Vacancy_Store.Services;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace Vacancy_Store.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;

        private UserService userService;

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationItems = new();

        [ObservableProperty]
        private ObservableCollection<INavigationControl> _navigationFooter = new();

        [ObservableProperty]
        private ObservableCollection<MenuItem> _trayMenuItems = new();
                
        private string? nameCompany;
        public string?NameCompany {
            get=>nameCompany;
            set { nameCompany = value; OnPropertyChanged(); }
        }

        private string? aboutCompany;
        public string? AboutCompany
        {
            get => aboutCompany;
            set { aboutCompany = value; OnPropertyChanged(); }
        }

        private string? loginCompany;
        public string? LoginCompany
        {
            get => loginCompany;
            set { loginCompany = value; OnPropertyChanged(); }
        }

        private string? passwordCompany;
        public string? PasswordCompany
        {
            get => passwordCompany;
            set { passwordCompany = value; OnPropertyChanged(); }
        }

        private string? imgCompany;
        public string? ImgCompany
        {
            get => imgCompany;
            set { imgCompany = value; OnPropertyChanged(); }
        }

        private string? firstName;
        public string? FirstName
        {
            get => firstName;
            set { firstName = value; OnPropertyChanged(); }
        }

        private string? lastName;
        public string? LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(); }
        }

        private string? patronymic;
        public string? Patronymic
        {
            get => patronymic;
            set { patronymic = value; OnPropertyChanged(); }
        }

        private string? phoneNumber;
        public string? PhoneNumber
        {
            get => phoneNumber;
            set { phoneNumber = value; OnPropertyChanged(); }
        }

        private string? email;
        public string? Email
        {
            get => email;
            set { email = value; OnPropertyChanged(); }
        }
        private string? age;
        public string? Age
        {
            get => age;
            set { age = value; OnPropertyChanged(); }
        }
        private string? loginJobApplicant;
        public string? LoginJobApplicant
        {
            get => loginJobApplicant;
            set { loginJobApplicant = value; OnPropertyChanged(); }
        }

        private string? passwordJobApplicant;
        public string? PasswordJobApplicant
        {
            get => passwordJobApplicant;
            set { passwordJobApplicant = value; OnPropertyChanged(); }
        }

        private string? vacancyNameForResume;
        public string? VacancyNameForResume
        {
            get => vacancyNameForResume;
            set { vacancyNameForResume = value; OnPropertyChanged(); }
        }

        private string? aboutMe;
        public string? AboutMe
        {
            get => aboutMe;
            set { aboutMe = value; OnPropertyChanged(); }
        }
        private string? lastPlaceOfWork;
        public string? LastPlaceOfWork
        {
            get => lastPlaceOfWork;
            set { lastPlaceOfWork = value; OnPropertyChanged(); }
        }
        private string? desiredSalary;
        public string? DesiredSalary
        {
            get => desiredSalary;
            set { desiredSalary = value; OnPropertyChanged(); }
        }

        private string? imgVacancys;
        public string? ImgVacancys
        {
            get => imgVacancys;
            set { imgVacancys = value; OnPropertyChanged(); }
        }
        private int myId;
        public int MyId
        {
            get => myId;
            set { myId = value; OnPropertyChanged(); }
        }

        private string? nameVacancy;
        public string? NameVacancy
        {
            get => nameVacancy;
            set { nameVacancy = value; OnPropertyChanged(); }
        }
        private string? salary;
        public string? Salary
        {
            get => salary;
            set { salary = value; OnPropertyChanged(); }
        }

        private string? requiredWorkExperience;
        public string? RequiredWorkExperience
        {
            get => requiredWorkExperience;
            set { requiredWorkExperience = value; OnPropertyChanged(); }
        }
        private string? aboutVacansy;
        public string? AboutVacansy
        {
            get => aboutVacansy;
            set { aboutVacansy = value; OnPropertyChanged(); }
        }        
        
        public IAsyncRelayCommand GetAllVacanciesCommand { get ; }
        public IAsyncRelayCommand AddNewCompanyCommand { get; }
        public IAsyncRelayCommand AddNewEmployeeCommand { get; }
        public IAsyncRelayCommand AddNewResumeCommand { get; }
        public IAsyncRelayCommand AddNewVacancyCommand { get; }
        public IAsyncRelayCommand GetAllResumesCommand { get; }

        public MainWindowViewModel(INavigationService navigationService)
        {
            if (!_isInitialized)
                InitializeViewModel();
            GetAllVacanciesCommand = new AsyncRelayCommand(x => userService.GetAllVacancies());
            GetAllResumesCommand = new AsyncRelayCommand(x => userService.GetAllResumes());
            AddNewCompanyCommand = new AsyncRelayCommand(x => userService.AddNewCompany((
                new Company
                {
                    Login = LoginCompany,
                    NameCompany = NameCompany,
                    Password = PasswordCompany,
                    AboutCompany = AboutCompany,
                    Img = ImgCompany,
                    Salt = "1"
                })));
            AddNewEmployeeCommand = new AsyncRelayCommand(x => userService.AddNewEmployee((
                new JobApplicant
                {
                    Login = LoginJobApplicant,
                    FirstName = FirstName,
                    LastName = LastName,
                    Patronymic = Patronymic,
                    Password = PasswordJobApplicant,
                    Age = Age,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Salt = "1"
                })));
            AddNewResumeCommand = new AsyncRelayCommand(x => userService.AddNewResume(new Resume
            {
                VacancyName = VacancyNameForResume,
                AboutMe = AboutMe,
                DesiredSalary = DesiredSalary,
                Img = ImgVacancys,
                LastPlaceOfWork = LastPlaceOfWork
            }, MyId));
            AddNewVacancyCommand = new AsyncRelayCommand(x => userService.AddNewVacancy(new Vacancy
            {
                NameVacancy = NameVacancy,
                Salary = Salary,
                RequiredWorkExperience = RequiredWorkExperience,
                AboutVacansy = AboutVacansy
            }, MyId));
        }

        private void InitializeViewModel()
        {
            ApplicationTitle = "Vacancy Store";

            NavigationItems = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Home",
                    PageTag = "dashboard",
                    Icon = SymbolRegular.Home24,
                    PageType = typeof(Views.Pages.DashboardPage)
                },
                new NavigationItem()
                {
                    Content = "Авторизация",
                    PageTag = "autorization",
                    Icon = SymbolRegular.Home24,
                    PageType = typeof(Views.Pages.AuthorizationPage)
                },
                new NavigationItem()
                {
                    Content = "Вакансии",
                    PageTag = "data",
                    Icon = SymbolRegular.DataHistogram24,
                    PageType = typeof(Views.Pages.DataPage)
                },
                new NavigationItem()
                {
                    Content = "Резюме",
                    PageTag = "resume",
                    Icon = SymbolRegular.DeveloperBoard24,
                    PageType = typeof(Views.Pages.ResumePage)
                }
            };

            NavigationFooter = new ObservableCollection<INavigationControl>
            {
                new NavigationItem()
                {
                    Content = "Settings",
                    PageTag = "settings",
                    Icon = SymbolRegular.Settings24,
                    PageType = typeof(Views.Pages.SettingsPage)
                }
            };

            TrayMenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Header = "Home",
                    Tag = "tray_home"
                }
            };

            _isInitialized = true;
        }
    }
}
