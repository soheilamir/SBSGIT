using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SBSWebSiteAPI.Controllers.Global
{
    [EnableCors(origins: "http://localhost:24258", headers: "content-type", methods: "*")]
    public class LocationInfoController : ApiController
    {
        #region API Currency Method
        /// <summary>
        /// show sample currency info
        /// </summary>
        /// <returns></returns>
        [Route("LacationInfo/GetInfoCurrency")]
        public string GetInfoCurrency()
        {
            return "IRR";
        }

        #endregion

        #region API Location Method

        /// <summary>
        /// show sample location info
        /// </summary>
        /// <returns></returns>
        [Route("LacationInfo/GetInfoLocation")]
        public string GetInfoLocation()
        {
            return "IR";
        }

        #endregion
    }

}
