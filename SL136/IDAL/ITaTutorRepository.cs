namespace IRepository
{
    using System.Collections.Generic;

    using POCO;

    public interface ITaTutorRepository
    {
        void InsertTaTutor(TaTutor ta_tutor, ref List<string> errors);

        void DeleteTaTutor(string ta_tutor_id, ref List<string> errors);

        void UpdateTaTutor(TaTutor ta_tutor, ref List<string> errors);

        TaTutor GetTaTutorInfo(string ta_tutor_id, ref List<string> errors);

        List<TaTutor> GetTutorList(ref List<string> errors);

        List<TaTutor> GetTutorByCourseSchedule(int course_schedule_id, ref List<string> errors);
    }
}
