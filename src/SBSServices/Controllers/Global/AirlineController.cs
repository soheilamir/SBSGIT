using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SBSWebSiteAPI.Controllers.Global
{
    [EnableCors(origins: "http://localhost:24258", headers: "content-type", methods: "*")]
    public class AirlineController : ApiController
    {
        [Route("baseData/lstAirline")]
        public IList GetAirlinesList()
        {
            IList airline = new ArrayList();
            return airline;
        }
        [Route("baseData/lstHotels")]
        public IList GetHotelsList()
        {
            IList hotels = new ArrayList();
            return hotels;
        }
    }
}
