using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using Persons = SBSWebProject.Web.Api.Models.Persons;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    class PersonsMapper : IMappingObject<Data.Entities.Persons, Persons>
    {
        public Persons Map(Data.Entities.Persons objectToMap)
        {
            if (objectToMap == null) return null;
            //var airlineMapper = new AirlineMapper();
            //var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new Persons
            {
                Id = objectToMap.Id,

                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
