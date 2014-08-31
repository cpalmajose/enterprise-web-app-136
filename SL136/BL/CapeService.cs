namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class CapeService
    {
        private readonly ICapeReviewRepository repository;

        public CapeService(ICapeReviewRepository repo)
        {
            this.repository = repo;
        }

        public List<CapeCourseReview> GetCapeReviewByCourse(string course_id, ref List<string> errors)
        {
            int cid;

            if (string.IsNullOrEmpty(course_id) || !int.TryParse(course_id, out cid))
            {
                errors.Add("Invalid Course_ID");
                throw new ArgumentException();
            }

            if (cid < 0)
            {
                errors.Add("Invalid Course_ID");
                throw new ArgumentException();
            }

            return this.repository.GetCapeReviewByCourse(cid, ref errors);
        }
    }
}
