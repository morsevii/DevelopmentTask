using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DevelopmentTask.Models
{
    public static class SystemsModel
    {


        public static List<System> GetList(string search) {

            DBModel db = new DBModel();

            db.Query = "[dbo].[GetSystemList]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();
            
            SQLParams.Add(new SQLParameter { Param_name = "@search", Param_value = search });
            db.SQLParameters = SQLParams;
            DataSet ds = db.GetData();

            var data = ds.Tables[0].AsEnumerable()
            .Select(dataRow => new System
            {
                id = dataRow.Field<int>("id"),
                Code = dataRow.Field<string>("Code"),
                Name = dataRow.Field<string>("Name"),
                AccomplishmentDate = dataRow.Field<string>("AccomplishmentDate"),
                Pending = dataRow.Field<int>("Pending"),
                Ongoing = dataRow.Field<int>("Ongoing"),
                Total = dataRow.Field<int>("Total")
            }).ToList();

            db.Dispose();

            return data;
        } 
    }

    public class System {
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AccomplishmentDate { get; set; }
        public int Pending { get; set; }
        public int Ongoing { get; set; }
        public int Total { get; set; }
    }
}