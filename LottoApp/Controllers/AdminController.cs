using System.Collections.Generic;
using BusinessLayer.CreateRound;
using Microsoft.AspNetCore.Mvc;


namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly ICreateRound _createRound;

        public AdminController(ICreateRound createRound)
        {
            _createRound = createRound;
        }
       [Route("create-round")]
       [HttpPost]
       public IActionResult CreateRound()
        {
            try
            {
                return Ok(_createRound.ActivateRound());
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
