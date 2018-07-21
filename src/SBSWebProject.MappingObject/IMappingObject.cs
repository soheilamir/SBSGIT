using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.MappingObject
{
    public interface IMappingObject<in T, out TU>
    {
        TU Map(T objectToMap);
    }
}
