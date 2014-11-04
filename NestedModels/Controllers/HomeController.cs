using System.Collections.Generic;
using System.Web.Mvc;
using NestedModels.Models;

namespace NestedModels.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Page()
        {
            var pageViewModel = new PageViewModel()
            {
                Name = "My Page",
                Zones = new List<ZoneViewModel>()
                {
                    new ZoneViewModel()
                    {
                        Name = "Zone 1",
                        Widgets = new List<WidgetViewModel>()
                        {
                            new WidgetViewModel() { Name = "widget 1" },
                            new WidgetViewModel() { Name = "widget 2" }
                        }
                    },
                    new ZoneViewModel()
                    {
                        Name = "Zone 2",
                        Widgets = new List<WidgetViewModel>()
                        {
                            new WidgetViewModel() { Name = "Widget 3" },
                            new WidgetViewModel() { Name = "Widget 4" }
                        }
                    }
                }
            };

            return View(pageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Page(PageViewModel pageViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(pageViewModel);
            }

            return View(pageViewModel);
        }
        
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetNewZone()
        {
            return PartialView("NewZone", new ZoneViewModel());
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult GetNewWidget(string containerPrefix)
        {
            ViewData["ContainerPrefix"] = containerPrefix;
            return PartialView("NewWidget", new WidgetViewModel());
        }
    }
}