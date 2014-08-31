namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;
    
    ////teest
    public class CapeReviewRepository : BaseRepository, ICapeReviewRepository
    {
        private const string GetCapeReviewByCourseProcedure = "spGetCapeReviewByCourse";

        public List<CapeCourseReview> GetCapeReviewByCourse(int course_id, ref List<string> errors)
        {
            var list = new List<CapeCourseReview>();
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(GetCapeReviewByCourseProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var cape = new CapeReview
                    {
                        CourseScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["course_schedule_id"].ToString()),
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(),
                        Year = dataSet.Tables[0].Rows[i]["year"].ToString(),
                        Course = new Course
                        {
                            CourseId = dataSet.Tables[0].Rows[i]["course_id"].ToString(),
                            Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                            Description = dataSet.Tables[0].Rows[i]["course_description"].ToString()
                        },
                        Instructor = new Instructor
                        {
                            FirstName = dataSet.Tables[0].Rows[i]["instructor_first_name"].ToString(),
                            LastName = dataSet.Tables[0].Rows[i]["instructor_last_name"].ToString()
                        }
                    };

                    var capeCourseReview = new CapeCourseReview
                    {
                        CapeDetail = cape,
                        As = Convert.ToInt32(dataSet.Tables[0].Rows[i]["As"].ToString()),
                        Bs = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Bs"].ToString()),
                        Cs = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Cs"].ToString()),
                        Ds = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Ds"].ToString()),
                        Fs = Convert.ToInt32(dataSet.Tables[0].Rows[i]["Fs"].ToString()),
                        TotalReviews = Convert.ToInt32(dataSet.Tables[0].Rows[i]["total"].ToString()),
                        AverageReview = Convert.ToSingle(dataSet.Tables[0].Rows[i]["avg"].ToString())
                    };

                    list.Add(capeCourseReview);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return list;
        }
    }
}
