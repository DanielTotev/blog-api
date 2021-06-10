using Newtonsoft.Json;

namespace BlogApi.Service.DTOs
{
    public class AllPostsDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }
    }
}