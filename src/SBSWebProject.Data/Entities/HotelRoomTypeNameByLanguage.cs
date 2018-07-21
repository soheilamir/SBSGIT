using System;
using System.Collections.Generic;

namespace SBSWebProject.Data.Entities
{
    public class HotelRoomTypeNameByLanguage : Entity
    {
        public virtual Languages LanguagesItem { get; set; }
        public virtual HotelRoomType HotelRoomTypeItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
