namespace BusinessLayer.Helpers
{
    public interface IHashHelper
    {
        (string Salt, string Password) Hash(string plaintext, string saltString = null);
    }
}
