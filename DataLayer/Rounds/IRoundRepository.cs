using DomainModels;
using System;
using System.Collections.Generic;

namespace DataLayer.Rounds
{
    public interface IRoundRepository : IRepository<Round>
    {
        IEnumerable<Ticket> GetTicketsByDate(DateTime startDate, DateTime? endDate);
    }
}
