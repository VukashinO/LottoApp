namespace BusinessLayer.Helpers
{
    public interface ICalculateCombination
    {
        int GetNumberOfCorrectValues(string ticket, string roundCombination);
        int CalculatePrize(int count);
    }
}
