using BookYourResidency.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public class OtherServices : IOtherServices
    {
        private readonly BookYourResidencyDbContext _context;
        public OtherServices(BookYourResidencyDbContext context)
        {
            this._context = context;
        }
       
        public async Task<TenantsType> CreateTenantsType(TenantsType type)
        {
            var exist = await _context.TenantsTypes.AnyAsync(e => e.Name == type.Name);
            if (exist)
            {
                return null;
            }

            await _context.TenantsTypes.AddAsync(type);
            await _context.SaveChangesAsync();
            return await _context.TenantsTypes.FirstOrDefaultAsync(e => e.Name == type.Name);
        }

        public async Task<PropertyType> CreatePropertyType(PropertyType type)
        {
            var exist = await _context.Types.AnyAsync(e => e.Name == type.Name);
            if (exist)
            {
                return null;
            }
            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();
            return await _context.Types.FirstOrDefaultAsync(e => e.Name == type.Name);
        }

        public async Task<TenantsType> GetTenantsTypeById(int id)
        {
            return await _context.TenantsTypes.FirstOrDefaultAsync(e => e.TenantsTypeId == id);
        }

        public async Task<IEnumerable<TenantsType>> GetTenantsTypes()
        {
            return await _context.TenantsTypes.ToListAsync();
        }

        public async Task<PropertyType> GetPropertyTypeById(int id)
        {
            return await _context.Types.FirstOrDefaultAsync(e => e.PropertyTypeId == id);
        }

        public async Task<IEnumerable<PropertyType>> GetPropertyTypes()
        {
            return await _context.Types.ToListAsync();
        }

        public async Task<TenantsType> RemoveTenantsType(int id)
        {
            var temptype = await _context.TenantsTypes.FindAsync(id);
            if (temptype != null)
            {
                _context.TenantsTypes.Remove(temptype);
                await _context.SaveChangesAsync();
                return temptype;
            }
            return null;
        }

        public async Task<PropertyType> RemovePropertyType(int id)
        {
            var temptype = await _context.Types.FindAsync(id);
            if (temptype != null)
            {
                _context.Types.Remove(temptype);
                await _context.SaveChangesAsync();
                return temptype;
            }
            return null;
        }

       
    }
}
