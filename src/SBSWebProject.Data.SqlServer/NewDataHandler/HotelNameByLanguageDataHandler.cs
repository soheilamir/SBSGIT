﻿using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class HotelNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelNameByLanguage>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.HotelNameByLanguage> de;

        public HotelNameByLanguageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.HotelNameByLanguage>(this.sessionFactory);
        }

        #region IBasicDataHandler<HotelNameByLanguage> Members

        public void Save(SBSWebProject.Data.Entities.HotelNameByLanguage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelNameByLanguage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelNameByLanguage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelNameByLanguage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelNameByLanguage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelNameByLanguage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
