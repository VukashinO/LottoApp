using ViewModels;

namespace BusinessLayer.Rounds
{
    public interface IRoundService
    {
        void GenerateRound();
        RoundViewModel GetRoundResult(int roundId);
    }
}
