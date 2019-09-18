using System.Collections.Generic;
using System.Linq;
using DataLayer.Tickets.Views;
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

        public IEnumerable<TicketView> GetTicketByUserId(int id)
        {
            return GetAllTickets().Where(t => t.UserId == id);
        }

        public IEnumerable<TicketView> GetTicketsByRound(int roundId)
        {
            return GetAllTickets().Where(t => t.RoundId == roundId);
        }

        public IEnumerable<TicketView> GetTickets()
        {
            return GetAllTickets().ToList();
        }

        public void Update(Ticket obj)
        {
            throw new System.NotImplementedException();
        }

        public void SaveContext()
        {
            _dbContext.SaveChanges();
        }

        private IQueryable<TicketView> GetAllTickets()
        {
            return
                from t in _dbContext.Tickets
                join r in _dbContext.Rounds on t.Round equals r.Id 
                select new TicketView
                {
                    Id = t.Id,
                    Combination = t.Combination,
                    RoundCombination = r.WinningComination,
                    RoundId = t.Round,
                    DateOfTicket = t.DateCreated.Value,
                    UserId = t.UserId,
                    Status = t.Status
                };
        }
    }
}
