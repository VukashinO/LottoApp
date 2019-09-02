using DomainModels;
using System;
using System.Collections.Generic;

namespace DataLayer.Tickets
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        IEnumerable<Ticket> GetTicketByUserId(int id);
        IEnumerable<Ticket> GetTicketsByRound(int roundId);
    }
}
