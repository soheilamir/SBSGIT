using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelCommentsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelComments>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelComments> de;

        public HotelCommentsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelComments> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelComments> Members

        public void Save(SBSWebProject.Data.Entities.HotelComments entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelComments entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelComments entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelComments entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelComments GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelComments)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
