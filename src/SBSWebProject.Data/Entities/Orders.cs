using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public class Orders : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual RequestStatus OrderStatusItem { get; set; }
        public virtual DateTime? SubmitDateTime { get; set; }
        public virtual DateTime? CompletionDateTime { get; set; }
        public virtual bool? IsHealthSave { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }

        public virtual IList<CompanyOrdersConfirmation> CompanyOrdersConfirmationS { get; set; }
        public virtual IList<CompanyAttachment> CompanyAttachmentS { get; set; }
        public virtual IList<OnlineFlightTicket> OnlineFlightTicketS { get; set; }
        public virtual IList<RequestAirplaneService> RequestAirplaneServiceS { get; set; }
    }
}
