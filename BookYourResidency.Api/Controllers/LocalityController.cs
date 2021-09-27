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
    public class LocalityController : ControllerBase
    {
        private readonly IAddressServices addressServices;
        public LocalityController(IAddressServices addressServices)
        {
            this.addressServices = addressServices;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Locality>>> GetLocalities(int id)
        {
            try
            {
                return Ok(await addressServices.GetLocalities(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        [HttpGet("GetLocality/{id}")]
        public async Task<ActionResult<Locality>> GetLocality(int id)
        {
            var loc = await addressServices.GetLocality(id);
            if (loc == null)
            {
                return NotFound($"Country for id = {id} not found");
            }
            else
            {
                return loc;
            }
        }

        [HttpGet("Exist")]
        public bool LocalityExists(Locality locality)
        {
            return addressServices.LocalityExists(locality);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Locality>> CreateLocality(Locality locality)
        {
            try
            {
                if (LocalityExists(locality))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "locality already exist");
                }
                if (locality == null)
                {
                    return BadRequest();
                }
                await addressServices.CreateLocality(locality);
                return StatusCode(StatusCodes.Status200OK, "locality created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating locality");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Locality>> DeleteLocality(int id)
        {
            try
            {
                var loc = await addressServices.GetLocality(id);
                if (loc == null)
                {
                    return NotFound($"state with id = {id} not found");
                }
                return await addressServices.DeleteLocalityAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
    }
}
