using System;

namespace ParkAPI
{
    public class Park
    {
        public int ParkId { get; set; }
        public string ManagedBy { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Activities { get; set; }  
        public string Amenities { get; set; }
        public bool ADA { get; set; }
        public string Events { get; set; }
    }
}
