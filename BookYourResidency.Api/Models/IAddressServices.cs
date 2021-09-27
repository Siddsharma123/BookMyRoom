using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public interface IAddressServices
    {
        Task<IEnumerable<Country>> GetCountries();
        Task<IEnumerable<State>> GetStates(int CountryId);
        Task<IEnumerable<City>> GetCities(int StateId);
        Task<IEnumerable<Locality>> GetLocalities(int CityId);
        Task<Country> GetCountry(int id);
        Task<State> GetState(int id);
        Task<City> GetCity(int id);
        Task<Locality> GetLocality(int id);
        Task<Country> CreateCountry(Country country);
        Task<State> CreateState(State state);
        Task<City> CreateCity(City city);
        Task<Locality> CreateLocality(Locality locality);
        Task<Country> DeleteCountryAsync(int CountryId);
        Task<State> DeleteStateAsync(int StateId);
        Task<City> DeleteCityAsync(int CityId);
        Task<Locality> DeleteLocalityAsync(int LocalityId);
        bool CountryExists(Country country);
        bool StateExists(State state);
        bool CityExists(City city);
        bool LocalityExists(Locality locality);
    }
}
