using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Data.DataHandlers;
using SBSWebProject.MappingObject;
using SBSWebProject.Web.Api.MethodsInterface;
using SBSWebProject.Web.Api.Models;
using System.Collections;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class FacilitiesMethod : IFacilitiesMethod
    {
        private readonly IMappingObject<FacilitiesCategory, Data.Entities.FacilitiesCategory> _facilitiesCategoryModelToEntity;
        private readonly IMappingObject<Data.Entities.FacilitiesCategory, FacilitiesCategory> _facilitiesCategoryEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.FacilitiesCategory> _facilitiesCategoryDataHandler;

        private readonly IMappingObject<Facilities, Data.Entities.Facilities> _facilitiesModelToEntity;
        private readonly IMappingObject<Data.Entities.Facilities, Facilities> _facilitiesEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.Facilities> _facilitiesDataHandler;

        private readonly IMappingObject<FacilitiesNameByLanguage, Data.Entities.FacilitiesNameByLanguage> _facilitiesNameByLanguageModelToEntity;
        private readonly IMappingObject<Data.Entities.FacilitiesNameByLanguage, FacilitiesNameByLanguage> _facilitiesNameByLanguageEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.FacilitiesNameByLanguage> _facilitiesNameByLanguageDataHandler;

        public FacilitiesMethod(IMappingObject<FacilitiesCategory, Data.Entities.FacilitiesCategory> facilitiesCategoryModelToEntity
            , IMappingObject<Data.Entities.FacilitiesCategory, FacilitiesCategory> facilitiesCategoryEntityToModel
            , IBasicDataHandler<Data.Entities.FacilitiesCategory> facilitiesCategoryDataHandler

            , IMappingObject<Facilities, Data.Entities.Facilities> facilitiesModelToEntity
            , IMappingObject<Data.Entities.Facilities, Facilities> facilitiesEntityToModel
            , IBasicDataHandler<Data.Entities.Facilities> facilitiesDataHandler

            , IMappingObject<FacilitiesNameByLanguage, Data.Entities.FacilitiesNameByLanguage> facilitiesNameByLanguageModelToEntity
            , IMappingObject<Data.Entities.FacilitiesNameByLanguage, FacilitiesNameByLanguage> facilitiesNameByLanguageEntityToModel
            , IBasicDataHandler<Data.Entities.FacilitiesNameByLanguage> facilitiesNameByLanguageDataHandler)
        {
            _facilitiesCategoryModelToEntity = facilitiesCategoryModelToEntity;
            _facilitiesCategoryEntityToModel = facilitiesCategoryEntityToModel;
            _facilitiesCategoryDataHandler = facilitiesCategoryDataHandler;

            _facilitiesModelToEntity = facilitiesModelToEntity;
            _facilitiesEntityToModel = facilitiesEntityToModel;
            _facilitiesDataHandler = facilitiesDataHandler;

            _facilitiesNameByLanguageModelToEntity = facilitiesNameByLanguageModelToEntity;
            _facilitiesNameByLanguageEntityToModel = facilitiesNameByLanguageEntityToModel;
            _facilitiesNameByLanguageDataHandler = facilitiesNameByLanguageDataHandler;
        }
        #region FacilitiesCategoryMethods
        public FacilitiesCategory AddFacilitiesCategory(FacilitiesCategory facilitiesCategoryModel)
        {
            Data.Entities.FacilitiesCategory newObj = _facilitiesCategoryModelToEntity.Map(facilitiesCategoryModel);
            _facilitiesCategoryDataHandler.Save(newObj);
            return _facilitiesCategoryEntityToModel.Map(newObj);
        }
        public FacilitiesCategory EditFacilitiesCategory(FacilitiesCategory facilitiesCategoryModel)
        {
            Data.Entities.FacilitiesCategory newObj = _facilitiesCategoryModelToEntity.Map(facilitiesCategoryModel);
            _facilitiesCategoryDataHandler.Update(newObj);
            return _facilitiesCategoryEntityToModel.Map(newObj);
        }
        public void DeleteFacilitiesCategory(FacilitiesCategory facilitiesCategoryModel)
        {
            Data.Entities.FacilitiesCategory newObj = _facilitiesCategoryDataHandler.GetEntity(facilitiesCategoryModel.Id);

            _facilitiesCategoryDataHandler.Delete(newObj);
        }
        public IList<FacilitiesCategory> GetAllFacilitiesCategory()
        {
            IList lstFacilitiesCategory = _facilitiesCategoryDataHandler.SelectAll();
            IList<FacilitiesCategory> lstResult = new List<FacilitiesCategory>();
            foreach (Data.Entities.FacilitiesCategory item in lstFacilitiesCategory)
            {
                lstResult.Add(_facilitiesCategoryEntityToModel.Map(item));
            }
            return lstResult;
        }
        #endregion

        #region FacilitiesMethods
        public Facilities AddFacilities(Facilities facilitiesModel)
        {
            Data.Entities.Facilities newFacilitiesObj = _facilitiesModelToEntity.Map(facilitiesModel);
            _facilitiesDataHandler.Save(newFacilitiesObj);
            newFacilitiesObj.FacilitiesNameByLanguageS = new List<Data.Entities.FacilitiesNameByLanguage>();
            foreach (var item in facilitiesModel.FacilitiesNameByLanguageS)
            {
                Data.Entities.FacilitiesNameByLanguage newNameByLangObj = _facilitiesNameByLanguageModelToEntity.Map(item);
                newNameByLangObj.FacilitiesItem = newFacilitiesObj;
                _facilitiesNameByLanguageDataHandler.Save(newNameByLangObj);
                newFacilitiesObj.FacilitiesNameByLanguageS.Add(newNameByLangObj);
            }
            Models.Facilities result = _facilitiesEntityToModel.Map(newFacilitiesObj);
            result.FacilitiesNameByLanguageS = new List<Models.FacilitiesNameByLanguage>();
            foreach (var item in newFacilitiesObj.FacilitiesNameByLanguageS)
            {
                result.FacilitiesNameByLanguageS.Add(_facilitiesNameByLanguageEntityToModel.Map(item));
            }

            return result;
        }
        public IList<Facilities> GetAllFacilities()
        {
            IList lstFacilities = _facilitiesDataHandler.SelectAll();
            IList<Facilities> lstResult = new List<Facilities>();
            foreach (Data.Entities.Facilities item in lstFacilities)
            {
                lstResult.Add(_facilitiesEntityToModel.Map(item));
            }
            return lstResult;
        }
        #endregion

    }
}