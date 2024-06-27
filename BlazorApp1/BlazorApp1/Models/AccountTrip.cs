using System.Collections.Generic;

namespace BlazorApp1.Models
{
    public class AccountTrip
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int Luggage { get; set; }
    }
}
