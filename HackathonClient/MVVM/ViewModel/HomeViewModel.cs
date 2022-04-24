using HackathonClient.Core;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonClient.MVVM.ViewModel
{
    class HomeViewModel : ObservableObject
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
        public RelayCommand Test { get; set; }
        public RelayCommand Close { get; set; }
        public HomeViewModel()
        {
            Test = new RelayCommand(o =>
            {             
                CurrentView = new HomeViewModel();
            });
            Close = new RelayCommand(o =>
            {
                CurrentView = null;
            });
        }
        
    }
}
