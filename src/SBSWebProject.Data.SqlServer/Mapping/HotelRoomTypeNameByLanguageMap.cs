using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class HotelRoomTypeNameByLanguageMap : VersionedClassMap<HotelRoomTypeNameByLanguage>
    {
        public HotelRoomTypeNameByLanguageMap()
        {
            Table("HotelRoomTypeNameByLanguage");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.HotelRoomTypeItem).Column("HOTEL_ROOM_TYPE_ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.Description).Column("DESCRIPTION");
        }
    }
}
