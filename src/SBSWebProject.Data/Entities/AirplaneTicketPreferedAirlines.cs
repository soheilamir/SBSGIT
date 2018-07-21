using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class AirplaneTicketPreferedAirlines : Entity {
        public virtual RequestAirplaneTicket RequestAirplaneTicketItem { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
    }
}
