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
    public class TypeController : ControllerBase
    {
        private readonly IOtherServices otherServices;
        public TypeController(IOtherServices otherServices)
        {
            this.otherServices = otherServices;
        }
        [HttpGet("getTenantsTypes")]
        public async Task<ActionResult<IEnumerable<TenantsType>>> GetTenantsTypes()
        {
            return Ok(await otherServices.GetTenantsTypes());
        }
        [HttpGet("getPropertyTypes")]
        public async Task<ActionResult<IEnumerable<Type>>> GetPropertyTypes()
        {
            return Ok(await otherServices.GetPropertyTypes());
        }

        [HttpGet("getTenantsTypeById/{id}")]
        public async Task<ActionResult<TenantsType>> GetTenantsTypeById(int id)
        {
            return Ok(await otherServices.GetTenantsTypeById(id));
        }

        [HttpGet("getPropertyTypeById/{id}")]
        public async Task<ActionResult<Type>> GetPropertyTypeById(int id)
        {
            return Ok(await otherServices.GetPropertyTypeById(id));
        }

        [HttpPost("createTenantsType")]
        public async Task<ActionResult<TenantsType>> CreateTenantsType(TenantsType type)
        {
            try
            {
                var exist = await otherServices.CreateTenantsType(type);
                if (exist == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Type already exists");
                }
                return exist;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding Type");
            }
        }
        [HttpPost("createPropertyType")]
        public async Task<ActionResult<PropertyType>> CreatePropertyType(PropertyType type)
        {
            try
            {
                var exist = await otherServices.CreatePropertyType(type);
                if (exist == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Type already exists");
                }
                return exist;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding Type");
            }
        }
        [HttpDelete("RemovePropertyType/{id}")]
        public async Task<ActionResult<PropertyType>> RemovePropertyType(int id)
        {
            try
            {
                var temp = await otherServices.RemovePropertyType(id);
                if (temp == null)
                {
                    return NotFound($"Type with id = {id} not found");
                }
                return temp;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
        [HttpDelete("RemoveTenantsType/{id}")]
        public async Task<ActionResult<TenantsType>> RemoveTenantsType(int id)
        {
            try
            {
                var temp = await otherServices.RemoveTenantsType(id);
                if (temp == null)
                {
                    return NotFound($"Type with id = {id} not found");
                }
                return temp;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
    }
}
