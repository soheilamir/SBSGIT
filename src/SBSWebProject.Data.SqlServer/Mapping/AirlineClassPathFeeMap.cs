using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlineClassPathFeeMap : VersionedClassMap<AirlineClassPathFee>
    {
        public AirlineClassPathFeeMap()
        {
            Table("AirlineClassPathFee");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.AirlineClassPathItem).Column("AIRLINE_CLASS_PATH_ID");
            Map(x => x.AdultFee).Column("ADULT_FEE");
            Map(x => x.ChildFee).Column("CHILD_FEE");
            Map(x => x.InfantFee).Column("INFANT_FEE");
            Map(x => x.IsActive).Column("IS_ACTIVE");
            Map(x => x.RegisterDate).Column("REGISTER_DATE");
            HasMany(x => x.OnlineFlightTicketPathS).KeyColumn("AIRLINE_CLASS_PATH_FEE_ID");
        }
    }
}
