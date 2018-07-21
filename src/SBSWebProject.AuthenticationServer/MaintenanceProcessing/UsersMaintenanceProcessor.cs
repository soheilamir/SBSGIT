using System;
using System.Collections.Generic;
using SBSWebProject.Data.QueryProcessors;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.MappingObject;

namespace SBSWebProject.AuthenticationServer.MaintenanceProcessing
{
    public class UsersMaintenanceProcessor : IUsersMaintenanceProcessor
    {
        private readonly IMappingObject<Data.Entities.Users, Web.Api.Models.Users> _autoMapper;
        private readonly IUsersQueryProcessor _queryProcessor;


        public UsersMaintenanceProcessor(IUsersQueryProcessor queryProcessor, IMappingObject<Data.Entities.Users, Web.Api.Models.Users> autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }
        public Users CheckUser(string userName, string password)
        {
            var usersEntity = _queryProcessor.CheckLogin(userName, password);
            return CreateUsersResponse(usersEntity);
        }
        public virtual Users CreateUsersResponse(Data.Entities.Users usersEntity)
        {
            var users = _autoMapper.Map(usersEntity);
            return users;
        }
    }
}