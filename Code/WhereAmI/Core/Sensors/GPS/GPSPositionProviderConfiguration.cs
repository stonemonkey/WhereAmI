using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereAmI.Core.Sensors.GPS
{
    public class GPSPositionProviderConfiguration
    {
        /// <summary>
        /// Define the time interval when a new GPS location is retrived.
        /// </summary>
        public TimeSpan TimeInterval { get; set; }

        /// <summary>
        /// Define the min. distance when a GPS location is retrived.
        /// The distance is in meters.
        /// </summary>
        public int Distance { get; set; }
    }
}
