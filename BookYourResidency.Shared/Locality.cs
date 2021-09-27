using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class Locality
    {
        public int LocalityId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
