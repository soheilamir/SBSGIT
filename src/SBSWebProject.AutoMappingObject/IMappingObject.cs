using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.AutoMappingObject
{
    public interface IMappingObject<in T, out TU>
    {
        TU Map(T objectToMap);
    }
}
