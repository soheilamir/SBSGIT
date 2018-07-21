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
using SBSWebProject.Web.Api.MethodsInterface;
using CountryModel = SBSWebProject.Web.Api.Models.Country;
using ExcelCountryModel = SBSWebProject.Web.Api.Models.ExcelReaderCountry;
using CountryEntity = SBSWebProject.Data.Entities.Country;
using StateProvinceEntity = SBSWebProject.Data.Entities.StateProvince;

using CountryNameByLanguageModel = SBSWebProject.Web.Api.Models.CountryNameByLanguage;
using CountryNameByLanguageEntity = SBSWebProject.Data.Entities.CountryNameByLanguage;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class CountryMethod : ICountryMethod
    {
        private readonly IMappingObject<ExcelCountryModel, CountryEntity> _excelCountryModelToEntity;
        private readonly IMappingObject<CountryModel, CountryEntity> _countryModelToEntity;
        private readonly IMappingObject<CountryEntity, CountryModel> _countryEntityToModel;

        private readonly IMappingObject<CountryNameByLanguageModel, CountryNameByLanguageEntity> _countryNameModelToEntity;
        private readonly IMappingObject<CountryNameByLanguageEntity, CountryNameByLanguageModel> _countryNameEntityToModel;

        private readonly IMappingObject<SBSWebProject.Data.Entities.StateProvince, SBSWebProject.Web.Api.Models.StateProvince> _stateProvinceEntityToModel;
        private readonly IMappingObject<SBSWebProject.Data.Entities.City, SBSWebProject.Web.Api.Models.City> _cityEntityToModel;

        private readonly IBasicDataHandler<CountryEntity> _countryDataHandler;
        private readonly IBasicDataHandler<StateProvinceEntity> _stateDataHandler;
        private readonly IBasicDataHandler<CountryNameByLanguageEntity> _countryNameByLanguageEntity;
        public CountryMethod(IMappingObject<CountryModel, CountryEntity> countryModelToEntity,
            IMappingObject<CountryEntity, CountryModel> countryEntityToModel,
            IBasicDataHandler<CountryEntity> countryDataHandler,
            IBasicDataHandler<CountryNameByLanguageEntity> countryNameByLanguageEntity,
            IMappingObject<CountryNameByLanguageModel, CountryNameByLanguageEntity> countryNameModelToEntity,
            IMappingObject<CountryNameByLanguageEntity, CountryNameByLanguageModel> countryNameEntityToModel,
            IMappingObject<ExcelCountryModel, CountryEntity> excelCountryModelToEntity,
            IMappingObject<SBSWebProject.Data.Entities.StateProvince, SBSWebProject.Web.Api.Models.StateProvince> stateProvinceEntityToModel,
            IBasicDataHandler<StateProvinceEntity> stateDataHandler,
            IMappingObject<SBSWebProject.Data.Entities.City, SBSWebProject.Web.Api.Models.City> cityEntityToModel)
        {
            _countryModelToEntity = countryModelToEntity;
            _countryEntityToModel = countryEntityToModel;
            _countryDataHandler = countryDataHandler;
            _countryNameByLanguageEntity = countryNameByLanguageEntity;
            _countryNameModelToEntity = countryNameModelToEntity;
            _countryNameEntityToModel = countryNameEntityToModel;
            _excelCountryModelToEntity = excelCountryModelToEntity;
            _stateProvinceEntityToModel = stateProvinceEntityToModel;
            _stateDataHandler = stateDataHandler;
            _cityEntityToModel = cityEntityToModel;
        }
        public void AddCountry(ExcelCountryModel newCountry, CountryNameByLanguageEntity newCountryName)
        {
            //CountryEntity vvv = _excelCountryModelToEntity.Map(newCountry);
            //_countryDataHandler.Save(vvv);
            //newCountryName.CountryItem = vvv;
            _countryNameByLanguageEntity.Save(newCountryName);
        }

        public CountryModel GetCountryById(long id)
        {
            throw new NotImplementedException();
        }

        public CountryModel GetCountryByName(long languageId, string name)
        {
            throw new NotImplementedException();
        }

        public IList<StateProvince> GetInternationalStateByCountry(long countryId)
        {
            IList<Data.Entities.StateProvince> lst = _countryDataHandler.GetEntity(countryId).StateProvinceS;
            return _countryDataHandler.GetEntity(countryId).StateProvinceS.Cast<Data.Entities.StateProvince>().Select(item => _stateProvinceEntityToModel.Map(item)).ToList();
        }

        public IList<CountryModel> GetInternationalCountriesList()
        {
            return _countryDataHandler.SelectAll().Cast<CountryEntity>().Select(item => _countryEntityToModel.Map(item)).ToList();
        }

        public IList<City> GetInternationalCityByState(long stateId)
        {
            Data.Entities.StateProvince sss = _stateDataHandler.GetEntity(stateId);
            return _stateDataHandler.GetEntity(stateId).CityS.Where(c => c.State == 0).Select(item => _cityEntityToModel.Map(item)).ToList();
        }

        public IList<ComboBox> GetComboCityByState(long langId, long stateId)
        {
            Data.Entities.StateProvince sss = _stateDataHandler.GetEntity(stateId);
            //return _stateDataHandler.GetEntity(stateId).CityS.Where(c => c.State == 0).Select(item => new { item.Id, item.CityNameByLanguageS }).Cast<ComboBox>().ToList();
            return _stateDataHandler.GetEntity(stateId).CityS.Where(c => c.State == 0).Select(item => new { id = item.Id, name = item.CityNameByLanguageS.Where(c => c.State == 0 && c.LanguagesItem.Id == langId) }).Cast<ComboBox>().ToList();
        }
    }
}