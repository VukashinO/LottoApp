using System;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ViewModels;


namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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

        [Route("create-user")]
        [HttpPost]
        public IActionResult Create([FromBody]RegisterViewModel registerViewModel)
        {
            try
            {
                _userService.Register(registerViewModel);
                return Ok("Succseffuly created user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
