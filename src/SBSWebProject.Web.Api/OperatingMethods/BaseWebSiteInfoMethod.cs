using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Web.Api.Models;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using SBSWebProject.Web.Api.MethodsInterface;
using System.Collections;

namespace SBSWebProject.Web.Api.OperatingMethods
{
    public class BaseWebSiteInfoMethod : IBaseWebSiteInfoMethod
    {
        public IList<string> FillImgList(string kind)
        {
            IList<string> lstUrlImg = new List<string>();
            if (kind == "_f")
                lstUrlImg.Add("http://rrfco.com/wallpaper/waikiki_after_sunset-wallpaper-3554x1999.jpg");
            else if (kind == "_h")
                lstUrlImg.Add("http://rrfco.com/wallpaper/hotel.jpg");
            return lstUrlImg;
        }
    }
}