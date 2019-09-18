using DataLayer.Tickets.Views;
using DomainModels;
using System;
using System.Collections.Generic;

namespace DataLayer.Tickets
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        IEnumerable<TicketView> GetTicketByUserId(int id);
        IEnumerable<TicketView> GetTicketsByRound(int roundId);
        IEnumerable<TicketView> GetTickets();
    }
}
