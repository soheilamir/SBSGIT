using SBSWebProject.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IAirplaneMethod
    {
        void SaveAirplane(Airplane airplane);
        void UpdateAirplane(Airplane airplane);
        void DeleteAirplane(Airplane airplane);
        IList<Airplane> GetAirplanesData();
    }
}
