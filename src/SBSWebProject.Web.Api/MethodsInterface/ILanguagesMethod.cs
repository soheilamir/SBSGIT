using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageModel = SBSWebProject.Web.Api.Models.Languages;
using LanguageEntity = SBSWebProject.Data.Entities.Languages;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface ILanguagesMethod
    {
        LanguageEntity GetLanguageEntityByCode(string languageCode);
        LanguageModel GetLanguageModelByCode(string languageCode);
        IList<LanguageModel> GetAllLanguageModel();
    }
}
