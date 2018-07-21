using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserFavoriteAirlines
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        public virtual long? FromCityId { get; set; }
        public virtual long? ToCityId { get; set; }
    }
}
