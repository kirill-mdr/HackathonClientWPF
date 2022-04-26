using HackathonClient.Core;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonClient.MVVM.ViewModel
{
    class DetailsSessionViewModel : ObservableObject
    {
        private SessionData _sessionData;
        public SessionData SessionData
        {
            get
            {
                return _sessionData;
            }
            set
            {
                _sessionData = value;
                OnPropertyChanged();
            }
        }
    }
}
