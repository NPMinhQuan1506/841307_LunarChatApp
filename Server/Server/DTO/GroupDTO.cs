using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    class GroupDTO
    {
        private static DataTable dt;
        public string id { set; get; } = "";
        public string name { set; get; } = "";
        public string img { set; get; } = "";
        public int status { set; get; } = 0;
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["name"] = this.name;
            dr["img"] = this.img;
            dr["status"] = this.status;
            dr["created"] = this.created;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("img");
            dt.Columns.Add("status");
            dt.Columns.Add("created");
            return dt;
        }
    }
}
