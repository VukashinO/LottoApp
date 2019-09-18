using System;
using System.Collections.Generic;
using System.Linq;
using DomainModels;

namespace DataLayer.Rounds
{
    public class RoundRepository : IRoundRepository
    {
        private readonly LottoDbContext _dbContext;

        public RoundRepository(LottoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Round roundResult)
        {
            _dbContext.Rounds.Update(roundResult);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Round> GetAll()
        {
            return _dbContext.Rounds;
        }

        public void Create(Round obj)
        {
            _dbContext.Rounds.Add(obj);
            _dbContext.SaveChanges();
        }

        public Round GetById(int id)
        {
            return _dbContext.Rounds.FirstOrDefault(r => r.Id == id);
        }

        public void Delete(Round obj)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketsByDate(DateTime startDate, DateTime? endDate)
        {
            return _dbContext.Tickets.Where(t => t.DateCreated >= startDate.Date && t.DateCreated <= endDate);
        }

        public void SaveContext()
        {
            _dbContext.SaveChanges();
        }
    }
}
