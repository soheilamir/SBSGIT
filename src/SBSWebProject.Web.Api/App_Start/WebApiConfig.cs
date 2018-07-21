using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using SBSWebProject.Web.Common;
using SBSWebProject.Web.Common.Routing;
using System.Web.Http.Tracing;
using SBSWebProject.Common.Logging;
using System.Web.Http.ExceptionHandling;
using SBSWebProject.Web.Common.ErrorHandling;

namespace SBSWebProject.Web.Api
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register(HttpConfiguration config)
        {
            //HttpConfiguration config = new HttpConfiguration();

            //GlobalConfiguration.Configuration.EnableCors();
            //var constraintsResolver = new DefaultInlineConstraintResolver();
            //constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            //GlobalConfiguration.Configuration.MapHttpAttributeRoutes(constraintsResolver);
            //GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(GlobalConfiguration.Configuration));
            ////config.EnableSystemDiagnosticsTracing(); // replaced by custom writer
            //GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));
            //GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger), new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));
            //GlobalConfiguration.Configuration.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            //GlobalConfiguration.Configuration.EnsureInitialized();
            //return GlobalConfiguration.Configuration;


            HttpConfiguration configure = new HttpConfiguration();
            configure.EnableCors();
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            configure.MapHttpAttributeRoutes(constraintsResolver);
            configure.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(configure));
            //config.EnableSystemDiagnosticsTracing(); // replaced by custom writer
            configure.Services.Replace(typeof(ITraceWriter), new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));
            configure.Services.Add(typeof(IExceptionLogger), new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));
            configure.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            configure.DependencyResolver = config.DependencyResolver;
            return configure;
        }
    }
}
