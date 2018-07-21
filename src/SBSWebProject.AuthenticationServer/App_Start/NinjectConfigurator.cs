using System.Reflection;
using log4net.Config;
using Ninject;
using SBSWebProject.Common;
using SBSWebProject.Common.Logging;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using NHibernate;
using NHibernate.Context;
using Ninject.Activation;
using Ninject.Web.Common;
using SBSWebProject.Common.Security;
using SBSWebProject.Data.QueryProcessors;
using SBSWebProject.Data.SqlServer.Mapping;
using SBSWebProject.Data.SqlServer.QueryProcessors;
using SBSWebProject.Web.Common;
using SBSWebProject.Web.Common.Security;
using SBSWebProject.AuthenticationServer.MaintenanceProcessing;
using SBSWebProject.AuthenticationServer.Providers;
using SBSWebProject.MappingObject;
using SBSWebProject.MappingObject.EntityToModel;

//using SBSWebProject.AuthenticationServer.Security;
//using SBSWebProject.AuthenticationServer.InquiryProcessing;
//using SBSWebProject.AuthenticationServer.LinkServices;

namespace SBSWebProject.AuthenticationServer
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            AddBindings(container);
        }
        private void AddBindings(IKernel container)
        {
            ConfigureLog4net(container);
            ConfigureUserSession(container);
            ConfigureNHibernate(container);
            ConfigureMappingObject(container);
            container.Bind<IDateTime>().To<DateTimeAdapter>().InSingletonScope();
            container.Bind<IAddTaskQueryProcessor>().To<AddTaskQueryProcessor>().InRequestScope();
            container.Bind<IUpdateablePropertyDetector>().To<JObjectUpdateablePropertyDetector>().InSingletonScope();

            container.Bind<IUserQueryProcessor>().To<UserQueryProcessor>().InRequestScope();
            container.Bind<IUsersQueryProcessor>().To<UsersQueryProcessor>().InRequestScope();
            container.Bind<IUsersMaintenanceProcessor>().To<UsersMaintenanceProcessor>().InRequestScope();

            container.Bind<IOAuthAuthorizationServerProvider>().To<SimpleAuthorizationServerProvider>().InRequestScope();
            container.Bind<IOAuthAuthorizationServerOptions>().To<MyOAuthAuthorizationServerOptions>().InRequestScope();
        }
        private void ConfigureLog4net(IKernel container)
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            container.Bind<ILogManager>().ToConstant(logManager);
        }
        private void ConfigureNHibernate(IKernel container)
        {
            //var sessionFactory = Fluently.Configure()
            //.Database(
            //MsSqlConfiguration.MsSql2008.ConnectionString(
            //    c => c.FromConnectionStringWithKey("SBSWebProjectDb"))).CurrentSessionContext("web").Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>()).BuildSessionFactory();
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("SBSWebProjectDb")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsersMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TaskMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StatusMap>())
                .CurrentSessionContext("web")
                .BuildSessionFactory();
            container.Bind<ISessionFactory>().ToConstant(sessionFactory);
            container.Bind<ISession>().ToMethod(CreateSession).InRequestScope();
            container.Bind<IActionTransactionHelper>().To<ActionTransactionHelper>().InRequestScope();
            //container.Bind<IBasicSecurityService>().To<BasicSecurityService>().InSingletonScope();
        }
        private ISession CreateSession(IContext context)
        {

            var sessionFactory = context.Kernel.Get<ISessionFactory>();
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return sessionFactory.GetCurrentSession();
        }
        private void ConfigureUserSession(IKernel container)
        {
            var userSession = new UserSession();
            container.Bind<IUserSession>().ToConstant(userSession).InSingletonScope();
            container.Bind<IWebUserSession>().ToConstant(userSession).InSingletonScope();
        }
        private void ConfigureMappingObject(IKernel container)
        {
            container.Bind<IMappingObject<Data.Entities.Airports, Web.Api.Models.Airports>>().To<AirportMapper>();
            container.Bind<IMappingObject<Data.Entities.AirportNameByLanguage, Web.Api.Models.AirportNameByLanguage>>().To<AirportNameByLanguageMapper>();
            container.Bind<IMappingObject<Data.Entities.City, Web.Api.Models.City>>().To<CityMapper>();
            container.Bind<IMappingObject<Data.Entities.Languages, Web.Api.Models.Languages>>().To<LanguageMapper>();
            container.Bind<IMappingObject<Data.Entities.Users, Web.Api.Models.Users>>().To<UsersMapper>();
        }
    }
}