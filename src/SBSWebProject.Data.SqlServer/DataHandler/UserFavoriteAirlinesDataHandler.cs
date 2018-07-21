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
	public class UserFavoriteAirlinesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserFavoriteAirlines>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.UserFavoriteAirlines> de;

		public UserFavoriteAirlinesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.UserFavoriteAirlines> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<UserFavoriteAirlines> Members

		public void Save(SBSWebProject.Data.Entities.UserFavoriteAirlines entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.UserFavoriteAirlines entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.UserFavoriteAirlines entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.UserFavoriteAirlines entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.UserFavoriteAirlines GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.UserFavoriteAirlines)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
