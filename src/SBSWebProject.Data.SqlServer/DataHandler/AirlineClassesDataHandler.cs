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
	public class AirlineClassesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineClasses>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.AirlineClasses> de;

		public AirlineClassesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.AirlineClasses> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<AirlineClasses> Members

		public void Save(SBSWebProject.Data.Entities.AirlineClasses entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.AirlineClasses entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.AirlineClasses entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.AirlineClasses entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.AirlineClasses GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.AirlineClasses)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
