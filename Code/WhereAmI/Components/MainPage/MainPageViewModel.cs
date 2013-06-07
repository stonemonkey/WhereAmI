
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Caliburn.Micro;
using WhereAmI.Components.GpsSelectionPage;
using WhereAmI.Components.ManagePage;
using WhereAmI.Components.Navigation;
using WhereAmI.Components.PopupMenu;
using WhereAmI.Components.WayPointsSelectionPage;
using WhereAmI.Core.Model;
using WhereAmI.Core.Repository;
using WhereAmI.Core.Sensors.GPS;
using WhereAmI.Services;
using WhereAmI.Core.Model;
using System;
using Windows.UI.Popups;

namespace WhereAmI.Components.MainPage
{
    public class MainPageViewModel : PageViewModelBase
    {
        private bool _isAddLocationsPopup;
        private MenuBarViewModel _addLocationsPopup;
        private ObservableCollection<Waypoint> _waypointList;
        private double _currentLocationLatitude;
        private double _currentLocationLongitude;

        public bool IsAddLocationsPopupVisible
        {
            get
            {
                return _isAddLocationsPopup;
            }

            set
            {
                _isAddLocationsPopup = value;
                NotifyOfPropertyChange(() => IsAddLocationsPopupVisible);
            }
        }

        public MenuBarViewModel AddLocationsPopup
        {
            get
            {
                return _addLocationsPopup;
            }

            set
            {
                _addLocationsPopup = value;
                NotifyOfPropertyChange(() => AddLocationsPopup);
            }
        }

        public double CurrentLocationLatitude
        {
            get { return _currentLocationLatitude; }
            set
            {
                _currentLocationLatitude = value;
                NotifyOfPropertyChange(() => CurrentLocationLatitude);
            }
        }

        public double CurrentLocationLongitude
        {
            get { return _currentLocationLongitude; }
            set
            {
                _currentLocationLongitude = value;
                NotifyOfPropertyChange(() => CurrentLocationLongitude);
            }
        }

        public ObservableCollection<Waypoint> WaypointList
        {
            get
            {
                if (_waypointList == null)
                    _waypointList = new ObservableCollection<Waypoint>();
                return _waypointList;
            }
            set
            {
                _waypointList = value;
                NotifyOfPropertyChange(() => WaypointList);
            }
        }

        public MainPageViewModel(IUiService uiService, MenuBarViewModel menuBarViewModel)
            : base(uiService)
        {
            AddLocationsPopup = menuBarViewModel;

            IsAddLocationsPopupVisible = false;
            LoadAddLocationsPopupMenuItems();

            DisplayName = "Where Am I";

            WaypointsRepository repository = WaypointsRepositoryFactory.Create();
            Waypoints waypoints = new Waypoints();
            waypoints.Add(CreateWaypoint());

            Waypoints savedWaypoints = null;
            Task.Run(() => savedWaypoints = repository.LoadAsync().Result).Wait();

            //TODO: Delete!!! 
            if (savedWaypoints.Count == 0)
            {
                savedWaypoints.PopulateWithMockData();
                repository.SaveAsync(savedWaypoints);
            }

            WaypointList = new ObservableCollection<Waypoint>(savedWaypoints.ToArray());
            var location = GetCurrentLocation();
            if (location == null)
            {
                MessageDialog message = new MessageDialog("GPSLocationNotResolved");
                Task.Run(() => message.ShowAsync()).Wait();
            }
            else
            {
                CurrentLocationLatitude = location.Latitude;
                CurrentLocationLongitude = location.Longitude;
            }
        }

        public void AddLocation()
        {
            IsAddLocationsPopupVisible = true;
        }

        public void Manage()
        {
            UiService.Navigation.NavigateToViewModel<ManagePageViewModel>();
        }

        private void LoadAddLocationsPopupMenuItems()
        {
            AddLocationsPopup.Menus.Add(new Menu("GPS coordinates", ShowGpsSelection));
            AddLocationsPopup.Menus.Add(new Menu("Location", ShowWayPointsSelection));
        }

        public void ShowWayPointsSelection()
        {
            UiService.Navigation.NavigateToViewModel<WayPointsSelectionPageViewModel>();
        }

        public void ShowGpsSelection()
        {
            UiService.Navigation.NavigateToViewModel<GpsSelectionPageViewModel>();
        }

        public void Navigate()
        {
            Waypoint parameter = new Waypoint()
            {
                CreatedDate = DateTime.Now,
                Description = "bla bla",
                Id = -4,
                Position = new GPSPosition() { Latitude = 41.1, Longitude = 42.1 }
            };

            UiService.Navigation.NavigateToViewModel<NavigatePageViewModel>(parameter);
        }

        private Waypoint CreateWaypoint()
        {
            return new Waypoint()
            {
                Description = "bla bla bla",
                Position = new GPSPosition()
                {
                    Altitude = 123.1,
                    Longitude = 1,
                    Latitude = 1
                },
                CreatedDate = DateTime.Now
            };
        }


        private GPSPosition GetCurrentLocation()
        {
            //IGPSPositionProvider gpsPositionProvider = new GPSPositionProvider(new GPSPositionProviderConfiguration(), new GeopositionToGPSPositionConverter());
            GPSPositionProvider gpsPositionProvider = GPSPositionProvider.CurrentInstance;
            GPSPosition position = null;

            try
            {
                //Task<GPSPosition> location = null;
                GPSPosition location = null;
                //Task.Run(() => location = gpsPositionProvider.GetCurrentPositionAsync()).Wait();
                location = gpsPositionProvider.GetCurrentPositionAsync();
                position = location;
            }
            catch (COMException comException)
            {
                // The GPS location was not resolved.             
            }

            return position;
        }
    }
}
