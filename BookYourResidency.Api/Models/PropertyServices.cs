using BookYourResidency.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public class PropertyServices : IPropertyServices
    {
        private readonly BookYourResidencyDbContext _context;
        public PropertyServices(BookYourResidencyDbContext context)
        {
            this._context = context;
        }
        public async Task<Property> CreateProperty(Property propertyInput)
        {
            try
            {
                var user = await _context.Users.FindAsync(propertyInput.UserId);
                if (user == null)
                {
                    return null;
                }
                Property property = new Property();
                property.Availability = propertyInput.Availability;
                property.ForRent = propertyInput.ForRent;
                property.ForSale = propertyInput.ForSale;
                property.RentRate = propertyInput.RentRate;
                property.SaleRate = propertyInput.SaleRate;
                property.Phone = propertyInput.Phone;
                property.Negotiable = propertyInput.Negotiable;
                property.PropertyType = propertyInput.PropertyType;
                property.TenantsId = propertyInput.TenantsId;
                property.UserId = propertyInput.UserId;
                property.Message = propertyInput.Message;
                Location location = new Location();
                location.Property = property;
                location.Country = propertyInput.Location.Country;
                location.City = propertyInput.Location.City;
                location.State = propertyInput.Location.State;
                location.Locality = propertyInput.Location.Locality;
                property.Location = location;
                foreach (var img in propertyInput.Images)
                {
                    property.Images.Add(img);
                }
                user.Properties.Add(property);
                await _context.SaveChangesAsync();
                return property;
            }
            catch (Exception)
            {
                throw new Exception("error while creating a property");
            }
        }
        public async Task<Property> DeleteProperty(int id)
        {
            var prp = await _context.Properties.FindAsync(id);
            if (prp != null)
            {
                _context.Properties.Remove(prp);
                await _context.SaveChangesAsync();
                return prp;
            }
            return null;
        }
        public async Task<IEnumerable<Property>> GetAllProperties()
        {
            return await _context.Properties.Include(e => e.Location).Include(e => e.Location.Country).Include(e => e.Location.State).Include(e => e.Location.City).Include(e => e.Location.Locality).Include(e => e.PropertyType).Include(e=>e.TenantsId).Include(e => e.Images).ToListAsync();
        }
        public async Task<IEnumerable<Property>> GetPropertiesByUserId(int id)
        {
            return await _context.Properties.Where(e => e.UserId == id).Include(e => e.Location).Include(e => e.Location.Country).Include(e => e.Location.State).Include(e => e.Location.City).Include(e => e.Location.Locality).Include(e => e.PropertyType).Include(e => e.TenantsId).Include(e => e.Images).ToListAsync();
        }
        public async Task<Property> GetPropertyById(int id)
        {
            return await _context.Properties.FirstOrDefaultAsync(e => e.PropertyId == id);
        }
        public async Task<Property> UpdateProperty(Property property)
        {
            var prop = _context.Properties.FindAsync(property.PropertyId);
            if (prop == null)
            {
                return null;
            }
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
            return await _context.Properties.FirstOrDefaultAsync(e => e.PropertyId == property.PropertyId);
        }
    }
}
