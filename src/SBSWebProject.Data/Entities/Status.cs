namespace SBSWebProject.Data.Entities
{
    public class Status : Entity
    {
        public virtual long StatusId { get; set; }
        public virtual string Name { get; set; }
        public virtual int Ordinal { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
