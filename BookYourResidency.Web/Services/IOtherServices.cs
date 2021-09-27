using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Web.Services
{
    public interface IOtherServices
    {
        public Task<IEnumerable<TenantsType>> GetTenantsTypes();
        public Task<IEnumerable<PropertyType>> GetPropertyTypes();
        public Task<TenantsType> GetTenantsTypeById(int id);
        public Task<PropertyType> GetPropertyTypeById(int id);
    }
}
