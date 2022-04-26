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
                        return ses.SessionNumber.ToString().Contains(SearchText);
                    }

                    return false;
                };
                SessionsView.Refresh();

            }
        }

        #region Commands
        private RelayCommand _sortCommand;
        private RelayCommand _editSessionCommand;
        private RelayCommand _detailsSessionCommand;
        private RelayCommand _addSessionCommand;
        private RelayCommand _reportSessionCommand;

        public RelayCommand ReportSessionCommand
        {
            get
            {
                return _reportSessionCommand ??
                    (_reportSessionCommand = new RelayCommand(obj =>
                    {
                        var window = new ReportSessionView();
                        var vm = new ReportSessionViewModel();
                        if (SelectedSesseion != null)
                        {
                            vm = new ReportSessionViewModel
                            {
                                StartNumber = SelectedSesseion.SessionNumber
                            };
                        }
                        window.DataContext = vm;
                        if (window.ShowDialog() == true)
                        {
                            //Отправка данных на сервер
                        }
                    }));
            }
        }
        public RelayCommand AddSessionCommand
        {
            get
            {
                return _addSessionCommand ??
                    (_addSessionCommand = new RelayCommand(obj =>
                    {
                        SessionData temp = new SessionData
                        {
                            ObjectID = new string[4],
                            TrackDetectors = new float?[9],
                            OnlineDetectors = new float?[4]
                        };
                        var window = new AddSessionView();
                        var vm = new AddSessionViewModel
                        {
                            SessionData = temp
                        };
                        window.DataContext = vm;
                        if (window.ShowDialog() == true)
                        {
                            //Отправка данных на сервер
                            Sessions.Add(vm.SessionData);
                            SelectedSesseion = Sessions.Last();
                            
                        }
                    }));
            }
        }
        public RelayCommand DetailsSessionCommand
        {
            get
            {
                return _detailsSessionCommand ??
                (_detailsSessionCommand = new RelayCommand(obj =>
                {
                    SessionData sess = obj as SessionData;
                    if (sess != null)
                    {
                        var window = new DetailsSessionView();
                        var vm = new DetailsSessionViewModel
                        {
                            SessionData = SelectedSesseion
                        };
                        window.DataContext = vm;
                        window.ShowDialog();
                    }
                },
            (obj) => obj != null));
            }
        }
        public RelayCommand EditSessionCommand
        {
            get
            {
                return _editSessionCommand ??
                (_editSessionCommand = new RelayCommand(obj =>
                {
                    SessionData sess = obj as SessionData;
                    if (sess != null)
                    {
                        var window = new EditSessionView();
                        var vm = new EditSessionViewModel
                        {
                            SessionData = SelectedSesseion
                        };
                        window.DataContext = vm;
                        if (window.ShowDialog() == true)
                        {
                            //Отправка объекта на сервер
                        }
                    }
                },
            (obj) => obj != null));
            }
        }
        public RelayCommand SortCommand
        {
            get
            {
                return _sortCommand ??
                    (_sortCommand = new RelayCommand(obj =>
                    {
                        if (SessionsView.SortDescriptions.Count > 0)
                        {
                            SessionsView.SortDescriptions.Clear();
                        }
                        else
                        {
                            SessionsView.SortDescriptions.Add(new SortDescription("SessionNumber", ListSortDirection.Descending));
                        }
                    }));
            }
        }


        #endregion
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
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]

                },
                new SessionData
                {
                    SessionNumber = 5,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 3,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 1,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 2,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 6,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 7,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 8,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 9,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
                new SessionData
                {
                    SessionNumber = 10,
                    Organization = "fasdasf",
                    Agent = new Agent { Ion = "Ion"},
                    Timing = new SessionTiming {
                    StartTime = date1,
                    EndTime = DateTime.Now
                    },
                    ObjectID = new string[4],
                    TrackDetectors = new float?[9],
                    OnlineDetectors = new float?[4]
                },
            };
            #endregion

            //IsSelected = false;
            SessionsView = CollectionViewSource.GetDefaultView(Sessions);

        }

    }
}
