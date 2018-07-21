using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class ResponseAirplaneTicket
    {
        public virtual long Id { get; set; }
        public virtual RequestAirplaneTicket RequestAirplaneTicketItem { get; set; }
        public virtual FlightNumbers FlightNumbersItem { get; set; }
        public virtual int? Availability { get; set; }
        public virtual DateTime? TicketTime { get; set; }
        public virtual bool? SbsRecommend { get; set; }
        public virtual DateTime? TicketDate { get; set; }
        public virtual bool? IsReturning { get; set; }
        public virtual bool? IsSelect { get; set; }
        public virtual int? AdultPrice { get; set; }
        public virtual int? ChildPrice { get; set; }
        public virtual int? InfantPrice { get; set; }
        public virtual IList<TicketNumbers> TicketNumberS { get; set; }
    }
}
