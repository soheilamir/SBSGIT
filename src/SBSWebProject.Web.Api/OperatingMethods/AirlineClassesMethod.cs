using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.MethodsInterface;
using SBSWebProject.Data.DataHandlers;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.MappingObject;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class AirlineClassesMethod : IAirlineClassesMethod
    {
        private readonly IMappingObject<AirlineClasses, Data.Entities.AirlineClasses> _airlineClassesModelToEntity;
        private readonly IMappingObject<Data.Entities.AirlineClasses, AirlineClasses> _airlineClassesEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.AirlineClasses> _airlineClassesDataHandler;
        
        public AirlineClassesMethod(IBasicDataHandler<Data.Entities.AirlineClasses> airplaneClassesDataHandler,
            IMappingObject<AirlineClasses, Data.Entities.AirlineClasses> airlineClassesModelToEntity,
            IMappingObject<Data.Entities.AirlineClasses, AirlineClasses> airlineClassesEntityToModel)
        {
            _airlineClassesDataHandler = airplaneClassesDataHandler;
            _airlineClassesModelToEntity = airlineClassesModelToEntity;
            _airlineClassesEntityToModel = airlineClassesEntityToModel;
        }

        public void AddAirlineClass(AirlineClasses airlineClassModel)
        {
            _airlineClassesDataHandler.Save(_airlineClassesModelToEntity.Map(airlineClassModel));
        }
        public void EditAirlineClass(AirlineClasses airlineClassModel)
        {
            _airlineClassesDataHandler.Update(_airlineClassesModelToEntity.Map(airlineClassModel));
        }
        public void DeleteAirlineClass(AirlineClasses airlineClassModel)
        {
            _airlineClassesDataHandler.Delete(_airlineClassesModelToEntity.Map(airlineClassModel));
        }
        
    }
}