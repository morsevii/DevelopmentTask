using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DevelopmentTask.Tools;

namespace DevelopmentTask.Models
{
    public class TasksModel
    {
        public List<Task> GetSystemTask(string code,string search)
        {
            DBModel db = new DBModel();

            db.Query = "[dbo].[GetSystemTask]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            SQLParams.Add(new SQLParameter { Param_name = "@system_code", Param_value = code });
            SQLParams.Add(new SQLParameter { Param_name = "@search", Param_value = search });
            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();

            var data = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new Task
                {
                    id = dataRow.Field<int>("id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Phase = dataRow.Field<string>("Phase"),
                    Title = dataRow.Field<string>("Name"),
                    Details = dataRow.Field<string>("Details"),
                    Difficulty = dataRow.Field<int>("Difficulty"),
                    Status = dataRow.Field<int>("Status")
                }).ToList();
            ds.Dispose();
            db.Dispose();

            return data;
        }


        public List<Task> GetAllTask(string search)
        {
            DBModel db = new DBModel();
            db.Query = "[dbo].[GetAllTask]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            SQLParams.Add(new SQLParameter { Param_name = "@search", Param_value = search });
            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();

            var data = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new Task
                {
                    id = dataRow.Field<int>("id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Phase = dataRow.Field<string>("Phase"),
                    Title = dataRow.Field<string>("Title"),
                    Details = dataRow.Field<string>("Details"),
                    Difficulty = dataRow.Field<int>("Difficulty"),
                    Status = dataRow.Field<int>("Status")
                }).ToList();
            ds.Dispose();
            db.Dispose();

            return data;
        }

        public Task GetTask(int id)
        {
            DBModel db = new DBModel();
            db.Query = "[dbo].[GetTask]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            SQLParams.Add(new SQLParameter { Param_name = "@id", Param_value = id.ToString() });
            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();
            var dataRow = ds.Tables[0].Rows[0];

            Task t = new Task
            {
                id = dataRow.Field<int>("id"),
                Code = dataRow.Field<string>("Code"),
                Name = dataRow.Field<string>("Name"),
                Phase = dataRow.Field<string>("Phase"),
                Title = dataRow.Field<string>("Title"),
                Details = dataRow.Field<string>("Details"),
                Remarks = dataRow.Field<string>("Remarks") == null ? "-" : dataRow.Field<string>("Remarks"),
                Difficulty = dataRow.Field<int>("Difficulty"),
                Status = dataRow.Field<int>("Status"),

                AssignedTo = dataRow.Field<string>("assigned_to"),
                ToName = dataRow.Field<string>("ToName") == null ? "-" : dataRow.Field<string>("ToName"),

                ReqBy = dataRow.Field<string>("req_by"),
                ReqName = dataRow.Field<string>("ReqName"),
                ReqDate = dataRow.Field<DateTime>("req_date").ToString("yyyy-MM-dd"),

                EncBy = dataRow.Field<string>("enc_by"),
                EncName = dataRow.Field<string>("EncName"),
                EncDate = dataRow.Field<DateTime>("enc_date").ToString("yyyy-MM-dd"),

                ModBy = dataRow.Field<string>("mod_by"),
                ModDate = dataRow.Field<string>("mod_date") != null ? dataRow.Field<string>("mod_date").ToYMDHm() : "N/A",
                ModName = dataRow.Field<string>("ModName") != null ? dataRow.Field<string>("ModName") : "N/A",


                DoneBy = dataRow.Field<string>("done_by"),
                DoneDate = dataRow.Field<string>("done_date") != null ? dataRow.Field<string>("done_date").ToYMDHm() : "N/A",
                DoneName = dataRow.Field<string>("DoneName") != null ? dataRow.Field<string>("DoneName"): "N/A"
            };
            ds.Dispose();
            return t;
        }

        public List<Task> GetUserTask(string id,string search)
        {
            DBModel db = new DBModel();
            db.Query = "[dbo].[GetUserTask]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            SQLParams.Add(new SQLParameter { Param_name = "@username", Param_value = id });
            SQLParams.Add(new SQLParameter { Param_name = "@search", Param_value = search });
            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();

            var data = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new Task
                {
                    id = dataRow.Field<int>("id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Phase = dataRow.Field<string>("Phase"),
                    Title = dataRow.Field<string>("Title"),
                    Details = dataRow.Field<string>("Details"),
                    Difficulty = dataRow.Field<int>("Difficulty"),
                    Status = dataRow.Field<int>("Status")
                }).ToList();
            ds.Dispose();
            db.Dispose();

            return data;
        }

        public List<ListItem> GetAllMIS()
        {
            DBModel db = new DBModel();
            db.Query = "[dbo].[GetAllMIS]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();

            List<ListItem> data = new List<ListItem>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ListItem list = new ListItem();
                list.Text = item["Value"].ToString();
                list.Value = item["id"].ToString();

                data.Add(list);
            }
            ds.Dispose();
            db.Dispose();

            return data;
        }

        public List<ListItem> GetAllEmployee()
        {
            DBModel db = new DBModel();
            db.Query = "[dbo].[GetAllEmployee]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();

            List<ListItem> data = new List<ListItem>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ListItem list = new ListItem();
                list.Text = item["Value"].ToString();
                list.Value = item["id"].ToString();

                data.Add(list);
            }
            ds.Dispose();
            db.Dispose();

            return data;
        }


        public string AddTask( Task obj)
        {
            var message = "Success";
            try
            {
                DBModel db = new DBModel();
                db.Query = "[dbo].[AddTask]";

                List<SQLParameter> SQLParams = new List<SQLParameter>();

                SQLParams.Add(new SQLParameter { Param_name = "@sys_code", Param_value = obj.Code });
                SQLParams.Add(new SQLParameter { Param_name = "@phase", Param_value = obj.Phase.ToString() });
                SQLParams.Add(new SQLParameter { Param_name = "@difficulty", Param_value = obj.Difficulty.ToString() });
                SQLParams.Add(new SQLParameter { Param_name = "@status", Param_value = obj.Status.ToString() });
                SQLParams.Add(new SQLParameter { Param_name = "@title", Param_value = obj.Title });
                SQLParams.Add(new SQLParameter { Param_name = "@details", Param_value = obj.Details });
                SQLParams.Add(new SQLParameter { Param_name = "@remarks", Param_value = obj.Remarks });
                SQLParams.Add(new SQLParameter { Param_name = "@to", Param_value = obj.AssignedTo });

                SQLParams.Add(new SQLParameter { Param_name = "@enc_by", Param_value = obj.EncBy });
                SQLParams.Add(new SQLParameter { Param_name = "@req_by", Param_value = obj.ReqBy });
                SQLParams.Add(new SQLParameter { Param_name = "@req_date", Param_value = obj.ReqDate });

                db.SQLParameters = SQLParams;
                db.PostData();
                db.Dispose();
            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }

            return message;
        }
        public string UpdateTask( Task obj)
        {
            DBModel db = new DBModel();
            var message = "Success";
            try
            {
                db.Query = "[dbo].[UpdateTask]";

                List<SQLParameter> SQLParams = new List<SQLParameter>();

                SQLParams.Add(new SQLParameter { Param_name = "@id", Param_value = obj.id.ToString() });

                SQLParams.Add(new SQLParameter { Param_name = "@sys_code", Param_value = obj.Code });
                SQLParams.Add(new SQLParameter { Param_name = "@phase", Param_value = obj.Phase.ToString() });
                SQLParams.Add(new SQLParameter { Param_name = "@difficulty", Param_value = obj.Difficulty.ToString() });
                SQLParams.Add(new SQLParameter { Param_name = "@status", Param_value = obj.Status.ToString() });
                SQLParams.Add(new SQLParameter { Param_name = "@title", Param_value = obj.Title });
                SQLParams.Add(new SQLParameter { Param_name = "@details", Param_value = obj.Details });
                SQLParams.Add(new SQLParameter { Param_name = "@remarks", Param_value = obj.Remarks });
                SQLParams.Add(new SQLParameter { Param_name = "@to", Param_value = obj.AssignedTo });

                SQLParams.Add(new SQLParameter { Param_name = "@req_by", Param_value = obj.ReqBy });
                SQLParams.Add(new SQLParameter { Param_name = "@req_date", Param_value = obj.ReqDate });


                SQLParams.Add(new SQLParameter { Param_name = "@mod_by", Param_value = obj.ModBy });

                db.SQLParameters = SQLParams;
                db.PostData();
            }
            catch (Exception ex)
            {

                message = ex.Message.ToString();
            }
            db.Dispose();

            return message;
        }


        public string DoneTask(Task obj)
        {
            var message = "Success";
            DBModel db = new DBModel();

            db.Query = "[dbo].[DoneTask]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            SQLParams.Add(new SQLParameter { Param_name = "@id", Param_value = obj.id.ToString() });
            SQLParams.Add(new SQLParameter { Param_name = "@remarks", Param_value = obj.Remarks.ToString() });
            SQLParams.Add(new SQLParameter { Param_name = "@done_by", Param_value = obj.DoneBy });

            db.SQLParameters = SQLParams;

            db.PostData();

            db.Dispose();
            return message;
        }

        public List<Task> API_SystemTask(string _code) {
            List<Task> data = null;

            try
            {
                DBModel db = new DBModel();
                db.Query = "[dbo].[API_SystemTask]";

                List<SQLParameter> SQLParams = new List<SQLParameter>();

                SQLParams.Add(new SQLParameter { Param_name = "@sys_code", Param_value = _code.ToString() });
                db.SQLParameters = SQLParams;
                DataSet ds = db.GetData();

                data = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new Task
                {
                    id = dataRow.Field<int>("id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Phase = dataRow.Field<string>("Phase"),
                    Title = dataRow.Field<string>("Title"),
                    Details = dataRow.Field<string>("Details") == null ? "-" : dataRow.Field<string>("Details"),
                    Remarks = dataRow.Field<string>("Remarks") == null ? "-" : dataRow.Field<string>("Remarks"),
                    Difficulty = dataRow.Field<int>("Difficulty"),
                    Status = dataRow.Field<int>("Status"),

                    AssignedTo = dataRow.Field<string>("assigned_to"),
                    ToName = dataRow.Field<string>("ToName") == null ? "-" : dataRow.Field<string>("ToName"),

                    ReqBy = dataRow.Field<string>("req_by"),
                    ReqName = dataRow.Field<string>("ReqName"),
                    ReqDate = dataRow.Field<DateTime>("req_date").ToString("yyyy-MM-dd"),

                    EncBy = dataRow.Field<string>("enc_by"),
                    EncName = dataRow.Field<string>("EncName"),
                    EncDate = dataRow.Field<DateTime>("enc_date").ToString("yyyy-MM-dd"),

                    ModBy = dataRow.Field<string>("mod_by"),
                    ModDate = dataRow.Field<string>("mod_date") != null ? dataRow.Field<string>("mod_date").ToYMDHm() : "N/A",
                    ModName = dataRow.Field<string>("ModName") != null ? dataRow.Field<string>("ModName") : "N/A",


                    DoneBy = dataRow.Field<string>("done_by"),
                    DoneDate = dataRow.Field<string>("done_date") != null ? dataRow.Field<string>("done_date").ToYMDHm() : "N/A",
                    DoneName = dataRow.Field<string>("DoneName") != null ? dataRow.Field<string>("DoneName") : "N/A"
                }).ToList();

                ds.Dispose();
                db.Dispose();
                
            }
            catch (Exception)
            {

                throw;
            }


            return data;
        }
        
    }

    public class Task
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Phase { get; set; }
        public int Difficulty { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
        public string AssignedTo { get; set; }
        public string ReqBy { get; set; }
        public string ReqDate { get; set; }
        public int isActive { get; set; }
        public string EncBy { get; set; }
        public string EncDate { get; set; }
        public string ModBy { get; set; }
        public string ModDate { get; set; }
        public string DoneBy { get; set; }
        public string DoneDate { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public string EncName { get; set; }
        public string ReqName { get; set; }
        public string ModName { get; set; }
        public string ToName { get; set; }
        public string DoneName { get; set; }

        public string Remarks { get; set; }

    }
}