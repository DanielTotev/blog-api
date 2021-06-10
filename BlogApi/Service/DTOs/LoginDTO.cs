namespace BlogApi.Service.DTOs
{
    public class LoginDTO : IValidate
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }
    }
}