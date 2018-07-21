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
	public class AirlineSubClassesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineSubClasses>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.AirlineSubClasses> de;

		public AirlineSubClassesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.AirlineSubClasses> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<AirlineSubClasses> Members

		public void Save(SBSWebProject.Data.Entities.AirlineSubClasses entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.AirlineSubClasses entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.AirlineSubClasses entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.AirlineSubClasses entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.AirlineSubClasses GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.AirlineSubClasses)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
