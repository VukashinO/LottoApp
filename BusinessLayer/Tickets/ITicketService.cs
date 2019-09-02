using System;
using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer.Tickets
{
    public interface ITicketService
    {
        IEnumerable<TicketViewModel> GetTicketsById(int id);
        void CreateTicket(CreateTicketViewModel ticketViewModel, int userId);
        IEnumerable<TicketViewModel> GetTicketsByRoundId(int roundId);
    }
}
