using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.SqlServer.Mapping;
using JwtAuthForWebAPI;

namespace SBSWebProject.Web.NewApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static object syncRoot = new Object();
        public static ISessionFactory SessionFactory { get; private set; }
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //var nhConfig = new NHibernate.Cfg.Configuration().Configure();
            //SessionFactory = nhConfig.BuildSessionFactory();
            Application["Users"] = 0;
            SessionFactory = Fluently.Configure()
            .Database(
            MsSqlConfiguration.MsSql2008.ConnectionString(
                c => c.FromConnectionStringWithKey("SBSWebProjectDb"))).CurrentSessionContext("web").Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<UsersMap>())
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .BuildSessionFactory();
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["suer"] = Convert.ToInt32(Application["Users"]) + 1;
            Application["Users"] = Session["suer"];
        }
        private void RegisterHandlers()
        {
            //var logManager = WebContainerManager.Get<ILogManager>();
            //var userSession = WebContainerManager.Get<IUserSession>();

            var builder = new SecurityTokenBuilder();
            var reader = new ConfigurationReader();

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new BasicAuthenticationMessageHandler(logManager, WebContainerManager.Get<IBasicSecurityService>()));
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new TaskDataSecurityMessageHandler(logManager, userSession));

            GlobalConfiguration.Configuration.MessageHandlers.Add(
            new JwtAuthenticationMessageHandler
            {
                AllowedAudience = reader.AllowedAudience,
                Issuer = reader.Issuer,
                SigningToken = builder.CreateFromKey(reader.SymmetricKey)
            });

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new PagedTaskDataSecurityMessageHandler(logManager, userSession));
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            lock (syncRoot)
            {
                var session = SessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

        }
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
            Application.UnLock();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();

        }
    }
}
