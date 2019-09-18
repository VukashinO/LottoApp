using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer.Rounds
{
    public interface IRoundService
    {
        void GenerateRound();
        IEnumerable<RoundViewModel> GetRoundResult();
        void UpdateUserBalance(int roundId);
        RoundWinningCombinationViewModel GetWinningCombinationByRoundId(int roundId);
    }
}
