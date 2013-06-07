using System;
using WhereAmI.Core.Model;
using WhereAmI.Services;

namespace WhereAmI.Components.Navigation
{
    public class NavigatePageViewModel : PageViewModelBase
    {
        public NavigatePageViewModel(IUiService uiService)
            : base(uiService)
        {
            DisplayName = "Navigate to ...";

            CurrentLocation = new Waypoint()
                {
                    CreatedDate = DateTime.Now,
                    Description = "bla bla",
                    Id = -4,
                    Position = new GPSPosition() { Latitude = 41, Longitude = 42 }
                };
        }

        public Waypoint CurrentLocation { get; set; }

        public Waypoint DestinationLocation { get; set; }

        public Waypoint Parameter
        {
            get
            {
                return DestinationLocation;
            }
            set
            {
                DestinationLocation = value;
               // DisplayName = "Navigation to " + DestinationLocation.Title;
            }
        }

        
    }
}
