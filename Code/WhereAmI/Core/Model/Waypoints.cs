using System;
using System.Collections.Generic;

namespace WhereAmI.Core.Model
{
    public class Waypoints : List<Waypoint>
    {
        public Waypoints()
        {
        
        }

        public void PopulateWithMockData()
        {
            this.Add(new Waypoint()
            {
                Description = "WOWZAPP Windows 8 hackathon",
                Id = -1,
                Position = new GPSPosition() { Altitude = 1, Latitude = 14f, Longitude = 15f },
                Title = "The HUB location",
                CreatedDate = DateTime.Now
            });

            this.Add(new Waypoint()
            {
                Description = "Where I left my car",
                Id = -2,
                Position = new GPSPosition() { Altitude = 1, Latitude = 10f, Longitude = 15f },
                Title = "Car location",
                CreatedDate = DateTime.Now
            });

            this.Add(new Waypoint()
            {
                Description = "Bucharest hotel location",
                Id = -3,
                Position = new GPSPosition() { Altitude = 1, Latitude = 1, Longitude = 1 },
                Title = "Hotel location",
                CreatedDate = DateTime.Now

            });
        }
        

        public List<Waypoint> Search(string query)
        {
            if (query.Length < 2)
            {
                return new List<Waypoint>();
            }

            query = query.Remove(0, 1);
            query = query.Remove(query.Length - 1, 1);

            if (query.Length == 2)
            {
                return new List<Waypoint>(this);
            }

            return base.FindAll(x => x.Description.Contains(query) || x.Title.Contains(query));
        }
    }
}