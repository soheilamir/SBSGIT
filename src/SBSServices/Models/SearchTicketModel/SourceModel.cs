using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebSiteAPI.Models.SearchTicketModel
{
    public class SourceModel
    {
        public long Id { set; get; }
        public string CityName { set; get; }
        public string OriginIATACODE { set; get; }
    }
}