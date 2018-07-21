using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class CityPublicPlaceNameByLanguageMap : VersionedClassMap<CityPublicPlaceNameByLanguage> {
        
        public CityPublicPlaceNameByLanguageMap() {
			Table("CityPublicPlaceNameByLanguage");
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
			References(x => x.LanguagesItem).Column("LANGUAGE_ID");
			References(x => x.CityPublicPlaceItem).Column("PUBLIC_PLACE_ID");
			Map(x => x.Name).Column("NAME");
			Map(x => x.Description).Column("DESCRIPTION");
        }
    }
}
