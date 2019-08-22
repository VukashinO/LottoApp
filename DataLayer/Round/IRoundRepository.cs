
using DomainModels;

namespace DataLayer.Round
{
    public interface IRoundRepository
    {
        void Create(RoundResult roundResult);
    }
}
