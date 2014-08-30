namespace Web136.Controllers
{
    using System.Web.Mvc;

    public class TutorController : Controller
    {
        public ActionResult TutorBySchedule(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }
    }
}