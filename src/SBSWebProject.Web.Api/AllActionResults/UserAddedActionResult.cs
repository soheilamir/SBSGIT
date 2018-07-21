using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UsersModel = SBSWebProject.Web.Api.Models.Users;

namespace SBSWebProject.Web.Api.AllActionResults
{
    public class UserAddedActionResult : IHttpActionResult
    {
        private readonly UsersModel _createdUser;
        private readonly HttpRequestMessage _requestMessage;
        public UserAddedActionResult(HttpRequestMessage requestMessage, UsersModel createdUser)
        {
            _requestMessage = requestMessage;
            _createdUser = createdUser;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute());
        }
        public HttpResponseMessage Execute()
        {
            var responseMessage = _requestMessage.CreateResponse(HttpStatusCode.Created, _createdUser);
            //responseMessage.Headers.Location = LocationLinkCalculator.GetLocationLink(_createdTask);
            return responseMessage;
        }
    }
}