using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class Orders
    {
        public virtual long id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual RequestStatus OrderStatusItem { get; set; }
        public virtual DateTime? SubmitDateTime { get; set; }
        public virtual DateTime? CompletionDateTime { get; set; }
        //public virtual bool? IsHealthSave { get; set; }
        //public virtual IList<CompanyAttachment> CompanyAttachmentS { get; set; }
        //public virtual IList<OnlineFlightTicket> OnlineFlightTicketS { get; set; }
        public virtual IList<CompanyOrdersConfirmation> CompanyOrdersConfirmationS { get; set; }
        public virtual IList<RequestAirplaneService> lstFlightPackage { get; set; }
        //public virtual IList<> lstHotelPackage { get; set; }
    }
}
