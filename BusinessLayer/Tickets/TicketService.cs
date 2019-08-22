using DataLayer.Tickets;
using DomainModels;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace BusinessLayer.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void Create(CreateTicketViewModel ticketViewModel)
        {
            var model = new Ticket
            {
                Combination = ticketViewModel.Combination,
                Round = ticketViewModel.Round,
                Status = ticketViewModel.Status,
                UserId = ticketViewModel.UserId
            };

            _ticketRepository.Create(model);
        }

        public IEnumerable<TicketViewModel> GetTicketsById(int id)
        {
            var ticket = _ticketRepository.GetTicketByUserId(id);
            return ticket.Select(t => new TicketViewModel
            {
                Combination = t.Combination,
                Round = t.Round,
                Status = t.Status,
                Prize = t.Prize
            });
        }
    }
}
