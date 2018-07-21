using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.MappingObject;
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class AirplaneMethod : IAirplaneMethod
    {
        private readonly IMappingObject<Airplane, Data.Entities.Airplane> _airplaneModelToEntity;
        private readonly IMappingObject<Data.Entities.Airplane, Airplane> _airplaneEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.Airplane> _airplaneDataHandler;
        public AirplaneMethod(IMappingObject<Airplane, Data.Entities.Airplane> airplaneModelToEntity,
            IMappingObject<Data.Entities.Airplane, Airplane> airplaneEntityToModel,
            IBasicDataHandler<Data.Entities.Airplane> airplaneDataHandler)
        {
            _airplaneModelToEntity = airplaneModelToEntity;
            _airplaneDataHandler = airplaneDataHandler;
            _airplaneEntityToModel = airplaneEntityToModel;
        }
        public void SaveAirplane(Airplane airplane)
        {
            _airplaneDataHandler.Save(_airplaneModelToEntity.Map(airplane));
        }
        public void UpdateAirplane(Airplane airplane)
        {
            _airplaneDataHandler.Update(_airplaneModelToEntity.Map(airplane));
        }
        public void DeleteAirplane(Airplane airplane)
        {
            _airplaneDataHandler.Delete(_airplaneModelToEntity.Map(airplane));
        }
        public IList<Airplane> GetAirplanesData()
        {
            return _airplaneDataHandler.SelectAll().Cast<Data.Entities.Airplane>().Select(item => _airplaneEntityToModel.Map(item)).ToList();
        }
    }
}