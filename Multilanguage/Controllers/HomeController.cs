using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Multilanguage.Controllers
{
    public class HomeController : Controller
    {
        MultilanguageContext db = new MultilanguageContext();

        public ActionResult Index(string language)
        {
            SetLanguage(language);

            return View();
        }

        public ActionResult About(string language)
        {
            SetLanguage(language);

            ViewBag.Message = "TODO";

            return View();
        }

        public ActionResult Contact(string language)
        {
            SetLanguage(language);

            ViewBag.Message = Multilanguage.Resources.IndexResource.MyContactInformation;

            // Extract value from database based on the 'language'
            User user = db.Users.FirstOrDefault(u => u.Lang.Equals(language));
            System.Diagnostics.Debug.WriteLine("---" + user.ID + ", " + user.Lang + ", " + user.Description);

            return View(user);
        }

        public static void SetLanguage(string language)
        {
            if (IsValidLanguage(language))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }
            else
            {
                string defaultLanguage = "en-US";

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(defaultLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(defaultLanguage);
            }
        }

        private static bool IsValidLanguage(string language)
        {
            string[] supportingLangs = { "en-US", "ja-JP", "ko-KR", "vi-VN" };

            if (language == null)
            {
                return false;
            }

            foreach (string lang in supportingLangs)
            {
                if (lang.Equals(language))
                {
                    return true;
                }
            }

            return false;
        }
    }
}