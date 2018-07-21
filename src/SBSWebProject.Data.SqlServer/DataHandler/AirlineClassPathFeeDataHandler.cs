﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class AirlineClassPathFeeDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineClassPathFee>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.AirlineClassPathFee> de;

        public AirlineClassPathFeeDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.AirlineClassPathFee> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<AirlineClassPath> Members

        public void Save(SBSWebProject.Data.Entities.AirlineClassPathFee entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.AirlineClassPathFee entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.AirlineClassPathFee entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.AirlineClassPathFee entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.AirlineClassPathFee GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.AirlineClassPathFee)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
