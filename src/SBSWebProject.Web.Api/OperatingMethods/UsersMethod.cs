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
using UsersModel = SBSWebProject.Web.Api.Models.Users;
using SBSWebProject.Web.Api.MethodsInterface;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class UsersMethod : IUsersMethod
    {
        private readonly IMappingObject<NewUser, SBSWebProject.Data.Entities.Users> _userModelToEntity;
        private readonly IMappingObject<SBSWebProject.Data.Entities.Users, UsersModel> _userEntityToModel;
        private readonly IMappingObject<SBSWebProject.Data.Entities.Company, Company> _companyEntityToModel;
        private readonly IBasicDataHandler<SBSWebProject.Data.Entities.Users> _userDataHandler;
        

        public UsersMethod(IMappingObject<NewUser, SBSWebProject.Data.Entities.Users> userModelToEntity,
            IMappingObject<SBSWebProject.Data.Entities.Users, UsersModel> userEntityToModel, 
            IMappingObject<SBSWebProject.Data.Entities.Company, Company> companyEntityToModel,
        IBasicDataHandler<SBSWebProject.Data.Entities.Users> userDataHandler)
        {
            _userModelToEntity = userModelToEntity;
            _userDataHandler = userDataHandler;
            _userEntityToModel = userEntityToModel;
            _companyEntityToModel = companyEntityToModel;
        }

        public UsersModel AddUser(NewUser newUser)
        {
            Data.Entities.Users userEntity = _userModelToEntity.Map(newUser);
            _userDataHandler.Save(userEntity);
            return _userEntityToModel.Map(userEntity);
            //throw new NotImplementedException();
        }

        public UsersModel GetUserByUsername(string username)
        {
            IList<Data.Entities.Users> lstusers = _userDataHandler.SelectAll().Cast<Data.Entities.Users>().Where(c => c.Username == username).ToList();
            return _userEntityToModel.Map(lstusers[0]);
        }

        public IList<Company> GetUserCompanyAccounts(long userId)
        {

            IList<Company> lstResultCo = new List<Company>();
            foreach (SBSWebProject.Data.Entities.Company itemCompany in _userDataHandler.GetEntity(userId).CompanyS.Where(c => c.State == 0))
            {
                lstResultCo.Add(_companyEntityToModel.Map(itemCompany));
            }
            return lstResultCo;
        }
        public Data.Entities.Users IsUserExist(long userId)
        {
            Data.Entities.Users result = _userDataHandler.GetEntity(userId);
            if (result != null)
                return result;
            return null;
        }
    }
}