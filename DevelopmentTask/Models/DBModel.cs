using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DevelopmentTask.Models
{
    public class DBModel
    {
        public string Connection { get; set; } = "tasks";
        public string Query { get; set; }
        public List<SQLParameter> SQLParameters { get; set; }

        public void Dispose() {
            SQLParameters = null;
        }
        public DataSet GetData()
        {
            string conStr = ConfigurationManager.ConnectionStrings["tasks"].ConnectionString.ToString();

            SqlDataAdapter da = null;
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (SQLParameters != null)
                    foreach (var item in SQLParameters)
                    {
                        cmd.Parameters.AddWithValue(item.Param_name, item.Param_value);
                    }

                con.Open();

                da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return ds;
        }

        public string GetScalar()
        {
            string conStr = ConfigurationManager.ConnectionStrings["tasks"].ConnectionString.ToString();
            var str = ""; 

            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (SQLParameters != null)
                    foreach (var item in SQLParameters)
                    {
                        cmd.Parameters.AddWithValue(item.Param_name, item.Param_value);
                    }

                con.Open();
                str = cmd.ExecuteScalar().ToString();
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            return str;
        }

        public void PostData()
        {
            string conStr = ConfigurationManager.ConnectionStrings["tasks"].ConnectionString.ToString();

            using (SqlConnection con = new SqlConnection(conStr))
            {

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (SQLParameters != null)
                    foreach (var item in SQLParameters)
                    {
                        cmd.Parameters.AddWithValue(item.Param_name, item.Param_value);
                    }

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                con.Close();
                con.Dispose();
            }
        }
    }

    public class SQLParameter
    {
        public string Param_name { get; set; }
        public string Param_value { get; set; }
    }
}