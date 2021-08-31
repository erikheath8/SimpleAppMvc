using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAppMvc.Infrastructure
{
    public class DayOfWeekHandler : IHttpHandler, IRequiresDate
    {
        public void ProcessRequest(HttpContext context)
        {
            // Caution required when retrieving data from Items collection
            // First must ensure that data has been added to the collection below
            if (context.Items.Contains("DayModule_Time") && (context.Items["DayModule_Time"] is DateTime))
            {
                // Old assignment below
                //string day = DateTime.Now.DayOfWeek.ToString();
                                                        //Key
                string day = ((DateTime) context.Items["DayModule_Time"]).DayOfWeek.ToString();

                // Ensuring data being added to the Items collection is of the same type bc nothing preventing adding
                // different data type using the same key
                if (context.Request.CurrentExecutionFilePathExtension == ".json")
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(string.Format("{{\"day\": \"{0}\"}}", day));
                }
                else
                {
                    context.Response.ContentType = "text/html";
                    context.Response.Write(string.Format("<span>It is: {0}</span>", day));
                }
            } else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("No Module Data Available");
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }
}