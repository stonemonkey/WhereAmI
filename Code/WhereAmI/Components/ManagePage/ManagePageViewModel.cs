using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Caliburn.Micro;
using WhereAmI.Common;
using WhereAmI.Components.GpsSelectionPage;
using WhereAmI.Core.Model;
using WhereAmI.Core.Repository;
using WhereAmI.Services;

namespace WhereAmI.Components.ManagePage
{
    public class ManagePageViewModel : PageViewModelBase
    {
        private ObservableCollection<Waypoint> _waypointList;
        private Waypoint _selectedWaypointItem;
        private readonly WaypointsRepository _repository = WaypointsRepositoryFactory.Create();
        private bool _isSelectedItem = false;

        public ManagePageViewModel(IUiService uiService)
            : base(uiService)
        {
            DisplayName = "Where Am I";

            Waypoints savedWaypoints = null;
            Task.Run(() => savedWaypoints = _repository.LoadAsync().Result).Wait();
            WaypointList = new ObservableCollection<Waypoint>(savedWaypoints.ToArray());
            
            EditSelectedItemCommand = new DelegateCommand(OnEditSelectedItem);
            DeleteSelectedItemCommand = new DelegateCommand(OnDeleteSelectedItem);
        }

        #region Public Properties

        public Waypoint SelectedWaypointItem
        {
            get { return _selectedWaypointItem; }
            set
            {
                if (value != null)
                {
                    _selectedWaypointItem = value;
                    IsSelectedItem = true;
                    NotifyOfPropertyChange(() => SelectedWaypointItem);
                }
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

        public bool IsSelectedItem
        {
            get { return _isSelectedItem; }
            set
            {
                _isSelectedItem = value;
                NotifyOfPropertyChange(() => IsSelectedItem);
            }
        }
        #endregion

        #region Commands

        public ICommand DeleteSelectedItemCommand { get; set; }
        public ICommand EditSelectedItemCommand { get; set; }

        #endregion

      
        private void OnDeleteSelectedItem(object obj)
        {
            WaypointList.Remove(SelectedWaypointItem);
            var availableWaipoints = new Waypoints();
            availableWaipoints.AddRange(WaypointList);
            Task.Run(() => _repository.SaveAsync(availableWaipoints));
            NotifyOfPropertyChange(() => WaypointList);

        }

        private void OnEditSelectedItem(object obj)
        {
            SelectedWaypointItem.CreatedDate = DateTime.Now;
            UiService.Navigation.NavigateToViewModel<GpsSelectionPageViewModel>(SelectedWaypointItem);

        }
    }
}
