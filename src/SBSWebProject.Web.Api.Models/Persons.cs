using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class Persons
    {
        public long Id { get; set; }
        public int? PersonType { get; set; }
        public IList<InsuranceOrders> InsuranceOrdersS { get; set; }
    }
}
