using BusinessLayer.Rounds;
using BusinessLayer.Tickets;
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
        private readonly ITicketService _ticketService;

        public AdminController(IRoundService roundService, ITicketService ticketService)
        {
            _roundService = roundService;
            _ticketService = ticketService;
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

        [Route("tickets/{roundId}")]
        [HttpGet]
        public IActionResult GetAllTickets(int roundId)
        {
            try
            {
                return Ok(_ticketService.GetTicketsByRoundId(roundId));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("round-result/{roundId}")]
        [HttpGet]
        public IActionResult GetRoundResults(int roundId)
        {
            try
            {
                return Ok(_roundService.GetRoundResult(roundId));
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
