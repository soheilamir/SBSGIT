using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SBSWebSiteAPI.AllClasses.ViewWebPageClasses
{
    public class AboutPage
    {
        public string Banner { get; set; } = "http://sbs.rrfco.com/wallpaper/about/department-background.jpg";
        public string TextBanner { get; set; } = "آژانس مسافرتی هفت آسمان آبی";
        public string DescriptionTextBanner { get; set; } = "Tour & Travel Agency";
        public List<string> AboutUsText { get; set; }
        public List<string> LstLocationImage { get; set; }
        public List<string> LstSelectedAwardsImage { get; set; }

        public AboutPage()
        {
            AboutUsText = new List<string>(); LstLocationImage = new List<string>(); LstSelectedAwardsImage = new List<string>();
            AboutUsText.Add("بنام حضرت دوست که هرچه داریم ازاوست");
            AboutUsText.Add("به عنوان یک آژانس مسافرتی پیشرو با نیم قرن سابقه مدیریتی و فعالیت حرفه ای بصورت خانوادگی در صنعت توریسم در آذر ماه 1375 تاسیس گردید.");
            AboutUsText.Add("ما مفتخریم که اعلام داریم هفت آسمان آبی عضو یاتا(  211452-33 ) دارای مجوز(بند الف) از سازمان هواپیمایی کشوری و(بند ب) از سازمان میراث فرهنگی و گردشگری با تلفیقی از تجربیات درخشان گذشته، دانش روز وپشتوانه کادرمجرب و کارآزموده، با همکاری نمایندگی فعال و خوشنام خود در تورنتوی کانادا، به عنوان یک آژانس متخصص در زمینه ارائه و برگزاری تورهای مرتبط با فعالیتهای گوناگون شامل تجاری، تفریحی، ورزشی، انگیزشی و شرکتها آماده ارائه خدمات گسترده در زمینه فروش بلیط کلیه خطوط هوایی(داخلی و خارجی )، رزرواسیون هتل، هتل آپارتمان و رستوران در سراسر ایران و جهان، تورهای اختصاصی و گروهی(داخلی و خارجی )، خدمات وقت سفارت، اخذ دعوتنامه و ویزا، بیمه مسافرتی و گواهینامه بین المللی، ترانسفر با خودروهای مجهز و تشریفاتی، خدمات ویژه فرودگاهی(CIP )، ثبت نام و برگزاری همایشهای علمی و کنفرانسهای پزشکی می باشد.");
            AboutUsText.Add("هفت آسمان آبی همواره خود را نسبت به افزایش سطح اعتماد، رضایتمندی و تحقق خواسته های مشتریان با بالاترین کیفیت، سرعت و کمترین هزینه متعهد میداند و در این راستا نسبت به شناسایی، تامین و حفظ کلیه منابع و امکانات لازماز هیچ اقدامی فروگذار نخواهد کرد.");
            LstLocationImage.Add("http://sbs.rrfco.com/wallpaper/about/about-us-2.jpg");
            LstLocationImage.Add("http://sbs.rrfco.com/wallpaper/about/departments-background.jpg");
            LstLocationImage.Add("http://sbs.rrfco.com/wallpaper/about/1996_image.jpg");
            LstLocationImage.Add("http://sbs.rrfco.com/wallpaper/about/how-we-hire.jpg");
            LstLocationImage.Add("http://sbs.rrfco.com/wallpaper/about/Business-Development-e1455188576240.jpg");
            LstLocationImage.Add("http://sbs.rrfco.com/wallpaper/about/defaultHeader.jpg");

            LstSelectedAwardsImage.Add("http://sbs.rrfco.com/wallpaper/awards/11.jpg");
            LstSelectedAwardsImage.Add("http://sbs.rrfco.com/wallpaper/awards/12.jpg");
            LstSelectedAwardsImage.Add("http://sbs.rrfco.com/wallpaper/awards/06.jpg");
            LstSelectedAwardsImage.Add("http://sbs.rrfco.com/wallpaper/awards/07.jpg");
            LstSelectedAwardsImage.Add("http://sbs.rrfco.com/wallpaper/awards/1.jpg");
            LstSelectedAwardsImage.Add("http://sbs.rrfco.com/wallpaper/awards/5.jpg");
        }
    }

}