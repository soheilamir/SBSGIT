using SBSWebProject.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IStateProvinceMethod
    {
        void AddStateProvinceFromExcel(IList<ExcelReaderState> state);
        StateProvince GetStateProvinceById(long id);

    }
}
