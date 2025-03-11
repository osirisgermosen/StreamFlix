using Microsoft.AspNetCore.Mvc;

namespace MovieMvcProject.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            return View("Test");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}






