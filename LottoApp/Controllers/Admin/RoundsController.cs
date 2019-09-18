using BusinessLayer.Rounds;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LottoApp.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoundsController : BaseController
    {
        private readonly IRoundService _roundService;

        public RoundsController(IRoundService roundService)
        {
            _roundService = roundService;
        }

        [Route("create-round")]
        [HttpPut]
        public IActionResult CreateRound()
        {
            try
            {
                _roundService.GenerateRound();
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("rounds-result")]
        [HttpGet]
        public IActionResult GetRoundResults()
        {
            try
            {
                return Ok(_roundService.GetRoundResult());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("winning-combination/{roundId}")]
        [HttpGet]
        public IActionResult GetWinningCombinationByRoundId(int roundId)
        {
            try
            {
                return Ok(_roundService.GetWinningCombinationByRoundId(roundId));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}