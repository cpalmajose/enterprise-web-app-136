namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ICapeReviewRepository
    {
        List<CapeCourseReview> GetCapeReviewByCourse(int course_id, ref List<string> errors);
    }
}
