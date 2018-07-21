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
    public class FlightPathMethod : IFlightPathMethod
    {
        private readonly IMappingObject<FlightPath, Data.Entities.FlightPath> _flightPathModelToEntity;
        private readonly IMappingObject<Data.Entities.FlightPath, FlightPath> _flightPathEntityToModel;
        private readonly IBasicDataHandler<Data.Entities.FlightPath> _flightPathDataHandler;
        public FlightPathMethod(IMappingObject<FlightPath, Data.Entities.FlightPath> flightPathModelToEntity,
            IMappingObject<Data.Entities.FlightPath, FlightPath> flightPathEntityToModel,
            IBasicDataHandler<Data.Entities.FlightPath> flightPathDataHandler)
        {
            _flightPathModelToEntity = flightPathModelToEntity;
            _flightPathEntityToModel = flightPathEntityToModel;
            _flightPathDataHandler = flightPathDataHandler;
        }
        public void SaveFlightPath(FlightPath flightPathModel)
        {
            _flightPathDataHandler.Save(_flightPathModelToEntity.Map(flightPathModel));
        }
        public void UpdateFlightPath(FlightPath flightPathModel)
        {
            _flightPathDataHandler.Update(_flightPathModelToEntity.Map(flightPathModel));
        }
        public void DeleteFlightPath(FlightPath flightPathModel)
        {
            _flightPathDataHandler.Delete(_flightPathModelToEntity.Map(flightPathModel));
        }
        public Data.Entities.FlightPath GetFlightPathEntity(City source, City destination)
        {
            List<Data.Entities.FlightPath> lst = _flightPathDataHandler.SelectAll().Cast<Data.Entities.FlightPath>().Where(c => c.SourceCityItem.Id == source.Id && c.DestinationCityItem.Id == destination.Id).ToList();
            if (lst.Count > 0)
                return lst[0];
            else
                return null;
        }
    }
}