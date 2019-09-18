using BusinessLayer.Tickets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace LottoApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Route("gettickets")]
        [HttpGet]
        public IActionResult GetTicketsById()
        {
            try
            {
                return Ok(_ticketService.GetTicketsById(CurrentUser.Id));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateTicket([FromBody] CreateTicketViewModel createTicketViewModel)
        {
            try
            {
                _ticketService.CreateTicket(createTicketViewModel, CurrentUser.Id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
