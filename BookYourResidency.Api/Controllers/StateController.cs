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
    public class StateController : ControllerBase
    {
        private readonly IAddressServices addressServices;
        public StateController(IAddressServices addressServices)
        {
            this.addressServices = addressServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates(int id)
        {
            try
            {
                return Ok(await addressServices.GetStates(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database ");
            }
        }

        [HttpGet("GetState/{id}")]
        public async Task<ActionResult<State>> GetState(int id)
        {
            var state = await addressServices.GetState(id);
            if (state == null)
            {
                return NotFound($"State for id = {id} not found");
            }
            else
            {
                return state;
            }
        }

        [HttpGet("Exist")]
        public bool StateExists(State state)
        {
            return addressServices.StateExists(state);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<State>> CreateState(State state)
        {
            try
            {
                if (StateExists(state))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "State already exist");
                }
                if (state == null)
                {
                    return BadRequest();
                }
                await addressServices.CreateState(state);
                return StatusCode(StatusCodes.Status200OK, "State created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<State>> DeleteState(int id)
        {
            try
            {
                var state = await addressServices.GetState(id);
                if (state == null)
                {
                    return NotFound($"state with id = {id} not found");
                }
                return await addressServices.DeleteStateAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
    }
}
