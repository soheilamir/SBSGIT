using System.Web;
using System.Web.Http;
using SBSWebProject.Common.Logging;
using SBSWebProject.Common.Security;
//using SBSWebProject.Web.Api.Security;
using SBSWebProject.Web.Common;
using JwtAuthForWebAPI;

namespace SBSWebProject.AuthenticationServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterHandlers();
        }
        private void RegisterHandlers()
        {
            var logManager = WebContainerManager.Get<ILogManager>();
            var userSession = WebContainerManager.Get<IUserSession>();

            var builder = new SecurityTokenBuilder();
            var reader = new ConfigurationReader();

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new BasicAuthenticationMessageHandler(logManager, WebContainerManager.Get<IBasicSecurityService>()));
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new TaskDataSecurityMessageHandler(logManager, userSession));

            //GlobalConfiguration.Configuration.MessageHandlers.Add(
            //new JwtAuthenticationMessageHandler
            //{
            //    AllowedAudience = reader.AllowedAudience,
            //    Issuer = reader.Issuer,
            //    SigningToken = builder.CreateFromKey(reader.SymmetricKey)
            //});

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new PagedTaskDataSecurityMessageHandler(logManager, userSession));
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                var log = WebContainerManager.Get<ILogManager>().GetLog(typeof(WebApiApplication));
                log.Error("Unhandled exception.", exception);
            }
        }
    }
}
