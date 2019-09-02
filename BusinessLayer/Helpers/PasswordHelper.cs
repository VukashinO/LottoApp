using System.Text.RegularExpressions;

namespace BusinessLayer.Helpers
{
    public class PasswordHelper : IPasswordHelper 
    {
        public bool GetPasswordRegex(string input)
        {
            int maxCharLength = 16;

            if (input.Length > maxCharLength) return false;
            if (input.Contains("`")) return false;

            Regex projectPasswordRules = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

            return projectPasswordRules.IsMatch(input);
        }
    }
}
