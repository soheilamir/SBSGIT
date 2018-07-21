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
    public class HotelRoomTypeNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage> de;

        public HotelRoomTypeNameByLanguageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage>(this.sessionFactory);
        }

        #region IBasicDataHandler<HotelRoomTypeNameByLanguage> Members

        public void Save(SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelRoomTypeNameByLanguage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
