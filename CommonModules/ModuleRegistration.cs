using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

//[assembly: PreApplicationStartMethod(typeof(CommonModules.ModuleRegistration), "RegisterModule")]

namespace CommonModules
{
    public class ModuleRegistration
    {
        public static void RegisterModule()
        {
            HttpApplication.RegisterModule(typeof(CommonModules.InfoModule));
        }

    }
}
