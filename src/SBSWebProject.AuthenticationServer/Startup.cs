using SBSWebProject.AuthenticationServer.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Jwt;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using SBSWebProject.AuthenticationServer.MaintenanceProcessing;
using SBSWebProject.Web.Common;

[assembly: OwinStartup(typeof(SBSWebProject.AuthenticationServer.Startup))]

namespace SBSWebProject.AuthenticationServer
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            // Web API routes
            config.MapHttpAttributeRoutes();
            ConfigureOAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(WebApiConfig.Register());
            //app.UseNinjectMiddleware(() => WebContainerManager);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = "http://localhost:44075/";
            var audience = "099153c2625149bc8ecb3e85e03f0022";
            var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            //OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            //{
            //    //For Dev enviroment only (on production should be AllowInsecureHttp = false)

            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
            //    //Provider = _provider,
            //    Provider = new SimpleAuthorizationServerProvider(_user),
            //    AccessTokenFormat = new Formats.CustomJwtFormat("http://localhost:44075/")
            //};

            // OAuth 2.0 Bearer Access Token Generation
            //app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthAuthorizationServer(WebContainerManager.Get<MyOAuthAuthorizationServerOptions>().GetOptions());


            //// token consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                    Provider = new OAuthBearerAuthenticationProvider
                    {
                        OnValidateIdentity = context =>
                        {
                            context.Ticket.Identity.AddClaim(new System.Security.Claims.Claim("newCustomClaim", "newValue"));
                            return Task.FromResult<object>(null);
                        }
                    }
                });

        }
    }
}
