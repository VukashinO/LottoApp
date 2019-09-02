namespace ViewModels
{
    public class AuthorizeModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
