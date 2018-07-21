using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FoldersMap : VersionedClassMap<Folders>
    {
        public FoldersMap()
        {
            Table("Folders");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UserItem).Column("OWNER_USER_ID");
            References(x => x.FolderItem).Column("UP_FOLDER_ID");
            Map(x => x.Name).Column("NAME");
            HasMany(x => x.FileS).KeyColumn("FOLDER_ID");
            HasMany(x => x.FoldersS).KeyColumn("UP_FOLDER_ID");
        }
    }
}