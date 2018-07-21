using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Data.DataHandlers;
using SBSWebProject.MappingObject;
using System.Web.Http;

using SBSWebProject.Data.SqlServer;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class CompanyMethod : ICompanyMethod
    {
        private readonly IUsersMethod _usersMethods;

        private readonly IBasicDataHandler<Data.Entities.Company> _companyHandler;
        private readonly IBasicDataHandler<Data.Entities.CompanyEmployee> _companyEmployeeHandler;
        private readonly IBasicDataHandler<Data.Entities.Users> _usersHandler;

        private readonly IMappingObject<NewCompany, Data.Entities.Company> _newCompanyModelToEntity;
        private readonly IMappingObject<Data.Entities.Company, Company> _companyEntityToModel;
        private readonly IMappingObject<Company, Data.Entities.Company> _companyModelToEntity;
        private readonly IMappingObject<Data.Entities.CompanyEmployee, CompanyEmployee> _companyEmployeeEntityToModel;
        private readonly IMappingObject<CompanyEmployee, Data.Entities.CompanyEmployee> _companyEmployeeModelToEntity;
        public CompanyMethod(IBasicDataHandler<Data.Entities.Company> companyHandler,
            IBasicDataHandler<Data.Entities.Users> usersHandler,
            IMappingObject<NewCompany, Data.Entities.Company> newCompanyModelToEntity,
            IMappingObject<Company, Data.Entities.Company> companyModelToEntity,
            IMappingObject<Data.Entities.Company, Company> companyEntityToModel,
            IMappingObject<Data.Entities.CompanyEmployee, CompanyEmployee> companyEmployeeEntityToModel,
            IUsersMethod usersMethods,
            IBasicDataHandler<Data.Entities.CompanyEmployee> companyEmployeeHandler,
            IMappingObject<CompanyEmployee, Data.Entities.CompanyEmployee> companyEmployeeModelToEntity)
        {
            _companyHandler = companyHandler;
            _newCompanyModelToEntity = newCompanyModelToEntity;
            _companyEntityToModel = companyEntityToModel;
            _usersHandler = usersHandler;
            _companyEmployeeEntityToModel = companyEmployeeEntityToModel;
            _usersMethods = usersMethods;
            _companyEmployeeHandler = companyEmployeeHandler;
            _companyModelToEntity = companyModelToEntity;
            _companyEmployeeModelToEntity = companyEmployeeModelToEntity;
        }
        #region public method
        public Company RegisterComopany(long userId, NewCompany companyObj)
        {
            Data.Entities.Company company = _newCompanyModelToEntity.Map(companyObj);
            company.RegisterDate = DateTime.Now;
            company.UsersItem = new Data.Entities.Users { Id = userId };
            _companyHandler.Save(company);
            return _companyEntityToModel.Map(company);
        }

        public IList<CompanyEmployee> GetAllCompanyEmployee(long userId, long companyId)
        {
            if (CheckUserInCompany(userId, companyId))
                return _companyHandler.GetEntity(companyId).CompanyEmployeeS.Cast<Data.Entities.CompanyEmployee>().Where(c => c.State == 0).Select(item => _companyEmployeeEntityToModel.Map(item)).ToList();
            return null;
        }


        public void SendJoinToCompanyRequest(long userId, Company company)
        {
            Data.Entities.Users userToSendRequest = _usersMethods.IsUserExist(userId);
            if (userToSendRequest != null)
            {
                Data.Entities.CompanyEmployee newEmployee = new Data.Entities.CompanyEmployee
                {
                    UserItem = userToSendRequest,
                    CompanyItem = _companyModelToEntity.Map(company),
                    RequestDate = DateTime.Now,
                };
                _companyEmployeeHandler.Save(newEmployee);
            }

        }
        public Company EditCompanyInfo(Company company)
        {
            _companyHandler.Update(_companyModelToEntity.Map(company));
            return company;

        }
        public Company GetCompanyInfo(long companyId)
        {
            return _companyEntityToModel.Map(_companyHandler.GetEntity(companyId));
        }
        public void AssignEmployeeResponsible(CompanyEmployee mainEmployee, CompanyEmployee altEmployee, short level)
        {
        }
        #endregion

        #region local method
        private bool CheckUserInCompany(long userId, long companyId)
        {
            if (_usersHandler.GetEntity(userId).CompanyS.Where(c => c.State == 0 && c.Id == companyId).Count() > 0)
                return true;
            return false;
        }
        #endregion

    }
}