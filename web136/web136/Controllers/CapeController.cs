namespace Web136.Controllers
{
    using System.Web.Mvc;

    public class CapeController : Controller
    {
        //// Currently is an error
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Course(string id)
        {
            ViewBag.course_id = id;
            return this.View();
        }
    }
}
