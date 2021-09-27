using System;
using System.Collections.Generic;
using System.Text;

namespace BookYourResidency.Shared
{
    public class Property
    {
        public Property()
        {
            Images = new HashSet<Image>();
            Location = new Location();
            PropertyType = new PropertyType();
            TenantsId = new TenantsType();
        }
        public int PropertyId { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Message { get; set; }
        public virtual Location Location { get; set; }
        public Availability Availability { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public bool ForRent { get; set; }
        public int? RentRate { get; set; }
        public bool ForSale { get; set; }
        public int? SaleRate { get; set; }
        public bool Negotiable { get; set; }
        public ICollection<Image> Images { get; set; }
        public virtual TenantsType TenantsId { get; set; }
    }
    public enum Availability
    {
        Available,
        Booked
    }
}
