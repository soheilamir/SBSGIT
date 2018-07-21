using SBSWebProject.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IAirlineSubClassesMethod
    {
        void AddAirlineSubClass(AirlineSubClasses airlineSubClassModel);
        void EditAirlineSubClass(AirlineSubClasses airlineSubClassModel);
        void DeleteAirlineSubClass(AirlineSubClasses airlineSubClassModel);
        IList<AirlineSubClasses> GetAirlineSubClassesData();
    }
}
