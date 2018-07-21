using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class FilesMap : VersionedClassMap<Files>
    {
        public FilesMap()
        {
            Table("Files");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("OWNER_USER_ID");
            References(x => x.FoldersItem).Column("FOLDER_ID");
            References(x => x.ExtensionsItem).Column("FILE_EXTENSION_ID");
            Map(x => x.FileUrl).Column("FILE_URL");
            Map(x => x.FileName).Column("FILE_NAME");
            Map(x => x.UploadeDate).Column("UPLOADE_DATE");
            Map(x => x.FileSize).Column("FILE_SIZE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.BlogsS).KeyColumn("IMAGE_ID");
            HasMany(x => x.CompanyAttachmentS).KeyColumn("ATTACH_FILE_ID");
            HasMany(x => x.HotelPhotosS).KeyColumn("PHOTO_ID");
            HasMany(x => x.HotelRoomPhotosS).KeyColumn("PHOTO_ID");
            HasMany(x => x.NewsS).KeyColumn("IMAGE_ID");
            HasMany(x => x.ReceivedResumeS).KeyColumn("ATTACH_FILE_ID");
            HasMany(x => x.SbsBranchAwardsS).KeyColumn("IMAGE_ID");
            HasMany(x => x.SbsBranchImagesS).KeyColumn("IMAGE_ID");
            HasMany(x => x.SbsBranchTeamS).KeyColumn("PERSONNEL_IMAGE_ID");
            HasMany(x => x.WebPageBannersS).KeyColumn("FILE_ID");
        }
    }
}
