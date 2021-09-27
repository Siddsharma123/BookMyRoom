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
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await userServices.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await userServices.GetUser(id);
            if (user == null)
            {
                return NotFound($"User for id = {id} not found");
            }
            else
            {
                return user;
            }
        }
        [HttpPut("update")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                var updatedUser = await userServices.UpdateUser(user);
                if (updatedUser == null)
                {
                    return NotFound("user not found");
                }
                return updatedUser;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating");
            }
        }
        [HttpPost("create")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                var exist = userServices.UserExist(user);
                if (exist)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "User already exists with email id = " + user.EmailAddress);
                }
                if (user == null)
                {
                    return BadRequest();
                }
                await userServices.CreateUser(user);
                return StatusCode(StatusCodes.Status200OK, "User created");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = await userServices.GetUser(id);
                if (user == null)
                {
                    return NotFound($"user with id = {id} not found");
                }
                return await userServices.DeleteUser(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(string EmailAddress, string Password)
        {
            try
            {
                var user = await userServices.UserWithIdAndPass(EmailAddress, Password);
                if (user == null)
                {
                    return NotFound($"Email address and password not found {EmailAddress}");
                }
                return user;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
