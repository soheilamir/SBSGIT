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
	public class CompanyAttachmentDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CompanyAttachment>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.CompanyAttachment> de;

		public CompanyAttachmentDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CompanyAttachment> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<CompanyAttachment> Members

		public void Save(SBSWebProject.Data.Entities.CompanyAttachment entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.CompanyAttachment entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.CompanyAttachment entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.CompanyAttachment entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.CompanyAttachment GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.CompanyAttachment)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
