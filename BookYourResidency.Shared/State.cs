using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
