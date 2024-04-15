using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PeopleApp.Api.Attributes
{
    [AttributeUsage(validOn:AttributeTargets.Class)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        //Net zoals bij Controllers valt 'Attribute' weg, als
        //er gevraagd wordt op de examen om een controller te beveilignen met een Key
        //Dat doen we op deze methode
        private const string APIKEYNAME = "ApiKey";
        private ContentResult GetContentResult(int statusCode, string content)
        {
            var result = new ContentResult();
            result.StatusCode = statusCode;
            result.Content  = content;
            return result;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Result = GetContentResult(500, "Api Key was not provided");
                    return;
                }
                var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                if (appSettings == null)
                {
                    context.Result = GetContentResult(401, "Appsettings not found");
                    return;
                }
                var apiKey = appSettings.GetValue<string>(APIKEYNAME);
                if (apiKey == null)
                {
                    context.Result = GetContentResult(401, "Appsettings - ApiKey - not found");
                    return;
                }
                if (!apiKey.Equals(extractedApiKey))
                {
                    context.Result = GetContentResult(422, "Api Key is not valid!");
                    return;
                }
                await next();
            }
            catch (Exception ex)
            {
                context.Result = GetContentResult(400, ex.Message);
                return;
            }
        }
    }
}
