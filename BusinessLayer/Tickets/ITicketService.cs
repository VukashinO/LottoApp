using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer.Tickets
{
    public interface ITicketService
    {
        IEnumerable<TicketViewModel> GetTicketsById(int id);
        void Create(CreateTicketViewModel ticketViewModel);
    }
}
