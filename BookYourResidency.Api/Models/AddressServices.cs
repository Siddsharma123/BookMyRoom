using BookYourResidency.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public class AddressServices : IAddressServices
    {
        private readonly BookYourResidencyDbContext _context;
        public AddressServices(BookYourResidencyDbContext context)
        {
            this._context = context;
        }
        public async Task<City> CreateCity(City city)
        {
            var state = await _context.States.FindAsync(city.StateId);
            if (state == null)
            {
                return null;
            }
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<Country> CreateCountry(Country country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
            return country;
        }
        public async Task<Locality> CreateLocality(Locality locality)
        {
            var City = await _context.Cities.FindAsync(locality.CityId);
            if (City == null)
            {
                return null;
            }
            await _context.AddAsync<Locality>(locality);
            await _context.SaveChangesAsync();
            return locality;
        }
        public async Task<State> CreateState(State state)
        {
            var Country = await _context.Countries.FindAsync(state.CountryId);
            if (Country == null)
            {
                return null;
            }
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
            return state;
        }
        public async Task<City> DeleteCityAsync(int CityId)
        {
            var City = await _context.Cities.FindAsync(CityId);
            if (City != null)
            {
                _context.Cities.Remove(City);
                await _context.SaveChangesAsync();
                return City;
            }
            else
            {
                return null;
            }
        }
        public async Task<Country> DeleteCountryAsync(int CountryId)
        {
            var Country = await _context.Countries.FindAsync(CountryId);
            //var ct = await _context.Countries.FirstOrDefaultAsync(e => e.CountryId == CountryId);
            if (Country != null)
            {
                _context.Countries.Remove(Country);
                await _context.SaveChangesAsync();
                return Country;
            }
            else
            {
                return null;
            }
        }
        public async Task<Locality> DeleteLocalityAsync(int LocalityId)
        {
            var Locality = await _context.Localities.FindAsync(LocalityId);
            if (Locality != null)
            {
                _context.Localities.Remove(Locality);
                await _context.SaveChangesAsync();
                return Locality;
            }
            else
            {
                return null;
            }
        }
        public async Task<State> DeleteStateAsync(int StateId)
        {
            var State = await _context.States.FindAsync(StateId);
            if (State != null)
            {
                _context.States.Remove(State);
                await _context.SaveChangesAsync();
                return State;
            }
            else
            {
                return State;
            }
        }
        public async Task<IEnumerable<City>> GetCities(int StateId)
        {
            return await _context.Cities.Where(e => e.StateId == StateId).ToListAsync();
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }
        public async Task<IEnumerable<Locality>> GetLocalities(int CityId)
        {
            return await _context.Localities.Where(e => e.CityId == CityId).ToListAsync();

        }
        public async Task<IEnumerable<State>> GetStates(int CountryId)
        {
            return await _context.States.Where(e => e.CountryId == CountryId).ToListAsync();
        }
        public bool CountryExists(Country country)
        {
            return _context.Countries.Any(e => e.Name == country.Name);
        }
        public bool StateExists(State state)
        {
            return _context.States.Any(e => e.Name == state.Name);
        }
        public bool CityExists(City city)
        {
            return _context.Cities.Any(e => e.Name == city.Name);
        }
        public bool LocalityExists(Locality locality)
        {
            return _context.Localities.Any(e => e.Name == locality.Name);
        }
        public async Task<Country> GetCountry(int id)
        {
            return await _context.Countries.FindAsync(id);

        }
        public async Task<State> GetState(int id)
        {
            return await _context.States.FindAsync(id);
        }
        public async Task<City> GetCity(int id)
        {
            return await _context.Cities.FindAsync(id);
        }
        public async Task<Locality> GetLocality(int id)
        {
            return await _context.Localities.FindAsync(id);
        }
    }
}
