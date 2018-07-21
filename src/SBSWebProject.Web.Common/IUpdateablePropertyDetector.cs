using System.Collections.Generic;

namespace SBSWebProject.Web.Common
{
    public interface IUpdateablePropertyDetector
    {
        IEnumerable<string> GetNamesOfPropertiesToUpdate<TTargetType>(
        object objectContainingUpdatedData);
    }
}
