using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Cors;
using SBSWebProject.Common;
using SBSWebProject.Web.Api.InquiryProcessing;
using SBSWebProject.Web.Api.MaintenanceProcessing;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Web.Common;
using SBSWebProject.Web.Common.Routing;
using SBSWebProject.Web.Common.Validation;
using System.Security.Claims;
using SBSWebProject.Hubs;
using Microsoft.AspNet.SignalR.Client;
using System;
using SBSWebProject.Web.Api.OperatingMethods;
using SBSWebProject.Web.Api.MethodsInterface;
using System.IO;
using System.Data;
using Excel;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    public class BaseInfoController : ApiController
    {
        private readonly ILanguagesMethod _languagesMethod;
        private readonly ICountryMethod _countryMethod;
        private readonly ICountryNameByLanguageMethod _countryNameByLanguageMethod;
        private readonly IAirlinesMethod _airlinesMethod;
        private readonly IAirplaneMethod _airplaneMethod;
        private readonly IAirlineClassesMethod _airlineClassesMethod;
        private readonly IAirlineSubClassesMethod _airlineSubClassesMethod;
        private readonly IStateProvinceMethod _stateProvinceMethod;
        public BaseInfoController(ICountryMethod countryMethod,
            ICountryNameByLanguageMethod countryNameByLanguageMethod,
            ILanguagesMethod languagesMethod, IAirlinesMethod airlinesMethod,
            IAirplaneMethod airplaneMethod,
            IAirlineClassesMethod airlineClassesMethod,
            IAirlineSubClassesMethod airlineSubClassesMethod,
            IStateProvinceMethod stateProvinceMethod)
        {
            _countryMethod = countryMethod;
            _countryNameByLanguageMethod = countryNameByLanguageMethod;
            _languagesMethod = languagesMethod;
            _airlinesMethod = airlinesMethod;
            _airplaneMethod = airplaneMethod;
            _airlineClassesMethod = airlineClassesMethod;
            _airlineSubClassesMethod = airlineSubClassesMethod;
            _stateProvinceMethod = stateProvinceMethod;
        }


        #region Country State/Province City Actions

        [Route("AddCountriesFromExcle")]
        [HttpPost]
        public void AddCountriesFromExcle(ExcelReaderCountry newCountry)
        {
            string filePath = @"D:\Country.xlsx";
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //DataSet result = excelReader.AsDataSet();
            //...
            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods

            SBSWebProject.Data.Entities.Languages lang = _languagesMethod.GetLanguageEntityByCode("FA");


            // _countryMethod.AddCountry(newCountry, newCountryName);
            int cnt = 0;
            while (excelReader.Read())
            {
                if (cnt++ == 0) continue;
                ExcelReaderCountry _newCountry = new ExcelReaderCountry
                {
                    DialingCode = excelReader.GetString(4),
                    IsoCode = excelReader.GetString(1),
                    UnCode = excelReader.GetString(2),
                    UnNum = excelReader.GetString(3),

                };
                SBSWebProject.Data.Entities.CountryNameByLanguage newCountryName = new SBSWebProject.Data.Entities.CountryNameByLanguage
                {
                    LanguagesItem = lang,
                    ContryName = excelReader.GetString(0),
                };
                _countryMethod.AddCountry(_newCountry, newCountryName);
                cnt++;
                //excelReader.GetInt32(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
        }

        [Route("AddStateFromXml")]
        [HttpPost]
        public void AddStateFromXml(ExcelReaderCountry newCountry)
        {
            string filePath = @"D:\States.xlsx";

            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            //...
            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //...
            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            //DataSet result = excelReader.AsDataSet();
            //...
            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods

            SBSWebProject.Data.Entities.Languages lang = _languagesMethod.GetLanguageEntityByCode("FA");


            // _countryMethod.AddCountry(newCountry, newCountryName);
            int cnt = 0;
            IList<ExcelReaderState> StateList = new List<ExcelReaderState>();
            while (excelReader.Read())
            {
                if (cnt++ == 0) continue;
                ExcelReaderState _newState = new ExcelReaderState
                {
                    Name = excelReader.GetString(0),
                    StateCode = excelReader.GetString(1),
                    Country = excelReader.GetString(2)

                };
                StateList.Add(_newState);
                cnt++;
                //excelReader.GetInt32(0);
            }
            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            _stateProvinceMethod.AddStateProvinceFromExcel(StateList);
        }

        [Route("GetCountriesByLangIso")]
        [HttpGet]
        public IList<SBSWebProject.Web.Api.Models.Country> GetCountriesByInternationalIso()
        {
            return _countryMethod.GetInternationalCountriesList();
        }

        [Route("GetInternationalStateProvinceByCountry")]
        [HttpPost]
        public IList<SBSWebProject.Web.Api.Models.StateProvince> GetInternationalStateProvinceByCountry(long countryId = 1)
        {
            IList<SBSWebProject.Web.Api.Models.StateProvince> lst = _countryMethod.GetInternationalStateByCountry(countryId);
            return _countryMethod.GetInternationalStateByCountry(countryId);
        }

        [Route("GetInternationalCityByState")]
        [HttpPost]
        public IList<SBSWebProject.Web.Api.Models.City> GetInternationalCityByState(long stateId = 1)
        {
            IList<SBSWebProject.Web.Api.Models.City> lst = _countryMethod.GetInternationalCityByState(stateId);
            return _countryMethod.GetInternationalCityByState(stateId);
        }

        #endregion

        #region Airplane Actions
        [Route("airplane/add")]
        [HttpPost]
        public void AddAirplane(Airplane airplane)
        {
            _airplaneMethod.SaveAirplane(airplane);
        }
        [Route("airplane/edit")]
        [HttpPost]
        public void EditAirplane(Airplane airplane)
        {
            _airplaneMethod.UpdateAirplane(airplane);
        }
        [Route("airplane/dekete")]
        [HttpDelete]
        public void DeleteAirplane(Airplane airplane)
        {
            _airplaneMethod.DeleteAirplane(airplane);
        }
        [Route("airplane/getAirplanesData")]
        [HttpGet]
        public IList<Airplane> GetAirplaneData()
        {
            return _airplaneMethod.GetAirplanesData();
        }
        #endregion

        #region Airlines Actions
        [Route("airline/add")]
        [HttpPost]
        public void AddAirline(Airlines airline)
        {
            _airlinesMethod.AddAirline(airline);
        }
        [Route("airline/edit")]
        [HttpPost]
        public void EditAirline(Airlines airline)
        {
            _airlinesMethod.EditAirline(airline);
        }
        [Route("airline/delete")]
        [HttpDelete]
        public void DeleteAirline(Airlines airline)
        {
            _airlinesMethod.DeleteAirline(airline);
        }
        [Route("airline/getAirlinesData")]
        [HttpGet]
        public IList<Airlines> GetAirlinesData()
        {
            return _airlinesMethod.GetAirlinesData();
        }
        [Route("airline/getAirlineClassesByAirline")]
        [HttpGet]
        public IList<AirlineClasses> GetAirlineClassesByAirline(Airlines airlineModel)
        {
            return _airlinesMethod.GetAirlineClassesByAirline(airlineModel);
        }
        [Route("airline/getAirlineSubClassesByAirline")]
        [HttpGet]
        public IList<AirlineSubClasses> GetAirlineSubClassesByAirline(Airlines airlineModel)
        {
            return _airlinesMethod.GetAirlineSubClassesByAirline(airlineModel);
        }
        [Route("airline/getAirlineSubClassesByAirlineClass")]
        [HttpGet]
        public IList<AirlineSubClasses> GetAirlineSubClassesByAirlineClass(AirlineClasses airlineClassModel)
        {
            return _airlinesMethod.GetAirlineSubClassesByAirlineClass(airlineClassModel);
        }
        #endregion

        #region AirlineClasses Action
        [Route("airlineClass/add")]
        [HttpPost]
        public void AddAirlineClass(AirlineClasses airlineClass)
        {
            _airlineClassesMethod.AddAirlineClass(airlineClass);
        }
        [Route("airlineClass/edit")]
        [HttpPost]
        public void EditAirlineClass(AirlineClasses airlineClass)
        {
            _airlineClassesMethod.EditAirlineClass(airlineClass);
        }
        [Route("airlineClass/delete")]
        [HttpDelete]
        public void DeleteAirlineClass(AirlineClasses airlineClass)
        {
            _airlineClassesMethod.DeleteAirlineClass(airlineClass);
        }

        #endregion

        #region AirlineSubClasses Action
        [Route("airlineSubClass/add")]
        [HttpPost]
        public void AddAirlineSubClass(AirlineSubClasses airlineSubClass)
        {
            _airlineSubClassesMethod.AddAirlineSubClass(airlineSubClass);
        }
        [Route("airlineSubClass/edit")]
        [HttpPost]
        public void EditAirlineSubClass(AirlineSubClasses airlineSubClass)
        {
            _airlineSubClassesMethod.EditAirlineSubClass(airlineSubClass);
        }
        [Route("airlineSubClass/delete")]
        [HttpDelete]
        public void DeleteAirlineSubClass(AirlineSubClasses airlineSubClass)
        {
            _airlineSubClassesMethod.DeleteAirlineSubClass(airlineSubClass);
        }

        #endregion

        #region FlightPath Actions
        [Route("flightPath/add")]
        [HttpPost]
        public void AddFlightPath(FlightPath flightPathModel)
        {
            // _airlineSubClassesMethod.AddAirlineSubClass(flightPathModel);
        }
        [Route("flightPath/edit")]
        [HttpPost]
        public void EditFlightPath(FlightPath flightPathModel)
        {
            // _airlineSubClassesMethod.EditAirlineSubClass(flightPathModel);
        }
        [Route("flightPath/delete")]
        [HttpDelete]
        public void DeleteFlightPath(FlightPath flightPathModel)
        {
            //_airlineSubClassesMethod.DeleteAirlineSubClass(flightPathModel);
        }
        #endregion
    }
}
