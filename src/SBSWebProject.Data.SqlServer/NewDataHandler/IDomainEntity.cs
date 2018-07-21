using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    interface IDomainEntity
    {
        void Save(Entity entity);
        IList GetEntityS();
        Entity GetEntityByID(long id);
        IList GetEntitySByState(int state);
        IList GetEntitySByParamsExactEqual(string hql, Dictionary<string, object> paramS);
        IList GetEntitySByParamS(string hql, Dictionary<string, object> paramS);
        void Delete(Entity entity);
        void DeleteByState(Entity entity);
        void Update(Entity entity);
        IList GetByExample(Entity exampleInstance, string[] propertiesToExclude);
        IList GetByExampleExactValue(Entity exampleInstance, string[] propertiesToExclude);
    }
}
