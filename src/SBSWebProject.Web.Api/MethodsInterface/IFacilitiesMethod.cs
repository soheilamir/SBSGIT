using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IFacilitiesMethod
    {
        FacilitiesCategory AddFacilitiesCategory(FacilitiesCategory facilitiesCategoryModel);
        FacilitiesCategory EditFacilitiesCategory(FacilitiesCategory facilitiesCategoryModel);
        void DeleteFacilitiesCategory(FacilitiesCategory facilitiesCategoryModel);
        IList<FacilitiesCategory> GetAllFacilitiesCategory();
        #region FacilitiesSection
        Facilities AddFacilities(Facilities facilitiesModel);
        IList<Facilities> GetAllFacilities();
        #endregion
    }
}
