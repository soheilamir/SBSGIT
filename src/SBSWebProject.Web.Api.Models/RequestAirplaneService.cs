using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class RequestAirplaneService
    {
        public virtual long Id { get; set; }
        public virtual Orders OrdersItem { get; set; }
        public virtual RequestStatus RequestStatusItem { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual bool? IsChanged { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
        public virtual string Description { get; set; }
        public virtual bool? IsActiveRequest { get; set; }
        public virtual IList<RequestAirplaneTicket> lstFlight { get; set; }
    }
}
