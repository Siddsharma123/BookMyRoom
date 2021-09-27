using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class User
    {
        public User()
        {
            Properties = new HashSet<Property>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
