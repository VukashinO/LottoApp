using DomainModels.Enums;

namespace BusinessLayer.Helpers
{
    public interface ITokenHelper
    {
        string GenerateToken(string userName, int Id, Role role);
    }
}
