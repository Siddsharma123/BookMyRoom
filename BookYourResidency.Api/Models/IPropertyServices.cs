using BookYourResidency.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public interface IPropertyServices
    {
        public Task<IEnumerable<Property>> GetPropertiesByUserId(int id);
        public Task<IEnumerable<Property>> GetAllProperties();
        public Task<Property> GetPropertyById(int id);
        public Task<Property> CreateProperty(Property property);
        public Task<Property> DeleteProperty(int id);
        public Task<Property> UpdateProperty(Property property);
    }
}
