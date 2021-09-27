using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.App.Models
{
    public class PropertyInputModel
    {
        public PropertyInputModel()
        {
            Images = new List<Image>();
        }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int LocalityId { get; set; }
        public int PropertyTypeId { get; set; }
        public int TenantsTypeId { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public Availability Availability { get; set; }
        public bool ForRent { get; set; }
        public int? RentRate { get; set; }
        public bool ForSale { get; set; }
        public int? SaleRate { get; set; }
        public bool Negotiable { get; set; }
        public List<Image> Images { get; set; }
    }
}
