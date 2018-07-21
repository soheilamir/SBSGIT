using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.DataHandlers
{
    public interface IBasicDataHandler<T>
    {
        void Save(T entity);
        void Delete(T entity);
        void Update(T entity);
        IList Search(T entity);
        T GetEntity(long id);
        IList SelectAll();
    }
}
