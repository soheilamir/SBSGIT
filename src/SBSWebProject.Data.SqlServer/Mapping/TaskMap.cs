using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class TaskMap : VersionedClassMap<Tasks>
    {
        public TaskMap()
        {
            Id(x => x.TaskId);
            Map(x => x.Subject).Not.Nullable();
            Map(x => x.StartDate).Nullable();
            Map(x => x.DueDate).Nullable();
            Map(x => x.CompletedDate).Nullable();
            Map(x => x.CreatedDate).Not.Nullable();
            //Map(x => x.State).Column("STATE").Not.Nullable();
            References(x => x.Status, "StatusId");
            References(x => x.CreatedBy, "CreatedUserId");

            HasManyToMany(x => x.Users)
            .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
            .Table("TaskUser")
            .ParentKeyColumn("TaskId")
            .ChildKeyColumn("UserId");
           
            
        }
    }
}
