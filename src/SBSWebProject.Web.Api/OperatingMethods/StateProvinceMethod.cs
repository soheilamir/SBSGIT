using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Data.DataHandlers;
using System.Text.RegularExpressions;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class StateProvinceMethod : IStateProvinceMethod
    {
        private readonly IBasicDataHandler<Data.Entities.Country> _countryDataHandler;
        private readonly IBasicDataHandler<Data.Entities.StateProvince> _stateDataHandler;
        private readonly IBasicDataHandler<Data.Entities.StateProvinceNameByLanguage> _stateNameByLangDataHandler;
        public StateProvinceMethod(IBasicDataHandler<Data.Entities.Country> countryDataHandler,
            IBasicDataHandler<Data.Entities.StateProvince> stateDataHandler,
            IBasicDataHandler<Data.Entities.StateProvinceNameByLanguage> stateNameByLangDataHandler)
        {
            _stateDataHandler = stateDataHandler;
            _stateNameByLangDataHandler = stateNameByLangDataHandler;
            _countryDataHandler = countryDataHandler;
        }
        public void AddStateProvinceFromExcel(IList<ExcelReaderState> stateList)
        {
            var regex = new Regex("[a-zA-Z0-9 ]*");
            //List<long> lstId = new List<long>();
            //string str = "";
            foreach (var state in stateList)
            {
                Data.Entities.StateProvince stateProvinceObj = new Data.Entities.StateProvince
                {
                    CountryItem = _countryDataHandler.GetEntity(Convert.ToInt64(state.Country)),
                    CharCode = state.StateCode,
                };
                _stateDataHandler.Save(stateProvinceObj);
                Data.Entities.StateProvinceNameByLanguage stateProvinceNameObj = new Data.Entities.StateProvinceNameByLanguage
                {
                    LanguagesItem = new Data.Entities.Languages { Id = 2 },
                    StateProvinceItem = stateProvinceObj,
                    StateProvinceName = state.Name
                };
                _stateNameByLangDataHandler.Save(stateProvinceNameObj);
                //if (!regex.IsMatch(stateProvinceNameObj.StateProvinceName))
                //{
                //    lstId.Add(stateProvinceNameObj.Id);
                //    str += stateProvinceNameObj.Id + " , ";
                //}
            }
        }

        public StateProvince GetStateProvinceById(long id)
        {
            throw new NotImplementedException();
        }
    }
}