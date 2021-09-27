using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Locality> Localities { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
