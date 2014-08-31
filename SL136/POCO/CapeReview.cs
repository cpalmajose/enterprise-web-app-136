namespace POCO
{
    public class CapeReview
    {
        public int CourseScheduleId { get; set; }

        public string Quarter { get; set; }

        public string Year { get; set; }

        public Course Course { get; set; }

        public Instructor Instructor { get; set; }
    }
}
