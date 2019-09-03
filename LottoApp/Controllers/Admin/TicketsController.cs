using BusinessLayer.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LottoApp.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TicketsController : BaseController
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Route("tickets-byround/{roundId}")]
        [HttpGet]
        public IActionResult GetTicketsByRoundId(int roundId)
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
    }
}