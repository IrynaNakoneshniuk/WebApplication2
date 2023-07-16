using System.Text;
using  UAParser;
using WebApplication2.Services;

namespace WebApplication2.Middleware
{
    public class DetectBrowserMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public DetectBrowserMiddleware(RequestDelegate requestDelegate) {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context, IEnumerable<IDetectBrowseService> detectBrowses)
        {
           var browserName= GetNameBrowser(context);

            if (!string.IsNullOrEmpty(browserName))
            {
                StringBuilder result= new StringBuilder();
                result.AppendLine("Visited to site");

                foreach (var browser in detectBrowses)
                {
                    bool hasFavico = HasFavico(context);
                    result.AppendLine(browser.DetectBrowse(browserName, hasFavico));
                }
                await context.Response.WriteAsync(result.ToString());
            }
        }

        private string GetNameBrowser(HttpContext context)
        {
            string userAgentString = context.Request.Headers["User-Agent"];

            var uaParser = Parser.GetDefault();
            ClientInfo clientInfo = uaParser.Parse(userAgentString);
            return  clientInfo.UA.Family;
        }

        private bool HasFavico(HttpContext context)
        {
            string favico = "/favicon.ico";
            return context.Request.Path.Equals(favico,
                    StringComparison.OrdinalIgnoreCase);
        }
    }
}
