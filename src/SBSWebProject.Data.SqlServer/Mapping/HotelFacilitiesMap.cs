using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelFacilitiesMap : VersionedClassMap<HotelFacilities>
    {

        public HotelFacilitiesMap()
        {
            Table("HotelFacilities");
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelItem).Column("HOTEL_ID");
            References(x => x.FacilitiesItem).Column("FACILITIES_ID");
        }
    }
}
