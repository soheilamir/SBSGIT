using System;
using System.Collections.Generic;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using CompanySection = SBSWebProject.Web.Api.Models.CompanySection;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CompanySectionMapper : IMappingObject<Data.Entities.CompanySection, CompanySection>
    {
        public CompanySection Map(Data.Entities.CompanySection objectToMap)
        {
            if (objectToMap == null) return null;
            var companyMapper = new CompanyMapper();
            var companySectionMapper = new CompanySectionMapper();
            var outputModel = new CompanySection
            {
                Id = objectToMap.Id,
                CompanyItem = companyMapper.Map(objectToMap.CompanyItem),
                CompanySectionItem = companySectionMapper.Map(objectToMap.CompanySectionItem),
                SectionName = objectToMap.SectionName,

            };
            return outputModel;
        }
        private SBSWebProject.Web.Api.Models.ComboBox GetCountryNameByLangISO(IList<SBSWebProject.Data.Entities.CountryNameByLanguage> lstName, string isoLangName)
        {
            IList<SBSWebProject.Data.Entities.CountryNameByLanguage> lstResult = lstName.Where(c => c.State == 0 && c.LanguagesItem.ISO6391 == isoLangName).ToList();
            if (lstResult.Count > 0)
                return new SBSWebProject.Web.Api.Models.ComboBox { id = (int)lstResult[0].Id, name = lstResult[0].ContryName };
            return null;
        }
    }
}
