namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using IRepository;

    using POCO;

    public class TaTutorRepository : BaseRepository, ITaTutorRepository
    {
        private const string InsertTaScheduleProcedure = "spInsertTASchedule";
        private const string InsertTaInfoProcedure = "spInsertTATutorInfo";
        private const string DeleteTaInfoProcedure = "spDeleteTATutorInfo";
        private const string UpdateTaInfoProcedure = "spUpdateTATutorInfo";
        private const string GetTaListProcedure = "spGetTaList";
        private const string GetTaScheduleByCourseProcedure = "spGetTaScheduleByCourse";

        public void InsertTaTutor(TaTutor ta_tutor, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertTaInfoProcedure, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@tutor_id", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ta_type_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@tutor_id"].Value = ta_tutor.TaTutorId;
                adapter.SelectCommand.Parameters["@first_name"].Value = ta_tutor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = ta_tutor.LastName;
                adapter.SelectCommand.Parameters["@ta_type_id"].Value = (int)ta_tutor.TaType;

                var dataset = new DataSet();
                adapter.Fill(dataset);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteTaTutor(string ta_tutor_id, ref List<string> errors)
        {
            var connection = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(DeleteTaInfoProcedure, connection)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@tutor_id", SqlDbType.VarChar, 10));

                adapter.SelectCommand.Parameters["@tutor_id"].Value = ta_tutor_id;

                var dataset = new DataSet();
                adapter.Fill(dataset);
            }
            catch (Exception e)
            {
                errors.Add("errors: " + e);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public void UpdateTaTutor(TaTutor ta_tutor, ref List<string> errors)
        {
            var connection = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertTaInfoProcedure, connection)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@tutor_id", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ta_type_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@tutor_id"].Value = ta_tutor.TaTutorId;
                adapter.SelectCommand.Parameters["@first_name"].Value = ta_tutor.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = ta_tutor.LastName;
                adapter.SelectCommand.Parameters["@ta_type_id"].Value = (int)ta_tutor.TaType;

                var dataset = new DataSet();
                adapter.Fill(dataset);
            }
            catch (Exception e)
            {
                errors.Add("Errors : " + e);
            }
            finally
            {
                connection.Dispose();
            }
        }

        public List<TaTutor> GetTutorList(ref List<string> errors)
        {
            var talist = new List<TaTutor>();
            var connection = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(GetTaScheduleByCourseProcedure, connection)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var ta = new TaTutor
                                     {
                                         TaTutorId = dataSet.Tables[0].Rows[i]["id"].ToString(),
                                         FirstName = dataSet.Tables[0].Rows[i]["first"].ToString(),
                                         LastName = dataSet.Tables[0].Rows[i]["last"].ToString(),
                                         TaType = 
                                            (TaType)
                                            Enum.Parse(
                                                 typeof(TaType),
                                                 dataSet.Tables[0].Rows[i]["type"].ToString())
                                     };
                    talist.Add(ta);
                }
            }
            catch (Exception e)
            {
                errors.Add("Errors: " + e);
            }
            finally
            {
                connection.Dispose();
            }

            return talist;
        }

        public List<TaTutor> GetTutorByCousrseSchedule(int course_schedule_id, ref List<string> errors)
        {
            var talist = new List<TaTutor>();
            var connection = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(GetTaScheduleByCourseProcedure, connection)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_schedule_id"].Value = course_schedule_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var ta = new TaTutor
                                     {
                                         TaTutorId = dataSet.Tables[0].Rows[i]["ta_tutor_id"].ToString(),
                                         FirstName = dataSet.Tables[0].Rows[i]["first_name"].ToString(),
                                         LastName = dataSet.Tables[0].Rows[i]["last_name"].ToString(),
                                         TaType = 
                                            (TaType)
                                            Enum.Parse(
                                                 typeof(TaType),
                                                 dataSet.Tables[0].Rows[i]["ta_type"].ToString())
                                     };
                    talist.Add(ta);
                }
            }
            catch (Exception e)
            {
                errors.Add("Errors: " + e);
            }
            finally
            {
                connection.Dispose();
            }

            return talist;
        }
    }
}
