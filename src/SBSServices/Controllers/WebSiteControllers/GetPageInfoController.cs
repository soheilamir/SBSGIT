using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SBSWebSiteAPI.Controllers.WebSiteControllers
{
    [EnableCors(origins: "http://localhost:24258", headers: "content-type", methods: "*")]
    public class GetPageInfoController : ApiController
    {
        #region API Get Data Page Method
        /// <summary>
        /// show sample get info
        /// </summary>
        /// <returns></returns>
        [Route("GetPageInfo/HomePage")]
        public async Task<string> GetHomePage()
        {
            Random rnd = new Random();
            return await Task.FromResult<string>(FillImgList()[rnd.Next(0, FillImgList().Count)]);
        }

        private IList<string> FillImgList()
        {
            IList<string> lstUrlImg = new List<string>();
            lstUrlImg.Add("http://rrfco.com/wallpaper/waikiki_after_sunset-wallpaper-3554x1999.jpg");
            return lstUrlImg;
        }

        [Route("GetPageInfo/AboutPage")]
        public AllClasses.ViewWebPageClasses.AboutPage GetAboutPage()
        {
            AllClasses.ViewWebPageClasses.AboutPage clsAboutPage = new AllClasses.ViewWebPageClasses.AboutPage();
            return clsAboutPage;
        }
        [Route("GetPageInfo/ContactPage")]
        public string GetContactPage()
        {
            return null;
        }
        #endregion
    }
}
