using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBSWebProject.Web.Common;
using SBSWebProject.Web.Common.Routing;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Web.Api.MethodsInterface;
using System.IO;
using System.Data;
using Excel;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    public class LanguageController : ApiController
    {
        private readonly ILanguagesMethod _languagesMethod;

        public LanguageController(ILanguagesMethod languagesMethod)
        {
            _languagesMethod = languagesMethod;
        }

        [Route("languages/getAll")]
        [HttpGet]
        public IList<Languages> GetAllLanguages()
        {
            return _languagesMethod.GetAllLanguageModel();
        }
    }
}
