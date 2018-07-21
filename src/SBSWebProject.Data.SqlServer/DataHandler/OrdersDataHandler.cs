using System; 
using System.Collections.Generic; 
using System.Collections; 
using System.Linq; 
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
	public class OrdersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Orders>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Orders> de;

		public OrdersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Orders> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Orders> Members

		public void Save(SBSWebProject.Data.Entities.Orders entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Orders entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Orders entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Orders entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Orders GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Orders)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
