using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookYourResidency.Web.Services
{
    public interface IPropertyServices
    {
        public Task<IEnumerable<Property>> GetPropertiesByUserId(int id);
        public Task<IEnumerable<Property>> GetAllProperties();
        public Task<Property> GetPropertyById(int id);
        public Task<HttpResponseMessage> CreateProperty(Property property);
        public Task<Property> DeleteProperty(int id);
        //public Task<IEnumerable<Property>> GetPropertiesByFilter(FilterModel filter); 
    }
}
