using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public class Files : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Folders FoldersItem { get; set; }
        public virtual Extensions ExtensionsItem { get; set; }
        public virtual string FileUrl { get; set; }
        public virtual string FileName { get; set; }
        public virtual DateTime? UploadeDate { get; set; }
        public virtual string FileSize { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Blogs> BlogsS { get; set; }
        public virtual IList<CompanyAttachment> CompanyAttachmentS { get; set; }
        public virtual IList<HotelPhotos> HotelPhotosS { get; set; }
        public virtual IList<HotelRoomPhotos> HotelRoomPhotosS { get; set; }
        public virtual IList<News> NewsS { get; set; }
        public virtual IList<ReceivedResume> ReceivedResumeS { get; set; }
        public virtual IList<SbsBranchAwards> SbsBranchAwardsS { get; set; }
        public virtual IList<SbsBranchImages> SbsBranchImagesS { get; set; }
        public virtual IList<SbsBranchTeam> SbsBranchTeamS { get; set; }
        public virtual IList<WebPageBanners> WebPageBannersS { get; set; }
    }
}
