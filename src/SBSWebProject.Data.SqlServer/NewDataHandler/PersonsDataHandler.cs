using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
	public class PersonsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Persons>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Persons> de;

        public PersonsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Persons>(this.sessionFactory);
        }

        #region IBasicDataHandler<Persons> Members

        public void Save(SBSWebProject.Data.Entities.Persons entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Persons entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Persons entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Persons entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Persons GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Persons)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
