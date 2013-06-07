using System;
using System.Collections.Generic;
using Caliburn.Micro;
using WhereAmI.Core.Model;
using WhereAmI.Results;
using WhereAmI.Services;

namespace WhereAmI.Components.GpsSelectionPage
{
	public class GpsSelectionPageViewModel : PageViewModelBase
	{
	    private string _title;
        private double _altitude;
	    private double _latitude;
	    private double _longitude;
	    private string _description;

	    private string _altitudeValidationMessage;
	    private string _latitudeValidationMessage;
	    private string _longitudeValidationMessage;

	    public double Altitude
        {
            get
            {
                return _altitude;
            }

            set
            {
                if (!ValidateAltitude(value))
                    return;

                _altitude = value;
                NotifyOfPropertyChange(() => Altitude);
            }
        }
        public string AltitudeValidationMessage
        {
            get
            {
                return _altitudeValidationMessage;
            }

            set
            {
                _altitudeValidationMessage = value;
                NotifyOfPropertyChange(() => AltitudeValidationMessage);
            }
        }

	    public double Latitude
	    {
	        get 
            {
                return _latitude;
            } 

            set
            {
                if (!ValidateLatitude(value))
                    return;

                _latitude = value; 
                NotifyOfPropertyChange(() => Latitude);
            }
	    }
        public string LatitudeValidationMessage
        {
            get
            {
                return _latitudeValidationMessage;
            }

            set
            {
                _latitudeValidationMessage = value;
                NotifyOfPropertyChange(() => LatitudeValidationMessage);
            }
        }

        public double Longitude
        {
            get
            {
                return _longitude;
            }

            set
            {
                if (!ValidateLongitude(value))
                    return;

                _longitude = value;
                NotifyOfPropertyChange(() => Longitude);
            }
        }
        public string LongitudeValidationMessage
        {
            get
            {
                return _longitudeValidationMessage;
            }

            set
            {
                _longitudeValidationMessage = value;
                NotifyOfPropertyChange(() => LongitudeValidationMessage);
            }
        }
	    
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        protected double DefaultLatitude { get { return 19.123456; }}
        protected double DefaultLongitude { get { return 45.654321; }}

        public GpsSelectionPageViewModel(IUiService uiService)
			: base(uiService)
        {
            Latitude = DefaultLatitude;
            Longitude = DefaultLongitude;

            DisplayName = "Location details";
        }

        public Waypoint Parameter
        {
            set
            {
                if (ReferenceEquals(null, value))
                    return;
                
                Title = value.Title;
                Description = value.Description;
                Altitude = value.Position.Altitude;
                Latitude = value.Position.Latitude;
                Longitude = value.Position.Longitude;
                NotifyOfPropertyChange(() => CanSave);
            }
        }

	    public bool CanSave
        {
            get 
            { 
                return IsValid(AltitudeValidationMessage) && 
                       IsValid(LongitudeValidationMessage) &&
                       IsValid(LatitudeValidationMessage); 
            }
        }

        public IEnumerable<IResult> Save()
        {
            var waypoint = new Waypoint
            {
                Title = this.Title,
                CreatedDate = DateTime.Now,
                Description = this.Description,
                Position = new GPSPosition { Latitude = this.Latitude, Longitude = this.Longitude, },
            };
            var waypoints = new Waypoints ();
            waypoints.Add(waypoint);

            yield return new SaveResult(waypoints);

            GoBack();
        }

        private bool ValidateAltitude(double value)
        {
            if (value > 8848)
                AltitudeValidationMessage = "You are no more on Erth!";
            else if (value < 10971)
                AltitudeValidationMessage = "Comme on you are in the cernter of Earth!";
            else
                AltitudeValidationMessage = null;

            NotifyOfPropertyChange(() => CanSave);

            return IsValid(AltitudeValidationMessage);
        }

	    private bool ValidateLatitude(double value)
        {
            if (value > 90)
                LatitudeValidationMessage = "To big!";
            else if (value < -90)
                LatitudeValidationMessage = "To small!";
            // and so on ...
            else
                LatitudeValidationMessage = null;
            
            NotifyOfPropertyChange(() => CanSave);
            
            return IsValid(LatitudeValidationMessage);
        }

        private bool ValidateLongitude(double value)
        {
            if (value > 180)
                LongitudeValidationMessage = "To big!";
            else if (value < -180)
                LongitudeValidationMessage = "To small!";
            // and so on ...
            else
                LongitudeValidationMessage = null;

            NotifyOfPropertyChange(() => CanSave);

            return IsValid(LongitudeValidationMessage);
        }

        private static bool IsValid(string message)
        {
            return string.IsNullOrEmpty(message);
        }
	}
}
