using HackathonClient.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonClient.MVVM.ViewModel
{
    class ReportSessionViewModel : ObservableObject
    {
        private int? _startNumber;
        private int? _endNumber;
        private string? _email;
        public int? StartNumber
        {
            get { return _startNumber; }
            set
            {
                _startNumber = value;
                OnPropertyChanged();
            }
        }
        public int? EndNumber
        {
            get { return _endNumber; }
            set
            {
                _endNumber = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        #region Commands
        private RelayCommand _sendReportCommand;
        public RelayCommand SendReportCommand
        {
            get
            {
                return _sendReportCommand ??
                    (_sendReportCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }
        #endregion
        public ReportSessionViewModel()
        {

        }
    }
}
