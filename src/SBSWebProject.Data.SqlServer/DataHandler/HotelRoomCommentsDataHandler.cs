using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelRoomCommentsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelRoomComments>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelRoomComments> de;

        public HotelRoomCommentsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelRoomComments> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelRoomComments> Members

        public void Save(SBSWebProject.Data.Entities.HotelRoomComments entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelRoomComments entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelRoomComments entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelRoomComments entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelRoomComments GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelRoomComments)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
