using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.MappingObject;
using SBSWebProject.Data.DataHandlers;
using AirlineModel = SBSWebProject.Web.Api.Models.Airlines;
using AirlineEntity = SBSWebProject.Data.Entities.Airlines;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class AirlinesMethod : IAirlinesMethod
    {
        private readonly IMappingObject<Data.Entities.AirlineSubClasses, AirlineSubClasses> _airlineSubClassesEntityToModel;
        private readonly IMappingObject<Data.Entities.AirlineClasses, AirlineClasses> _airlineClassesEntityToModel;
        private readonly IMappingObject<AirlineModel, AirlineEntity> _airlineModelToEntity;
        private readonly IMappingObject<AirlineEntity, AirlineModel> _airlineEntityToModel;
        private readonly IMappingObject<FlightCondition, Data.Entities.FlightCondition> _flightConditionModelToEntity;
        private readonly IMappingObject<ConditionValues, Data.Entities.ConditionValues> _conditionValuesModelToEntity;
        private readonly IBasicDataHandler<AirlineEntity> _airlineHandler;
        private readonly IBasicDataHandler<Data.Entities.FlightCondition> _flightConditionHandler;
        private readonly IBasicDataHandler<Data.Entities.ConditionValues> _conditionValuesHandler;
        private readonly IBasicDataHandler<Data.Entities.AirlineClasses> _airlineClassesHandler;
        private readonly IBasicDataHandler<Data.Entities.AirlineSubClasses> _airlineSubClassesHandler;

        public AirlinesMethod(IMappingObject<Data.Entities.AirlineSubClasses, AirlineSubClasses> airlineSubClassesEntityToModel,
            IMappingObject<Data.Entities.AirlineClasses, AirlineClasses> airlineClassesEntityToModel,
            IMappingObject<AirlineModel, AirlineEntity> airlineModelToEntity,
            IMappingObject<AirlineEntity, AirlineModel> airlineEntityToModel,
            IMappingObject<FlightCondition, Data.Entities.FlightCondition> flightConditionModelToEntity,
            IMappingObject<ConditionValues, Data.Entities.ConditionValues> conditionValuesModelToEntity,
            IBasicDataHandler<AirlineEntity> airlineHandler,
            IBasicDataHandler<Data.Entities.FlightCondition> flightConditionHandler,
            IBasicDataHandler<Data.Entities.ConditionValues> conditionValuesHandler,
            IBasicDataHandler<Data.Entities.AirlineClasses> airlineClassesHandler,
            IBasicDataHandler<Data.Entities.AirlineSubClasses> airlineSubClassesHandler)
        {
            _airlineSubClassesEntityToModel = airlineSubClassesEntityToModel;
            _airlineClassesEntityToModel = airlineClassesEntityToModel;
            _airlineModelToEntity = airlineModelToEntity;
            _airlineEntityToModel = airlineEntityToModel;
            _airlineHandler = airlineHandler;
            _flightConditionModelToEntity = flightConditionModelToEntity;
            _flightConditionHandler = flightConditionHandler;
            _conditionValuesModelToEntity = conditionValuesModelToEntity;
            _conditionValuesHandler = conditionValuesHandler;
            _airlineClassesHandler = airlineClassesHandler;
            _airlineSubClassesHandler = airlineSubClassesHandler;
        }
        #region Airline Method
        public void AddAirline(AirlineModel airline)
        {
            _airlineHandler.Save(_airlineModelToEntity.Map(airline));
        }
        public void EditAirline(AirlineModel airline)
        {
            _airlineHandler.Update(_airlineModelToEntity.Map(airline));
        }
        public void DeleteAirline(AirlineModel airline)
        {
            _airlineHandler.Delete(_airlineModelToEntity.Map(airline));
        }
        public Data.Entities.Airlines GetAirlineEntityByIataCode(string iataCode)
        {
            List<Data.Entities.Airlines> lst = _airlineHandler.SelectAll().Cast<Data.Entities.Airlines>().Where(c => c.IataCode == iataCode).ToList();
            if (lst.Count > 0)
                return lst[0];
            else
                return null;
        }


        public IList<AirlineModel> GetAirlinesData()
        {
            IList<AirlineEntity> lstAirlineEntities = _airlineHandler.SelectAll().Cast<AirlineEntity>().ToList();
            //return lstAirlineEntities;
            return lstAirlineEntities.Select(item => _airlineEntityToModel.Map(item)).Select(item => item).ToList();
            //return _airlineDataHandler.SelectAll().Cast<AirlineModel>().ToList();
        }
        public IList<AirlineClasses> GetAirlineClassesByAirline(Airlines airlineModel)
        {
            return _airlineHandler.GetEntity(airlineModel.Id).AirlineClassesS.Where(c => c.State == 0).Select(item => _airlineClassesEntityToModel.Map(item)).ToList();
        }
        public IList<AirlineSubClasses> GetAirlineSubClassesByAirline(Airlines airlineModel)
        {
            return _airlineHandler.GetEntity(airlineModel.Id).AirlineSubClassesS.Where(c => c.State == 0).Select(item => _airlineSubClassesEntityToModel.Map(item)).ToList();
        }
        public IList<AirlineSubClasses> GetAirlineSubClassesByAirlineClass(AirlineClasses airlineClassesModel)
        {
            return _airlineClassesHandler.GetEntity(airlineClassesModel.Id).AirlineSubClassesS.Where(c => c.State == 0).Select(item => _airlineSubClassesEntityToModel.Map(item)).ToList();
        }

        public Data.Entities.AirlineSubClasses GetAirlineSubClassEntityByName(Data.Entities.Airlines airlineEntity, string subClassName)
        {
            IList<Data.Entities.AirlineSubClasses> subClassList = _airlineSubClassesHandler.SelectAll().Cast<Data.Entities.AirlineSubClasses>().Where(c => c.AirlineClassesItem.AirlineItem.Id == airlineEntity.Id && c.AirlineSubClassName == subClassName).ToList();
            if (subClassList.Count > 0)
                return subClassList[0];
            else
                return null;
        }

        #endregion

        #region Flight Condition Method

        public FlightCondition AddFlightCondition(ConditionType conditionType, FlightCondition flightCondition)
        {
            Data.Entities.FlightCondition flightConditionEntity = _flightConditionModelToEntity.Map(flightCondition);
            _flightConditionHandler.Save(flightConditionEntity);
            foreach (var item in flightCondition.ConditionValuesS)
            {
                Data.Entities.ConditionValues conditionValueEntity = _conditionValuesModelToEntity.Map(item);
                conditionValueEntity.FlightConditionItem = flightConditionEntity;
                _conditionValuesHandler.Save(conditionValueEntity);
            }
            return null;
        }


        #endregion
    }
}