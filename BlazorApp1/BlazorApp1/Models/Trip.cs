using System;
using System.Collections.Generic;

namespace BlazorApp1.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public DateTime BookDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? CancelDate { get; set; }

        public ICollection<AccountTrip> AccountsTrips { get; set; }
    }
}
