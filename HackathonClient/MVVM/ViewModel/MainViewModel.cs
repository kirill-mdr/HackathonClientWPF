using HackathonClient.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonClient.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        //views
        public HomeViewModel HomeVM { get; set; }
        public SessionsViewModel SessionsVM { get; set; }
        public ReportViewModel ReportVM { get; set; }
        //commands
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand SessionsViewCommand { get; set; }
        public RelayCommand ReportViewCommand { get; set; }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            SessionsVM = new SessionsViewModel();
            ReportVM = new ReportViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            SessionsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SessionsVM;
            });
            ReportViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReportVM;
            });

        }
    }
}
