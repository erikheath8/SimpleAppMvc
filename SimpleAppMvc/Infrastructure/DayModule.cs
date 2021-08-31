using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAppMvc.Infrastructure
{
    public class DayModule : IHttpModule
    {
        public void Init(HttpApplication app)
        {
            app.PostMapRequestHandler += (src, args) =>
            {
                if (app.Context.Handler is IRequiresDate)
                {
                    app.Context.Items["DayModule_Time"] = DateTime.Now;
                }
            };

            /* Old
             app.BeginRequest += (src, args) =>
             {
                 app.Context.Items["DayModule_Time"] = DateTime.Now;
             };*/
        }

        public void Dispose()
        {

        }
    }
}