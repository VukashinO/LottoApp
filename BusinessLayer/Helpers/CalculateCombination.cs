using System.Linq;

namespace BusinessLayer.Helpers
{
    public static class CalculateCombination  
    {
        public static int GetNumberOfCorrectValues(string ticket, string roundCombination)
        {
            var result = 0;

            if (string.IsNullOrEmpty(roundCombination)) return result;

            var winningCombination = roundCombination.Split(';');
            var userTicket = ticket.Split(';');

            foreach (var number in userTicket)
            {
                if (winningCombination.Contains(number))
                    result++;
            }

            return result;
        }

        public static int CalculatePrize(int count)
        {
            switch (count)
            {
                case 4:
                    return count * 100;
                case 5:
                    return count * 1000;
                case 6:
                    return count * 10000;
                case 7:
                    return count * 100000;
                default:
                    return 0;
            }
        }
    }
}
