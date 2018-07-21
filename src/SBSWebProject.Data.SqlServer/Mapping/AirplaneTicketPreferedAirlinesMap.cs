using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities; 

namespace SBSWebProject.Data.SqlServer.Mapping {
    
    
    public partial class AirplaneTicketPreferedAirlinesMap : VersionedClassMap<AirplaneTicketPreferedAirlines> {
        
        public AirplaneTicketPreferedAirlinesMap() {
			Table("AirplaneTicketPreferedAirlines");
            LazyLoad();
			Id(x => x.Id).GeneratedBy.Increment().Column("ID");
			References(x => x.RequestAirplaneTicketItem).Column("REQUEST_AIRPLANE_TICKET_ID");
			References(x => x.AirlinesItem).Column("AIRLINE_ID");
			//Map(x => x.State).Column("STATE");
			//Map(x => x.Ts).Column("TS");
        }
    }
}
