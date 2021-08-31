using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

namespace SimpleAppMvc.Infrastructure
{
    public class SiteLengthHandler : HttpTaskAsyncHandler
    {
        public override async Task ProcessRequestAsync(HttpContext context)
        {
            string data = await new HttpClient().GetStringAsync("http://www.apress.com");

            context.Response.ContentType = "text/html";

            context.Response.Write(string.Format("<span>Length: {0}</span>", data.Length));
        }
    }
    
}