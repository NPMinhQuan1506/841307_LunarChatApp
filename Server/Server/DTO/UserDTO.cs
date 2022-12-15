using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    internal class UserDTO
    {
        private static DataTable dt;
        public int id { set; get; } = 0;
        public string name { set; get; } = "";
        public string phone { set; get; } = "";
        public string password { set; get; } = "";
        public int isActive { set; get; } = 0;
        public int isBlocked { set; get; } = 0;
        public string image { set; get; } = "";

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["name"] = this.name;
            dr["phone"] = this.phone;
            dr["password"] = this.password;
            dr["isActive"] = this.isActive;
            dr["isBlocked"] = this.isBlocked;
            dr["image"] = this.image;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("phone");
            dt.Columns.Add("password");
            dt.Columns.Add("isActive");
            dt.Columns.Add("isBlocked");
            dt.Columns.Add("image");
            return dt;
        }
    }
}
