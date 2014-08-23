namespace POCO
{
    using System.Collections.Generic;

    public class TaTutor
    {
        public string TaTutorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public TaType TaType { get; set; }

        public List<Schedule> TaTutorSchedule { get; set; }

        public override string ToString()
        {
            return this.TaTutorId + '|' + this.FirstName + "|" + this.LastName + "|" + this.TaType;
        }
    }
}
