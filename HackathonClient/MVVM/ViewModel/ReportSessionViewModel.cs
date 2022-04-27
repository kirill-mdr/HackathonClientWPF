using HackathonClient.Core;
using Newtonsoft.Json;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                        if (StartNumber != null && Email != null)
                        {
                            if (EndNumber == null)
                            {
                                EndNumber = StartNumber;
                            }
                            ReportHelper result = new ReportHelper
                            {
                                From = (int)StartNumber,
                                To = (int)EndNumber,
                                Email = Email
                            };
                            SendAsync(result);
                            Window w = obj as Window;
                            if (w != null)
                            {
                                w.DialogResult = true;
                                w.Close();

                            }
                        }

                    }));
            }
        }
        #endregion
        public ReportSessionViewModel()
        {

        }
        public async Task SendAsync(ReportHelper result)
        {

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json");
                await client.PostAsync("https://a6337-c1ef.k.d-f.pw/Report", content);
            }
        }
    }
}
