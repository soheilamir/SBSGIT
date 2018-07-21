using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.DataHandlers
{
    public interface IDomainEntity<T>
    {
        void Save(T entity);
        IList GetEntityS();
        T GetEntityByID(long id);
        IList GetEntitySByState(int state);
        IList GetEntitySByParamsExactEqual(string hql, Dictionary<string, object> paramS);
        IList GetEntitySByParamS(string hql, Dictionary<string, object> paramS);
        void Delete(T entity);
        void DeleteByState(T entity);
        void Update(T entity);
        IList GetByExample(T exampleInstance, string[] propertiesToExclude);
        IList GetByExampleExactValue(T exampleInstance, string[] propertiesToExclude);
    }
}
