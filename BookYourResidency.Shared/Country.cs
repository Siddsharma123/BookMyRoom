using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
