using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class PassengerFlight
    {
        public long Id { set; get; }
        public string Name_Fa { set; get; }
        public string LastName_Fa { set; get; }
        public string Name_En { set; get; }
        public string LastName_En { set; get; }
        public string BD { set; get; }
        public string NationalCode { set; get; }
        public string Tel { set; get; }
        public virtual string TicketNumber { get; set; }
    }
}
