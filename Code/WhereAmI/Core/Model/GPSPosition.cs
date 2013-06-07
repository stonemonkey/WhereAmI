using System.Runtime.Serialization;

namespace WhereAmI.Core.Model
{
    [DataContract]
    public class GPSPosition
    {
        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public double Altitude { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}",
                                 Latitude.ToString("0.00"),
                                 Longitude.ToString("0.00"));
        }
    }
}