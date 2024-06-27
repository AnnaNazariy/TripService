using System.Collections.Generic;

namespace BlazorApp1.Models
{
    public class City
    {
        public string CountryCode { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Hotel> Hotels { get; set; }
    }
}
