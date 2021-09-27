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
    public class CityController : ControllerBase
    {
        private readonly IAddressServices addressServices;
        public CityController(IAddressServices addressServices)
        {
            this.addressServices = addressServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities(int id)
        {
            try
            {
                return Ok(await addressServices.GetCities(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        [HttpGet("GetCity/{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = await addressServices.GetCity(id);
            if (city == null)
            {
                return NotFound($"Country for id = {id} not found");
            }
            else
            {
                return city;
            }

        }

        [HttpGet("Exist")]
        public bool CityExists(City city)
        {
            return addressServices.CityExists(city);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<City>> CreateCity(City city)
        {
            try
            {
                if (CityExists(city))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "city already exist");
                }
                if (city == null)
                {
                    return BadRequest();
                }
                await addressServices.CreateCity(city);
                return StatusCode(StatusCodes.Status200OK, "City created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<City>> DeleteCity(int id)
        {
            try
            {
                var city = await addressServices.GetCity(id);
                if (city == null)
                {
                    return NotFound($"city with id = {id} not found");
                }
                return await addressServices.DeleteCityAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
    }
}
