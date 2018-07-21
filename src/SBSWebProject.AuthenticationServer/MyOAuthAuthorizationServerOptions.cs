using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;

namespace SBSWebProject.AuthenticationServer
{
    public class MyOAuthAuthorizationServerOptions : IOAuthAuthorizationServerOptions
    {

        private IOAuthAuthorizationServerProvider _provider;


        public MyOAuthAuthorizationServerOptions(IOAuthAuthorizationServerProvider provider)
        {
            _provider = provider;
        }
        public OAuthAuthorizationServerOptions GetOptions()
        {
            return new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true, //TODO: HTTPS
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                Provider = _provider,
                AccessTokenFormat = new Formats.CustomJwtFormat("http://localhost:44075/")
            };
        }
    }
}