using Newtonsoft.Json;

namespace BlogApi.Messages
{
    public class ResponseMessage
    {
        [JsonProperty(PropertyName = "code")]
        public object Code { get; set; }

        [JsonProperty(PropertyName = "body", NullValueHandling = NullValueHandling.Ignore)]
        public object Body { get; set; }

        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public object Error { get; set; }

        public static ResponseMessage BadRequest()
        {
            return new ResponseMessage()
            {
                Code = 400,
                Error = "Bad Request"
            };
        }

        public static ResponseMessage BadRequest(string error)
        {
            return new ResponseMessage()
            {
                Code = 400,
                Error = error
            };
        }

        public static ResponseMessage InternalServerError()
        {
            return new ResponseMessage()
            {
                Code = 500,
                Error = "Internal Server Error"
            };
        }

        public static ResponseMessage Created(object body)
        {
            return new ResponseMessage()
            {
                Code = 201,
                Body = body
            };
        }

        public static ResponseMessage Ok(object body)
        {
            return new ResponseMessage()
            {
                Code = 200,
                Body = body
            };
        }

        public static ResponseMessage NotFound()
        {
            return new ResponseMessage()
            {
                Code = 404,
                Error = "Not Found"
            };
        }

        public static ResponseMessage NotFound(string error)
        {
            return new ResponseMessage()
            {
                Code = 404,
                Error = error
            };
        }

        public static ResponseMessage Unauthorized()
        {
            return new ResponseMessage()
            {
                Code = 401,
                Error = "Unauthorized"
            };
        }

        public static ResponseMessage NoContent()
        {
            return new ResponseMessage()
            {
                Code = 204,
            };
        }
    }
}