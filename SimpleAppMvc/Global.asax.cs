using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace SimpleAppMvc
{
    public class MvcApplication : HttpApplication
    {
        public MvcApplication()
        {
            PostAcquireRequestState += (src, args) => CreateTimeStamp();

            // Lambda way of assigning event to request
            //BeginRequest += (src, args) => RecordEvent("BeginRequest");
            //AuthenticateRequest += (src, args) => RecordEvent("AuthenicateRequest");
            //PostAuthenticateRequest += (src, args) => RecordEvent("PostAuthenicateRequest");

            //BeginRequest += RecordEvent;
            //AuthenticateRequest += RecordEvent;
            //PostAuthenticateRequest += RecordEvent;
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            CreateTimeStamp();
            //Debugger is called and application stops till continue is pressed
            //Debugger.Break();
        }

        private void CreateTimeStamp()
        {
            string stamp = Context.Timestamp.ToLongTimeString();
            if (Context.Session != null)
            {
                Session["request_timestamp"] = stamp;
            }
            else
            {
                Application["app_timestamp"] = stamp;
            }
        }
        private void RecordEvent(object src, EventArgs args)
        {
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }

            string name = Context.CurrentNotification.ToString();
            if (Context.IsPostNotification)
            {
                name = "Post" + name;
            }
            
            eventList.Add(name);
        }
        
        /*
         * Defined classes for logging 
        protected void Application_BeginRequest()
        {
            RecordEvent("BeginRequest");
        }

        protected void Application_AuthenicateRequest()
        {
            RecordEvent("AuthenicateRequest");
        }

        protected void Application_PostAuthenicateRequest()
        {
            RecordEvent("PostAuthenicateRequest");
        }
        */
        protected void Application_End()
        {
            Debugger.Break();
        }
        
    }
}
