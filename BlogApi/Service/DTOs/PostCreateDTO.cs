namespace BlogApi.Service.DTOs
{
    public class PostCreateDTO: IValidate
    {
        private const int TITLE_MAX_LENGTH = 150;
        private const int DESCRIPTION_MAX_LENGTH = 3000;
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description) 
                && Title.Length <= TITLE_MAX_LENGTH && Description.Length <= DESCRIPTION_MAX_LENGTH
                && (!string.IsNullOrEmpty(ImageUrl) ? ImageUrl.Length <= DESCRIPTION_MAX_LENGTH : true);
        }
    }
}