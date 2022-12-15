using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    class GroupDTO
    {
        private static DataTable dt;
        public int id { set; get; } = 0;
        public string name { set; get; } = "";
        public string img { set; get; } = "";
        public int status { set; get; } = 0;

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["name"] = this.name;
            dr["img"] = this.img;
            dr["status"] = this.status;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("img");
            dt.Columns.Add("status");
            return dt;
        }
    }
}
