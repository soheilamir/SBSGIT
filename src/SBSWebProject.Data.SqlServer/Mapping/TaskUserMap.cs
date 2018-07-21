using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class TaskUserMap : VersionedClassMap<Taskuser>
    {
        public TaskUserMap()
        {
            Table("TaskUser");
            LazyLoad();
            CompositeId().KeyProperty(x => x.Taskid, "TaskId")
                         .KeyProperty(x => x.Userid, "UserId");
            References(x => x.Task).Column("TaskId");
            References(x => x.Users).Column("UserId");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("ts").Not.Nullable();
        }
    }
}
