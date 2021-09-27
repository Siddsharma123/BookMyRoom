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
    public class CountryController : ControllerBase
    {
        private readonly IAddressServices addressServices;

        public CountryController(IAddressServices addressServices)
        {
            this.addressServices = addressServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return Ok(await addressServices.GetCountries());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await addressServices.GetCountry(id);
            if (country == null)
            {
                return NotFound($"Country for id = {id} not found");
            }
            else
            {
                return country;
            }
        }

        [HttpGet("Exist")]
        public bool CountryExists(Country country)
        {
            return addressServices.CountryExists(country);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                if (CountryExists(country))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Country already exists");
                }
                if (country == null)
                {
                    return BadRequest();
                }
                await addressServices.CreateCountry(country);
                return StatusCode(StatusCodes.Status200OK, "country created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            try
            {
                var country = await addressServices.GetCountry(id);
                if (country == null)
                {
                    return NotFound($"Country with id = {id} not found");
                }
                return await addressServices.DeleteCountryAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
    }
}
