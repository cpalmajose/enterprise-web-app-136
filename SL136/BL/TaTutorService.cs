namespace Service
{
    using System;
    using System.Collections.Generic;
    using IRepository;
    using POCO;

    public class TaTutorService
    {
        private readonly ITaTutorRepository repository;

        public TaTutorService(ITaTutorRepository repository)
        {
            this.repository = repository;
        }
		
		public void InsertTaTutor(TaTutor ta_tutor, ref List<string> errors)
		{
            if (ta_tutor == null)
            {
                errors.Add("TA/Tutor cannot be null");
                throw new ArgumentException();
            }

            if (ta_tutor.TaTutorId.Length < 5)
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            this.repository.InsertTaTutor(ta_tutor, ref errors);
		}
		
        public void DeleteTaTutor(string ta_tutor_id, ref List<string> errors)
        {
            if (string.IsNullOrEmpty(ta_tutor_id))
            {
                errors.Add("Invalid TA/Tutor id");
                throw new ArgumentException();
            }

            this.repository.DeleteTaTutor(ta_tutor_id, ref errors);
        }
		
        public void UpdateTaTutor(TaTutor ta_tutor, ref List<string> errors)
        {
            if (ta_tutor == null)
            {
                errors.Add("TA/Tutor cannot be null");
                throw new ArgumentException();
            }

            if (string.IsNullOrEmpty(ta_tutor.TaTutorId))
            {
                errors.Add("Invalid TA/Tutor id");
                throw new ArgumentException();
            }

            if (ta_tutor.TaTutorId.Length < 5)
            {
                errors.Add("Invalid TA/Tutor id");
                throw new ArgumentException();
            }

            this.repository.UpdateTaTutor(ta_tutor, ref errors);
        }
<<<<<<< HEAD
		
	}
}
=======

        public List<TaTutor> GetTutorList(ref List<string> errors)
        {
            return this.repository.GetTutorList(ref errors);
        }
		
		public List<TaTutor> GetTutorByCourseSchedule (int course_schedule_id, ref List<string> errors)
		{
            if (course_schedule_id < 0)
            {
                errors.Add("Invalid Course Schedule id");
                throw new ArgumentException();
            }

            return this.repository.GetTutorByCourseSchedule(course_schedule_id, ref errors);
		}
		
	}
}
>>>>>>> origin/developing
