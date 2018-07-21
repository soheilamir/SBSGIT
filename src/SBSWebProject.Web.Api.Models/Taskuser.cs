using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class TaskUser
    {
        public virtual long Taskid { get; set; }
        public virtual long Userid { get; set; }
        public virtual Task Task { get; set; }
        public virtual Users Users { get; set; }
        public virtual short State { get; set; }
        public virtual byte[] Version { get; set; }
        #region NHibernate Composite Key Requirements
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var t = obj as TaskUser;
            if (t == null) return false;
            if (Taskid == t.Taskid
             && Userid == t.Userid)
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Taskid.GetHashCode();
            hash = (hash * 397) ^ Userid.GetHashCode();

            return hash;
        }
        #endregion
    }
}
