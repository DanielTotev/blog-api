namespace BlogApi.Service.DTOs
{
    public class UserDTO: IValidate
    {
        private const int MAX_USERNAME_LENGTH = 50;
        private const int MAX_EMAIL_LENGTH = 150;
        private const int MAX_PASSWORD_LENGTH = 400;

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email)
                && Username.Length <= MAX_USERNAME_LENGTH && Email.Length <= MAX_EMAIL_LENGTH && Password.Length <= MAX_PASSWORD_LENGTH;
        }
    }
}