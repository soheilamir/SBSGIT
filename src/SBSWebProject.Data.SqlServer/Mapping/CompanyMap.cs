using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class CompanyMap : VersionedClassMap<Company>
    {
        public CompanyMap()
        {
            Table("Company");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            Map(x => x.CompanyName).Column("COMPANY_NAME");
            Map(x => x.ContractNumber).Column("CONTRACT_NUMBER");
            Map(x => x.Address).Column("ADDRESS");
            Map(x => x.Tel).Column("TEL");
            Map(x => x.Fax).Column("FAX");
            Map(x => x.StartCooperation).Column("START_COOPERATION");
            Map(x => x.EndCooperation).Column("END_COOPERATION");
            Map(x => x.RegisterDate).Column("REGISTER_DATE");
            Map(x => x.CreditDay).Column("CREDIT_DAY");
            Map(x => x.CreditFee).Column("CREDIT_FEE");
            Map(x => x.DepositPercent).Column("DEPOSIT_PERCENT");
            Map(x => x.HasAttachment).Column("HAS_ATTACHMENT");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.CompanyAttachmentS).KeyColumn("COMPANY_ID");
            HasMany(x => x.CompanyEmployeeS).KeyColumn("COMPANY_ID");
            HasMany(x => x.CompanyServiceFeeS).KeyColumn("COMPANY_ID");
            HasMany(x => x.OrdersS).KeyColumn("COMPANY_ID");
        }
    }
}
