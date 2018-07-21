using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IAirlinesMethod
    {
        IList<Airlines> GetAirlinesData();
        void AddAirline(Airlines airline);
        void EditAirline(Airlines airline);
        void DeleteAirline(Airlines airline);
        IList<AirlineClasses> GetAirlineClassesByAirline(Airlines airlineModel);
        IList<AirlineSubClasses> GetAirlineSubClassesByAirline(Airlines airlineModel);
        IList<AirlineSubClasses> GetAirlineSubClassesByAirlineClass(AirlineClasses airlineClassesModel);
        Data.Entities.Airlines GetAirlineEntityByIataCode(string iataCode);
        Data.Entities.AirlineSubClasses GetAirlineSubClassEntityByName(Data.Entities.Airlines airlineEntity, string subClassName);
    }
}
