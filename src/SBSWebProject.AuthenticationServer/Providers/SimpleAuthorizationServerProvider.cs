using System.Collections.Generic;
using System.EnterpriseServices;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using SBSWebProject.Data.SqlServer.QueryProcessors;
using SBSWebProject.AuthenticationServer.MaintenanceProcessing;

namespace SBSWebProject.AuthenticationServer.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsersMaintenanceProcessor _usersMaintenanceProcessor;

        public SimpleAuthorizationServerProvider(IUsersMaintenanceProcessor usersMaintenanceProcessor)
        {
            _usersMaintenanceProcessor = usersMaintenanceProcessor;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // OAuth2 supports the notion of client authentication
            // this is not used here
            //context.Validated();



            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }



            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_Id is not set");
                return;
                //return Task.FromResult<object>(null);   //comment for async
            }

            var audience = AudiencesStore.FindAudience(context.ClientId);

            if (audience == null)
            {
                context.SetError("invalid_clientId", string.Format("Invalid client_id '{0}'", context.ClientId));
                return;
                //return Task.FromResult<object>(null);    //comment for async
            }

            context.Validated();
            //return Task.FromResult<object>(null);   //comment for async


        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // validate user credentials (demo!)
            // user credentials should be stored securely (salted, iterated, hashed yada)
            //if (context.UserName != context.Password)
            //{
            //    context.Rejected();
            //    return;
            //}

            //// create identity
            //var id = new ClaimsIdentity(context.Options.AuthenticationType);
            //id.AddClaim(new Claim("sub", context.UserName));
            //id.AddClaim(new Claim("role", "user"));

            //context.Validated(id);




            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Dummy check here, you need to do your DB checks against membership system http://bit.ly/SPAAuthCode

            var test = _usersMaintenanceProcessor.CheckUser(context.UserName, context.Password);

            if (test == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
                return;
                //return Task.FromResult<object>(null);   //comment for async
            }

            //if (context.UserName != context.Password)
            //{
            //    context.SetError("invalid_grant", "The user name or password is incorrect");
            //    return;
            //    //return Task.FromResult<object>(null);   //comment for async
            //}

            var identity = new ClaimsIdentity("JWT");

           
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Sid, test.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Email, test.Email.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Supervisor"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "SeniorWorker"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "JuniorWorker"));
            
            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", (context.ClientId == null) ? string.Empty : context.ClientId
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
            //return Task.FromResult<object>(null);
        }
    }
}