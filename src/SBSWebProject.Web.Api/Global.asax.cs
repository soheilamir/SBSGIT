using System.Web;
using System.Web.Http;
using SBSWebProject.Common.Logging;
using SBSWebProject.Common.Security;
using SBSWebProject.Web.Api.Security;
using SBSWebProject.Web.Common;
using JwtAuthForWebAPI;
using System;
using NHibernate.Context;
using NHibernate;

namespace SBSWebProject.Web.Api
{
    public class WebApiApplication : HttpApplication
    {
        //private static object syncRoot = new Object();
        //private readonly ISessionFactory _sessionFactory;
        //public WebApiApplication(ISessionFactory sessionFactory)
        //{
        //    _sessionFactory = sessionFactory;
        //}
        protected void Application_Start()
        {
            RegisterHandlers();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    lock (syncRoot)
        //    {
        //        var session = _sessionFactory.OpenSession();
        //        CurrentSessionContext.Bind(session);
        //    }
        //    string currentUrl = HttpContext.Current.Request.Url.ToString().ToLower();
        //    if (currentUrl.StartsWith("http://www.kamargardan.com"))
        //    {
        //        Response.Status = "301 Moved Permanently";
        //        Response.AddHeader("Location", currentUrl.Replace("http://www.kamargardan.com", "http://kamargardan.com"));
        //        Response.End();
        //    }
        //}

        private void RegisterHandlers()
        {
            var logManager = WebContainerManager.Get<ILogManager>();
            var userSession = WebContainerManager.Get<IUserSession>();

            var builder = new SecurityTokenBuilder();
            var reader = new ConfigurationReader();

            GlobalConfiguration.Configuration.MessageHandlers.Add(new BasicAuthenticationMessageHandler(logManager, WebContainerManager.Get<IBasicSecurityService>()));
            GlobalConfiguration.Configuration.MessageHandlers.Add(new TaskDataSecurityMessageHandler(logManager, userSession));

            GlobalConfiguration.Configuration.MessageHandlers.Add(
            new JwtAuthenticationMessageHandler
            {
                AllowedAudience = reader.AllowedAudience,
                Issuer = reader.Issuer,
                SigningToken = builder.CreateFromKey(reader.SymmetricKey)
            });

            GlobalConfiguration.Configuration.MessageHandlers.Add(new PagedTaskDataSecurityMessageHandler(logManager, userSession));
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
        //protected void Application_End(object sender, EventArgs e)
        //{
        //    var session = _sessionFactory.GetCurrentSession();
        //    session.Close();
        //    session.Dispose();
        //    CurrentSessionContext.Unbind(_sessionFactory);
        //}
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var SessionFactory = WebContainerManager.Get<ISessionFactory>();
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var SessionFactory = WebContainerManager.Get<ISessionFactory>();
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();
        }
    }
}
