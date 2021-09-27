using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public interface IOtherServices
    {
        Task<IEnumerable<TenantsType>> GetTenantsTypes();
        Task<IEnumerable<PropertyType>> GetPropertyTypes();
        Task<TenantsType> GetTenantsTypeById(int id);
        Task<PropertyType> GetPropertyTypeById(int id);
        Task<TenantsType> CreateTenantsType(TenantsType type);
        Task<PropertyType> CreatePropertyType(PropertyType type);
        Task<TenantsType> RemoveTenantsType(int id);
        Task<PropertyType> RemovePropertyType(int id);
    }
}
