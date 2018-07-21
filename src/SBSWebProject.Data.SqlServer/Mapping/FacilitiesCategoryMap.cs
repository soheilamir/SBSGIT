using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FacilitiesCategoryMap : VersionedClassMap<FacilitiesCategory>
    {
        public FacilitiesCategoryMap()
        {
            Table("FacilitiesCategory");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.CategoryName).Column("CATEGORY_NAME");
            HasMany(x => x.FacilitiesS).KeyColumn("FACILITIES_CATEGORY_ID");
        }
    }
}
