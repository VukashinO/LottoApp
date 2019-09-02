using System.Collections.Generic;
using System.Linq;
using DomainModels;

namespace DataLayer.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly LottoDbContext _dbContext;

        public TicketRepository(LottoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Ticket obj)
        {
            _dbContext.Tickets.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Delete(Ticket obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _dbContext.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketByUserId(int id)
        {
            return _dbContext.Tickets.Where(t => t.UserId == id);
        }

        public IEnumerable<Ticket> GetTicketsByRound(int roundId)
        {
            return _dbContext.Tickets.Where(t => t.Round == roundId);
        }

        public void Update(Ticket obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
