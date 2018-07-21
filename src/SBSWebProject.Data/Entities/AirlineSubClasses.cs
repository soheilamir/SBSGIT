using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public class AirlineSubClasses : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        public virtual AirlineClasses AirlineClassesItem { get; set; }
        public virtual string AirlineSubClassName { get; set; }
        public virtual bool? IsActive { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirlineClassPath> AirlineClassPathS { get; set; }
        public virtual IList<FlightNumbers> FlightNumbersS { get; set; }
    }
}
