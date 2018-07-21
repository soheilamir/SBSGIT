using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : Entity
    {
        protected VersionedClassMap()
        {
            Version(x => x.Version)
            .Column("TS")
            .CustomSqlType("Rowversion")
            .Generated.Always()
            .UnsavedValue("null");
            Map(x => x.State).Column("STATE");
        }
    }
}
