using System;
using BusinessLayer.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace LottoApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("get-all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception)
            {
                return BadRequest("something went wrong");
            }
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IActionResult Create([FromBody]RegisterViewModel registerViewModel)
        {
            try
            {
                return Ok(_userService.Register(registerViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]LogInViewModel logInViewModel)
        {
            try
            {
                return Ok(_userService.Login(logInViewModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("winning-combination")]
        [HttpGet]
        public IActionResult GetLastRoundCombination()
        {
            try
            {
                return Ok(_userService.GetLastRoundCombination());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("signout")]
        [HttpGet]
        public IActionResult SignOut()
        {
            try
            {
                return Ok(CurrentUser.Token = string.Empty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
