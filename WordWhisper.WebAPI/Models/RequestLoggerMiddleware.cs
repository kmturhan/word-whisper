using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace WordWhisper.WebAPI.Models
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();

            var requestLog = new RequestLog
            {
                RequestMethod = context.Request.Method,
                RequestUrl = context.Request.Path,
                RequestBody = requestBody,
                ClientIpAddress = context.Connection.RemoteIpAddress.ToString(),
                RequestTime = DateTime.Now,
                JsonRequest = JsonConvert.SerializeObject(requestBody).ToString()
            };

            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(requestBody));
            await _next(context);
        }
    }
}
