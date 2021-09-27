using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BookYourResidency.Web.Services
{
    public class PropertyServices : IPropertyServices
    {
        private readonly HttpClient httpClient;
        public PropertyServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> CreateProperty(Property property)
        {
            return await httpClient.PostAsJsonAsync<Property>("api/property/create", property);
        }
        public Task<Property> DeleteProperty(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Property>> GetAllProperties()
        {
            return await httpClient.GetFromJsonAsync<Property[]>("api/property");
        }
        public async Task<IEnumerable<Property>> GetPropertiesByUserId(int id)
        {
            return await httpClient.GetFromJsonAsync<Property[]>($"api/property/ByUserId/{id}");
        }
        public async Task<Property> GetPropertyById(int id)
        {
            return await httpClient.GetFromJsonAsync<Property>($"api/property/ById/{id}");
        }
    }
}
