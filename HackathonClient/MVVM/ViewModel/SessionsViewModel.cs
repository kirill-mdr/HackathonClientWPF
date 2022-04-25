using HackathonClient.Core;
using HackathonClient.MVVM.View;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HackathonClient.MVVM.ViewModel
{
    class SessionsViewModel : ObservableObject
    {
        private ObservableCollection<SessionData> _sessions;
        private ICollectionView _sessionsView;
        private SessionData _selectedSesseion;
        private bool _isSelected; 
        public RelayCommand Sort { get; set; }
        public RelayCommand EditSession { get; set; }
        
        public bool IsSelected { 
            get 
            { 
                return _isSelected; 
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SessionData> Sessions
        {
            get { return _sessions; }
            set
            {
                _sessions = value;
                OnPropertyChanged();
            }
        }
        public ICollectionView SessionsView
        {
            get { return _sessionsView; }
            set
            {
                _sessionsView = value;
                OnPropertyChanged();
            }
        }

        public SessionData SelectedSesseion
        {
            get { return _selectedSesseion; }
            set
            {
                _selectedSesseion = value;
                IsSelected = true;
                OnPropertyChanged();
            }
        }
        private string _searchText { get; set; }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SessionsView.Filter = (obj) =>
                {
                    if (obj is SessionData ses)
                    {
                        return ses.Id.ToString().Contains(SearchText);
                    }

                    return false;
                };
                SessionsView.Refresh();

            }
        }
        public SessionsViewModel()
        {
            #region Adds
            var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            Sessions = new ObservableCollection<SessionData>
            {
                new SessionData
                {
                    SessionNumber = 4,
                    Organization = "ВВлдавы",
                    Agent = new Agent { Ion = "sfd"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 5,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 3,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 1,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 2,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 6,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 7,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 8,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 9,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    SessionNumber = 10,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
            };
            #endregion

            IsSelected = false;
            SessionsView = CollectionViewSource.GetDefaultView(Sessions);

            #region Commands
            Sort = new RelayCommand(o =>
            {
                if (SessionsView.SortDescriptions.Count > 0)
                {
                    SessionsView.SortDescriptions.Clear();
                }
                else
                {
                    SessionsView.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
                }
            });

            EditSession = new RelayCommand(o =>
            {
                var window = new EditSessionView();
                var vm = new EditSessionViewModel
                {
                    SessionData = SelectedSesseion
                };
                window.DataContext = vm;
                window.ShowDialog();
            });

            #endregion
        }

    }
}
