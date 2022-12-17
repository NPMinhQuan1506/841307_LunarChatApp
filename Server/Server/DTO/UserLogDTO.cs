using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class UserLogDTO
    {
        public string id { set; get; } = "";
        public string Ip { set; get; } = "";
        public string content { set; get; } = "";
        public string userId { set; get; } = "";
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

        public DataRow convertToDataRow()
        {
            DataTable dt = new DataTable();
            dt = convertToDataTable();
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["Ip"] = this.Ip;
            dr["content"] = this.content;
            dr["userId"] = this.userId;
            dr["created"] = this.created;
            return dr;
        }

        public DataTable convertToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("Ip");
            dt.Columns.Add("content");
            dt.Columns.Add("userId");
            dt.Columns.Add("created");

            return dt;

        }
    }
}
