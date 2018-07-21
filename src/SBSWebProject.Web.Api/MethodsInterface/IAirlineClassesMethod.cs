using SBSWebProject.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IAirlineClassesMethod
    {
        void AddAirlineClass(AirlineClasses airlineClassModel);
        void EditAirlineClass(AirlineClasses airlineClassModel);
        void DeleteAirlineClass(AirlineClasses airlineClassModel);
    }
}
