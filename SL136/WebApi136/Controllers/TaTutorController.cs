namespace WebApi136.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using POCO;

    using Repository;

    using Service;

    public class TaTutorController : ApiController
    {
        private readonly TaTutorService service = new TaTutorService(new TaTutorRepository());

        private List<string> errors = new List<string>();

        [HttpPost]
        public string InsertTaTutor(TaTutor ta_tutor)
        {
            this.service.InsertTaTutor(ta_tutor, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string DeleteTaTutor(string id)
        {
            this.service.DeleteTaTutor(id, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpPost]
        public string UpdateTaTutor(TaTutor ta_tutor)
        {
            this.service.UpdateTaTutor(ta_tutor, ref this.errors);
            return this.errors.Count == 0 ? "ok" : "Error occurred";
        }

        [HttpGet]
        public List<TaTutor> GetTutorList()
        {
            return this.service.GetTutorList(ref this.errors);
        }

        [HttpGet]
        public List<TaTutor> GetTutorByCourseSchedule(int course_schedule_id)
        {
            return this.service.GetTutorByCourseSchedule(course_schedule_id, ref this.errors);
        }
    }
}
