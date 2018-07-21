using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomTypeMap : VersionedClassMap<HotelRoomType>
    {
        public HotelRoomTypeMap()
        {
            Table("HotelRoomType");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
        }
    }
}
