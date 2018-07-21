using NHibernate;
using NHibernate.Util;
using SBSWebProject.Common;
using SBSWebProject.Common.Security;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.Exceptions;
using SBSWebProject.Data.QueryProcessors;
using SBSWebProject.Data.DataHandlers;
using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace SBSWebProject.Data.SqlServer.DomainEntities
{
    public class WebsiteFAQsDomainEntity : IDomainEntity<SBSWebProject.Data.Entities.WebsiteFAQs>
    {
        private Type persitentType = typeof(WebsiteFAQs);

        private readonly ISession _session;
        public WebsiteFAQsDomainEntity(ISession session)
        {
            _session = session;
        }
        private ISession GetSession()
        {
            return _session;
        }

        #region IDomainEntity Members

        public void Delete(WebsiteFAQs entity)
        {
            GetSession().Delete(entity);
        }

        public System.Collections.IList GetByExample(WebsiteFAQs exampleInstance, string[] propertiesToExclude)
        {
            ISession session = GetSession();
            ICriteria criteria = session.CreateCriteria(persitentType);
            Example example = Example.Create(exampleInstance);


            if (propertiesToExclude != null)
            {
                foreach (string propertyToExclude in propertiesToExclude)
                {
                    example.ExcludeProperty(propertyToExclude);
                }
            }
            example.EnableLike(MatchMode.Anywhere);
            criteria.Add(example);

            return criteria.List();
        }

        public System.Collections.IList GetByExampleExactValue(WebsiteFAQs exampleInstance, string[] propertiesToExclude)
        {
            ISession session = GetSession();
            ICriteria criteria = session.CreateCriteria(persitentType);
            Example example = Example.Create(exampleInstance);


            if (propertiesToExclude != null)
            {
                foreach (string propertyToExclude in propertiesToExclude)
                {
                    example.ExcludeProperty(propertyToExclude);
                }
            }
            criteria.Add(example);

            return criteria.List();
        }

        public WebsiteFAQs GetEntityByID(long id)
        {
            ISession session = this.GetSession();
            return (WebsiteFAQs)session.Load(persitentType, id);
        }

        public System.Collections.IList GetEntityS()
        {
            ISession session = this.GetSession();
            return session.CreateCriteria<WebsiteFAQs>().List();

        }

        /// <summary>
        /// This method gets select Query without where clouse and Params and find exactly
        /// the results with "=".
        /// </summary>
        public System.Collections.IList GetEntitySByParamsExactEqual(string hql, Dictionary<string, object> paramS)
        {
            ISession session = this.GetSession();
            string qr = hql;
            qr += " Where ";

            foreach (var parameter in paramS)
            {
                qr += String.Format("{0}= :{0}", parameter.Key);
            }



            var query = session.CreateQuery(qr);

            foreach (var parameter in paramS)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }
            return query.List();
        }

        /// <summary>
        /// This method gets select Query with where clouse and Params and find 
        /// the results
        /// </summary>
        public System.Collections.IList GetEntitySByParamS(string hql, Dictionary<string, object> paramS)
        {
            ISession session = this.GetSession();
            string qr = hql;

            var query = session.CreateQuery(qr);

            foreach (var parameter in paramS)
            {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            return query.List();
        }


        public void Save(WebsiteFAQs entity)
        {
            var tx = GetSession().BeginTransaction();
            _session.Save(entity);
            tx.Commit();
        }

        public void Update(WebsiteFAQs entity)
        {
            ISession session = GetSession();
            var tx = session.BeginTransaction();
            GetSession().Merge(entity);
            tx.Commit();
        }

        public System.Collections.IList GetEntitySByState(int state)
        {
            ISession session = this.GetSession();
            return session.CreateCriteria<WebsiteFAQs>().Add(Restrictions.Eq("State", state)).List();
        }

        public void DeleteByState(WebsiteFAQs entity)
        {
            entity.State = 1;
            ISession session = GetSession();
            var tx = session.BeginTransaction();
            GetSession().Merge(entity);
            tx.Commit();
        }
        #endregion
    }
}
