using DomainModels;

namespace DataLayer.Round
{
    public class RoundRepository : IRoundRepository
    {
        private readonly LottoDbContext _dbContext;

        public RoundRepository(LottoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(RoundResult roundResult)
        {
            _dbContext.RoundResults.Add(roundResult);
            _dbContext.SaveChanges();
        }
    }
}
