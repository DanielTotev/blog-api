using Newtonsoft.Json;

namespace BlogApi.Service.DTOs
{
    public class BaseCommentDTO: IValidate
    {
        private const int MAX_CONTENT_LENGTH = 3000;

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Content) && Content.Length <= MAX_CONTENT_LENGTH;
        }
    }
}