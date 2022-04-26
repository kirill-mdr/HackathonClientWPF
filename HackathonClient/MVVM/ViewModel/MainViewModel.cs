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
        public SessionsViewModel SessionsVM { get; set; }

        //commands
        #region Commands
        private RelayCommand _sessionsViewCommand;
        public RelayCommand SessionsViewCommand
        {
            get
            {
                return _sessionsViewCommand ??
                    (_sessionsViewCommand = new RelayCommand(obj =>
                    {
                        CurrentView = SessionsVM;
                    }));
            }
        }



        #endregion


        public MainViewModel()
        {
            SessionsVM = new SessionsViewModel();

            CurrentView = SessionsVM;

        }
    }
}
