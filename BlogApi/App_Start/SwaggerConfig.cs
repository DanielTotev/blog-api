using System.Web.Http;
using WebActivatorEx;
using BlogApi;
using Swashbuckle.Application;
using BlogApi.App_Start;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BlogApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
              .EnableSwagger(c => {
                  c.SingleApiVersion("v1", "Blog API");
                  c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
              })
              .EnableSwaggerUi();
        }
    }
}
