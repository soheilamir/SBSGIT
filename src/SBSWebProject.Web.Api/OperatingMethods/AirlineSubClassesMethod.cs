using SBSWebProject.Data.DataHandlers;
using SBSWebProject.MappingObject;
using SBSWebProject.Web.Api.MethodsInterface;
using SBSWebProject.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class AirlineSubClassesMethod : IAirlineSubClassesMethod
    {
        private readonly IMappingObject<AirlineSubClasses, Data.Entities.AirlineSubClasses> _airlineSubClassesModelToEntity;
        private readonly IMappingObject<Data.Entities.AirlineSubClasses, AirlineSubClasses> _airlineSubClassesEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.AirlineSubClasses> _airlineSubClassesDataHandler;
        public AirlineSubClassesMethod(IMappingObject<AirlineSubClasses, Data.Entities.AirlineSubClasses> airlineSubClassesModelToEntity,
            IMappingObject<Data.Entities.AirlineSubClasses, AirlineSubClasses> airlineSubClassesEntityToModel,
            IBasicDataHandler<Data.Entities.AirlineSubClasses> airlineSubClassesDataHandler)
        {
            _airlineSubClassesModelToEntity = airlineSubClassesModelToEntity;
            _airlineSubClassesEntityToModel = airlineSubClassesEntityToModel;
            _airlineSubClassesDataHandler = airlineSubClassesDataHandler;
        }
        public void AddAirlineSubClass(AirlineSubClasses airlineSubClassModel)
        {
            _airlineSubClassesDataHandler.Save(_airlineSubClassesModelToEntity.Map(airlineSubClassModel));
        }
        public void EditAirlineSubClass(AirlineSubClasses airlineSubClassModel)
        {
            _airlineSubClassesDataHandler.Update(_airlineSubClassesModelToEntity.Map(airlineSubClassModel));
        }
        public void DeleteAirlineSubClass(AirlineSubClasses airlineSubClassModel)
        {
            _airlineSubClassesDataHandler.Delete(_airlineSubClassesModelToEntity.Map(airlineSubClassModel));
        }
        public IList<AirlineSubClasses> GetAirlineSubClassesData()
        {
            return _airlineSubClassesDataHandler.SelectAll().Cast<Data.Entities.AirlineSubClasses>().Select(item => _airlineSubClassesEntityToModel.Map(item)).ToList();
        }
    }
}