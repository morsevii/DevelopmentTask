using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DevelopmentTask.Models
{
    public static class UserModel
    {

        public static User GetUserInfo(this string username) {
            DBModel db = new DBModel();
            db.Query = "[dbo].[GetUserInfo]";

            List<SQLParameter> SQLParams = new List<SQLParameter>();

            SQLParams.Add(new SQLParameter { Param_name = "@Employee_ID", Param_value = username.ToString() });
            db.SQLParameters = SQLParams;

            var str = db.GetScalar().Split('|');
            //var data = str.Split('|');

            User u = new User
            {
                FirstName = str[0],
                MiddleName = str[1],
                LastName = str[2],
                Department = str[3],
                Position = str[4],
                Employee_ID = str[5]
            };
            
            return u;
        }
    }

    public class User {
        public string Employee_ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Fullname
        {
            get { return FirstName + " " +MiddleName.Substring(0,1) + ". " + LastName; }
        }
    }
}