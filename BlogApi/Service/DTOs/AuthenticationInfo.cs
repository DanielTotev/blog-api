using Newtonsoft.Json;

namespace BlogApi.Service.DTOs
{
    public class AuthenticationInfo
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}