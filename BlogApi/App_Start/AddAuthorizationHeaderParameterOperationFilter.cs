using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace BlogApi.App_Start
{
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (!operation.operationId.Contains("Auth"))
            {
                if(operation.parameters == null)
                {
                    operation.parameters = new List<Parameter>();
                }
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "jwt access token",
                    required = true,
                    type = "string"
                });
            }
        }
    }
}