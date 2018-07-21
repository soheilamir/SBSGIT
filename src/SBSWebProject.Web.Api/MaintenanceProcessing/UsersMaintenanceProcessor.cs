using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections;
using System.Collections.Generic;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Data.QueryProcessors;
using SBSWebProject.Data.DataHandlers;
using SBSWebProject.MappingObject;
using System.Linq;
using Users = SBSWebProject.Web.Api.Models.Users;

namespace SBSWebProject.Web.Api.MaintenanceProcessing
{
    public class UsersMaintenanceProcessor : IUsersMaintenanceProcessor
    {
        private readonly IMappingObject<NewUser, SBSWebProject.Data.Entities.Users> _userModelToEntity;
        private readonly IMappingObject<SBSWebProject.Data.Entities.Users, Users> _userEntityToModel;
        private readonly IBasicDataHandler<SBSWebProject.Data.Entities.Users> _userDataHandler;


        public UsersMaintenanceProcessor(IMappingObject<NewUser, SBSWebProject.Data.Entities.Users> userModelToEntity,
            IMappingObject<SBSWebProject.Data.Entities.Users, Users> userEntityToModel,
        IBasicDataHandler<SBSWebProject.Data.Entities.Users> userDataHandler)
        {
            _userModelToEntity = userModelToEntity;
            _userDataHandler = userDataHandler;
            _userEntityToModel = userEntityToModel;
        }


        public Users AddUser(NewUser newUser)
        {
            _userDataHandler.Save(_userModelToEntity.Map(newUser));
            Users hh = new Users { };
            return hh;
            //throw new NotImplementedException();
        }

        public Users GetUserByUsername(string username)
        {
            IList<Data.Entities.Users> lstusers = _userDataHandler.SelectAll().Cast<Data.Entities.Users>().Where(c => c.Username == username).ToList();
            return _userEntityToModel.Map(lstusers[0]);
        }
    }
}