using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelComments
    {
        public long Id { get; set; }
        public Hotels HotelItem { get; set; }
        public Users UserItem { get; set; }
        public string Comments { get; set; }
        public DateTime? Date { get; set; }
    }
}
