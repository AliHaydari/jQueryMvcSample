using jQueryMvcSample.Models;
using jQueryMvcSample.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace jQueryMvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowSynchronous()
        {
            var model = getModel();
            return View(model); //نمايش همزمان
        }

        private static BlogPost getModel()
        {
            //شبيه سازي يك عمليات طولاني
            System.Threading.Thread.Sleep(3000);
            var model = new BlogPost
            {
                Title = "عنوان ... ",
                Body = "مطلب... "
            };
            return model;
        }

        [HttpGet]
        public ActionResult ShowAsynchronous()
        {
            return View(); //نمايش ابتدايي صفحه
        }

        [HttpPost]
        [AjaxOnly]
        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public ActionResult RenderAsynchronous()
        {
            //دريافت اطلاعات به صورت غيرهمزمان
            var model = getModel();
            return PartialView(viewName: "_Post", model: model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}