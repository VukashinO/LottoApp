using BusinessLayer.Rounds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LottoApp.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IRoundService _roundService;

        public AdminController(IRoundService roundService)
        {
            _roundService = roundService;
        }
        //[Route("create-round")]
        //[HttpPut]
        //public IActionResult CreateRound()
        //{
        //    try
        //    {
        //        _roundService.GenerateRound();
        //        return Ok();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[Route("round-result/{roundId}")]
        //[HttpGet]
        //public IActionResult GetRoundResults(int roundId)
        //{
        //    try
        //    {
        //        return Ok(_roundService.GetRoundResult(roundId));
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
