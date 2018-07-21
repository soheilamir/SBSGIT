using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.MappingObject;
using LanguageModel = SBSWebProject.Web.Api.Models.Languages;
using LanguageEntity = SBSWebProject.Data.Entities.Languages;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class LanguagesMethod : ILanguagesMethod
    {
        private readonly IMappingObject<LanguageModel, LanguageEntity> _languageModelToEntity;
        private readonly IMappingObject<LanguageEntity, LanguageModel> _languageEntityToModel;
        private readonly IBasicDataHandler<LanguageEntity> _languageDataHandler;
        public LanguagesMethod(IMappingObject<LanguageModel, LanguageEntity> languageModelToEntity, IMappingObject<LanguageEntity, LanguageModel> languageEntityToModel, IBasicDataHandler<LanguageEntity> languageDataHandler)
        {
            _languageModelToEntity = languageModelToEntity;
            _languageEntityToModel = languageEntityToModel;
            _languageDataHandler = languageDataHandler;
        }
        public LanguageEntity GetLanguageEntityByCode(string languageCode)
        {
            LanguageEntity langObj = new LanguageEntity
            {
                ISO6391 = languageCode,
            };
            IList<LanguageEntity> lst = _languageDataHandler.Search(langObj).Cast<LanguageEntity>().ToList();
            if (lst.Count > 0)
                return lst[0];
            else
                return null;
        }

        public LanguageModel GetLanguageModelByCode(string languageCode)
        {
            LanguageEntity langObj = new LanguageEntity
            {
                ISO6391 = languageCode,
            };
            IList<LanguageEntity> lst = _languageDataHandler.Search(langObj).Cast<LanguageEntity>().ToList();
            if (lst.Count > 0)
                return _languageEntityToModel.Map(lst[0]);
            else
                return null;
        }

        public IList<LanguageModel> GetAllLanguageModel()
        {
            IList lstTemp = _languageDataHandler.SelectAll();
            IList<LanguageModel> lstResult = new List<LanguageModel>();
            foreach (Data.Entities.Languages item in lstTemp)
            {
                lstResult.Add(_languageEntityToModel.Map(item));
            }
            return lstResult;
        }
    }
}