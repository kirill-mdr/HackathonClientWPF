using HackathonClient.Core;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonClient.MVVM.ViewModel
{
    class EditSessionViewModel : ObservableObject
    {
        private SessionData _sessionData;
        public SessionData SessionData { 
            get 
            {
                return _sessionData; 
            } set 
            { 
                _sessionData = value;
                OnPropertyChanged();
            } 
        }
        public EditSessionViewModel()
        {
            SessionData = new SessionData();
            SessionData.ObjectID = new string[] { "dsf", "dfd" };
        }
    }
}
