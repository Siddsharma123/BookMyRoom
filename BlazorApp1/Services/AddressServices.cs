using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly HttpClient httpClient;
        public AddressServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await httpClient.GetFromJsonAsync<Country[]>("api/country");
        }
        public async Task<IEnumerable<City>> GetCities(int StateId)
        {
            return await httpClient.GetFromJsonAsync<City[]>($"api/city/{StateId}");
        }
        public async Task<City> GetCity(int id)
        {
            return await httpClient.GetFromJsonAsync<City>($"api/city/GetCity/{id}");
        }

        public async Task<Country> GetCountry(int id)
        {
            return await httpClient.GetFromJsonAsync<Country>($"api/country/{id}");
        }
        public async Task<IEnumerable<Locality>> GetLocalities(int CityId)
        {
            return await httpClient.GetFromJsonAsync<Locality[]>($"api/Locality/{CityId}");
        }
        public async Task<Locality> GetLocality(int id)
        {
            return await httpClient.GetFromJsonAsync<Locality>($"api/Locality/getLocality/{id}");
        }
        public async Task<State> GetState(int id)
        {
            return await httpClient.GetFromJsonAsync<State>($"api/state/getState/{id}");
        }
        public async Task<IEnumerable<State>> GetStates(int CountryId)
        {
            return await httpClient.GetFromJsonAsync<State[]>($"api/state/{CountryId}");
        }
    }
}
