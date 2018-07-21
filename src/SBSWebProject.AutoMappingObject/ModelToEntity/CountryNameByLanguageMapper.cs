﻿using CountryNameByLanguage = SBSWebProject.Data.Entities.CountryNameByLanguage;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CountryNameByLanguageMapper : IMappingObject<Web.Api.Models.CountryNameByLanguage, CountryNameByLanguage>
    {
        public CountryNameByLanguage Map(Web.Api.Models.CountryNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new ModelToEntity.CountryMapper();
            var languageMapper = new LanguageMapper();
            var outputModel = new CountryNameByLanguage
            {
                Id = objectToMap.Id,
                ContryName = objectToMap.ContryName,
                //CountryItem = countryMapper.Map(objectToMap.CountryItem),
                //LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem)
            };
            return outputModel;
        }
        public CountryNameByLanguage Map(Web.Api.Models.CountryNameByLanguage objectToMap, CountryNameByLanguage refObj)
        {
            if (objectToMap == null) return null;
            var countryMapper = new ModelToEntity.CountryMapper();
            var languageMapper = new LanguageMapper();
            refObj.Id = objectToMap.Id;
            refObj.ContryName = objectToMap.ContryName;
            //CountryItem = countryMapper.Map(objectToMap.CountryItem),
            //LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem)
            return refObj;
        }
    }
}
