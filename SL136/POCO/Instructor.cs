namespace POCO
{
    public class Instructor
    {
        public int InstructorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return this.InstructorID + "|" + this.FirstName + "|" + this.LastName + "|" + this.Title;
        }
    }
}
