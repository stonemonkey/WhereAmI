using System;
using System.Runtime.Serialization;

namespace WhereAmI.Core.Model
{
    [DataContract]
    public class Waypoint
    {
        private int _id;
        [DataMember]
        public int Id{ get; set; }

        [DataMember]
        public GPSPosition Position { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }



    }
}
