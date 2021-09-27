using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookYourResidency.Web.Services
{
    public class OtherServices : IOtherServices
    {
        private readonly HttpClient httpClient;
        public OtherServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<TenantsType> GetTenantsTypeById(int id)
        {
            return await httpClient.GetFromJsonAsync<TenantsType>($"api/type/getTenantsTypeById/{id}");
        }

        public async Task<IEnumerable<TenantsType>> GetTenantsTypes()
        {
            return await httpClient.GetFromJsonAsync<TenantsType[]>("api/type/getTenantsTypes");
        }

        public async Task<PropertyType> GetPropertyTypeById(int id)
        {

            return await httpClient.GetFromJsonAsync<PropertyType>($"api/type/getPropertyTypeById/{id}");
        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypes()
        {
            return await httpClient.GetFromJsonAsync<PropertyType[]>("api/type/getPropertyTypes");
        }
    }
}
