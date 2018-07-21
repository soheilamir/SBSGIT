using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class CityPublicPlaceMap : VersionedClassMap<CityPublicPlace> {
        
        public CityPublicPlaceMap() {
			Table("CityPublicPlace");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
			References(x => x.CityItem).Column("CITY_ID");
			HasMany(x => x.CityPublicPlaceNameByLanguageS).KeyColumn("PUBLIC_PLACE_ID");
			HasMany(x => x.HotelAccessibilityS).KeyColumn("PUBLIC_PLACE_ID");
        }
    }
}
