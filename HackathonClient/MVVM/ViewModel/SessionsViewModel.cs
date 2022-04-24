using HackathonClient.Core;
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
        public RelayCommand Sort { get; set; }

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
                    Id = 4,
                    Organization = "ВВлдавы",
                    Agent = new Agent { Ion = "sfd"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 5,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 3,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 1,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 2,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 6,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 7,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 8,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 9,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
                new SessionData
                {
                    Id = 10,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    }
                },
            };
            #endregion

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
            #endregion
        }

    }
}
