namespace Service
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using IRepository;
    using POCO;

    public class TaTutorService
    {
        private readonly ITaTutorRepository repository;

        public TaTutorService(ITaTutorRepository repository)
        {
            this.repository = repository;
        }

        public bool CheckId(string input_id)
        {
            string strRegEx = @"[a-zA-Z0-9]{7,10}";
            Regex re = new Regex(strRegEx);
            var flag = re.IsMatch(input_id);
            Console.WriteLine(flag);
            if (re.IsMatch(input_id))
            {
                return true;
            }
            else
            {
                return false;
            }  
        }

        public bool CheckName(string input_name)
        {
            string strRegex = @"[a-zA-Z]{3,15}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input_name))
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        public bool CheckType(int input_type)
        {
            string strRegex = @"[0-9]";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input_type.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        public void InsertTaTutor(TaTutor ta_tutor, ref List<string> errors)
        {
            if (ta_tutor == null)
            {
                errors.Add("TA/Tutor cannot be null");
                throw new ArgumentException();
            }

            if (ta_tutor.TaTutorId.Length < 6 || ta_tutor.TaTutorId.Length > 11)
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            if (!this.CheckId(ta_tutor.TaTutorId))
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            if (!this.CheckName(ta_tutor.FirstName))
            {
                errors.Add("Invalid first name");
                throw new ArgumentException();
            }

            if (!this.CheckName(ta_tutor.LastName))
            {
                errors.Add("Invalid last name");
                throw new ArgumentException();
            }

            if ((int)ta_tutor.TaType < 0 || (int)ta_tutor.TaType > 2)
            {
                errors.Add("Invalid ta/tutor type");
                throw new ArgumentException(); 
            }
            else if (!this.CheckType((int)ta_tutor.TaType))
            {
                errors.Add("Invalid ta/tutor type");
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

            if (ta_tutor_id.Length < 6 || ta_tutor_id.Length > 11)
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            if (!this.CheckId(ta_tutor_id))
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            if(this.repository.GetTaTutorInfo(ta_tutor_id, ref errors) == null)
            {
                errors.Add("TA/Tutor doesn't exist");
                throw new Exception();
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

            if (ta_tutor.TaTutorId.Length < 6 || ta_tutor.TaTutorId.Length > 11)
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            if (!this.CheckId(ta_tutor.TaTutorId))
            {
                errors.Add("Invalid TA/Tutor ID");
                throw new ArgumentException();
            }

            if (!this.CheckName(ta_tutor.FirstName))
            {
                errors.Add("Invalid first name");
                throw new ArgumentException();
            }

            if (!this.CheckName(ta_tutor.LastName))
            {
                errors.Add("Invalid last name");
                throw new ArgumentException();
            }

            if ((int)ta_tutor.TaType < 0 || (int)ta_tutor.TaType > 2)
            {
                errors.Add("Invalid ta/tutor type");
                throw new ArgumentException();
            }
            else if (!this.CheckType((int)ta_tutor.TaType))
            {
                errors.Add("Invalid ta/tutor type");
                throw new ArgumentException();
            }

            this.repository.UpdateTaTutor(ta_tutor, ref errors);
        }

        public List<TaTutor> GetTutorList(ref List<string> errors)
        {
            return this.repository.GetTutorList(ref errors);
        }

        public List<TaTutor> GetTutorByCourseSchedule(int course_schedule_id, ref List<string> errors)
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