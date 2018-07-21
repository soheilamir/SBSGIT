using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class RequestStatus
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual IList<Orders> OrdersS { get; set; }
        public virtual IList<RequestAirplaneService> RequestAirplaneServiceS { get; set; }
    }
}
