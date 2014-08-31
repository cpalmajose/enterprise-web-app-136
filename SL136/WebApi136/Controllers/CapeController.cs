namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;
    using Repository;
    using Service;

    public class CapeController : ApiController
    {
        private readonly CapeService service = new CapeService(new CapeReviewRepository());

        private List<string> errors = new List<string>();

        [HttpGet]
        public List<CapeCourseReview> GetCapeReviewByCourse(string course_id)
        {
            return this.service.GetCapeReviewByCourse(course_id, ref this.errors);
        }
    }
}