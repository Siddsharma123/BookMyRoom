using BookYourResidency.Api.Models;
using BookYourResidency.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyServices propertyServices;
        public PropertyController(IPropertyServices propertyServices)
        {
            this.propertyServices = propertyServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetAllProperties()
        {
            return Ok(await propertyServices.GetAllProperties());
        }

        [HttpGet("ByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<Property>>> GetPropertiesByUserId(int id)
        {
            return Ok(await propertyServices.GetPropertiesByUserId(id));
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Property>> GetPropertyById(int id)
        {
            return Ok(await propertyServices.GetPropertyById(id));
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Property>> CreateProperty(Property property)
        {
            try
            {
                if (property == null)
                {
                    return BadRequest();
                }
                await propertyServices.CreateProperty(property);
                return StatusCode(StatusCodes.Status200OK, "Property created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating a property");
            }
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Property>> UpdateResult(Property property)
        {
            try
            {
                if(property == null)
                {
                    return BadRequest();
                }
                var prop = await propertyServices.UpdateProperty(property);
                if(prop == null)
                {
                    return NotFound($"property with id {property.PropertyId}");
                }
                return StatusCode(StatusCodes.Status200OK, "Property Updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating a property");
            }      
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Property>> DeleteProperty(int id)
        {
            try
            {
                var prop = await propertyServices.GetPropertyById(id);
                if (prop == null)
                {
                    return NotFound($"Property with id = {id} not found");
                }
                return await propertyServices.DeleteProperty(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
    }
}
