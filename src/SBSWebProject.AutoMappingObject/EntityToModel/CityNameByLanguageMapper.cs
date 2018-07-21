using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityNameByLanguage = SBSWebProject.Web.Api.Models.CityNameByLanguage;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CityNameByLanguageMapper : IMappingObject<Data.Entities.CityNameByLanguage, CityNameByLanguage>
    {
        public CityNameByLanguage Map(Data.Entities.CityNameByLanguage objectToMap)
        {
            if (objectToMap == null) return null;
            var languageMapper = new LanguageMapper();
            var cityMapper = new CityMapper();
            var outputModel = new CityNameByLanguage
            {
                Id = objectToMap.Id,
                Name = objectToMap.Name,
                LanguagesItem = languageMapper.Map(objectToMap.LanguagesItem),
                CityItem = cityMapper.Map(objectToMap.CityItem)
            };
            return outputModel;
        }
    }
}
