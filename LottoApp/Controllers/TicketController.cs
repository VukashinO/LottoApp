using BusinessLayer.Tickets;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace LottoApp.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Route("gettickets/{id}")]
        [HttpGet]
        public IActionResult GetTicketsById(int id)
        {
            try
            {
                return Ok(_ticketService.GetTicketsById(id));
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
                _ticketService.Create(createTicketViewModel);
                return Ok("Succseffuly created ticket");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
