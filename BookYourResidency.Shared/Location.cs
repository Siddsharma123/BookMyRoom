using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class Location
    {
        public int LocationId { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public Locality Locality { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
