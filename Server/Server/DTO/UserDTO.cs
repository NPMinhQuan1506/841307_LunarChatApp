using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class UserDTO
    {
        public string id { set; get; } = "";
        public string name { set; get; } = "";
        public string phone { set; get; } = "";
        public string password { set; get; } = "";
        public int isActive { set; get; } = 0;
        public int isBlocked { set; get; } = 0;
        public string image { set; get; } = "";
        public string lastsignin { set; get; } = Core.Common.DateTimeNowToBigInt();
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

        public DataRow convertToDataRow()
        {
            DataTable dt = new DataTable();
            dt = convertToDataTable();
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["name"] = this.name;
            dr["phone"] = this.phone;
            dr["password"] = this.password;
            dr["isActive"] = this.isActive;
            dr["isBlocked"] = this.isBlocked;
            dr["image"] = this.image;
            dr["lastsignin"] = this.lastsignin;
            dr["created"] = this.created;
            return dr;
        }

        public DataTable convertToDataTable()
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("phone");
            dt.Columns.Add("password");
            dt.Columns.Add("isActive");
            dt.Columns.Add("isBlocked");
            dt.Columns.Add("image");
            dt.Columns.Add("lastsignin");
            dt.Columns.Add("created");
            return dt;
        }
    }
}
