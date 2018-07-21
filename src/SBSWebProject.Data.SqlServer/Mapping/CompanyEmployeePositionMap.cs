using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
   public class CompanyEmployeePositionMap: VersionedClassMap<CompanyEmployeePosition>
    {
        public CompanyEmployeePositionMap()
        {
            Table("CompanyEmployeePosition");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.PositionName).Column("POSITION_NAME");
            HasMany(x => x.CompanyEmployeeS).KeyColumn("POSITION_ID");
        }
    }
}
