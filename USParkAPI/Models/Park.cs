using System;
using System.ComponentModel.DataAnnotations;

namespace USParkAPI {
    public class Park {
        public int ParkId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ManagedBy { get; set; }
        [Required]
        public string Activities { get; set; }
        [Required]
        public string Amenities { get; set; }
        [Required]
        public bool ADA { get; set; }
    }
}

//add:
// description
// links to actual park page
// conditions