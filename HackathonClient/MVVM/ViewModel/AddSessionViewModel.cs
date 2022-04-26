using HackathonClient.Core;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HackathonClient.MVVM.ViewModel
{
    class AddSessionViewModel : ObservableObject
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

        #region Commands
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(obj =>
                    {
                        Window w = obj as Window;
                        if (w != null)
                        {
                            w.DialogResult = true;
                            w.Close();
                            
                        }
                    }));
            }
        }
        #endregion
        public AddSessionViewModel()
        {

        }
    }


}
