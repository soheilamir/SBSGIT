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
    public class CompanyDomainEntity : IDomainEntity<SBSWebProject.Data.Entities.Company>
    {
        private Type persitentType = typeof(Company);

        private readonly ISession _session;
        public CompanyDomainEntity(ISession session)
        {
            _session = session;
        }
        private ISession GetSession()
        {
            return _session;
        }

        #region IDomainEntity Members

        public void Delete(Company entity)
        {
            GetSession().Delete(entity);
        }

        public System.Collections.IList GetByExample(Company exampleInstance, string[] propertiesToExclude)
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

        public System.Collections.IList GetByExampleExactValue(Company exampleInstance, string[] propertiesToExclude)
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

        public Company GetEntityByID(long id)
        {
            ISession session = this.GetSession();
            return (Company)session.Load(persitentType, id);
        }

        public System.Collections.IList GetEntityS()
        {
            ISession session = this.GetSession();
            return session.CreateCriteria<Company>().List();

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


        public void Save(Company entity)
        {
            var tx = GetSession().BeginTransaction();
            _session.Save(entity);
            tx.Commit();
        }

        public void Update(Company entity)
        {
            ISession session = GetSession();
            var tx = session.BeginTransaction();
            GetSession().Merge(entity);
            tx.Commit();
        }

        public System.Collections.IList GetEntitySByState(int state)
        {
            ISession session = this.GetSession();
            return session.CreateCriteria<Company>().Add(Restrictions.Eq("State", state)).List();
        }

        public void DeleteByState(Company entity)
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
