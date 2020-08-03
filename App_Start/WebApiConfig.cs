using AspMVCAdminLTE.Infrastructure;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace AspMVCAdminLTE
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());
            config.Filters.Add(new ApiExceptionHandlerAttribute());
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
        }
    }
}