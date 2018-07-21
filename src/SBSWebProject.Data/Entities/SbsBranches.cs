using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class SbsBranches : Entity
    {
        //public virtual long Id { get; set; }
        public virtual City CityItem { get; set; }
        public virtual string Description { get; set; }
        public virtual string Address { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Fax { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string Email { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Messages> MessagesS { get; set; }
        public virtual IList<SbsBranchAwards> SbsBranchAwardsS { get; set; }
        public virtual IList<SbsBranchImages> SbsBranchImagesS { get; set; }
        public virtual IList<SbsBranchTeam> SbsBranchTeamS { get; set; }
    }
}
