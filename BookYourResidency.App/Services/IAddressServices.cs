using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.App.Services
{
    public interface IAddressServices
    {
        public Task<IEnumerable<Country>> GetCountries();
        public Task<IEnumerable<State>> GetStates(int CountryId);
        public Task<IEnumerable<City>> GetCities(int StateId);
        public Task<IEnumerable<Locality>> GetLocalities(int CityId);
        public Task<Country> GetCountry(int id);
        public Task<State> GetState(int id);
        public Task<City> GetCity(int id);
        public Task<Locality> GetLocality(int id);
    }
}
