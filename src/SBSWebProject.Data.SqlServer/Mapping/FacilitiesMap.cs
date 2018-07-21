using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FacilitiesMap : VersionedClassMap<Facilities>
    {
        public FacilitiesMap()
        {
            Table("Facilities");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.FacilitiesCategoryItem).Column("FACILITIES_CATEGORY_ID");
            HasMany(x => x.FacilitiesNameByLanguageS).KeyColumn("FACILITIES_ID");
        }
    }
}
