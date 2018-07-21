namespace SBSWebProject.Data.Entities
{
    public interface IVersionedEntity
    {
        byte[] Version { get; set; }
        short State { get; set; }
    }
}
