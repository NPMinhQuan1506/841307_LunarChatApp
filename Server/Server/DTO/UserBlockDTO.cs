using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    class UserBlockDTO
    {
        private static DataTable dt;
        public string id { set; get; } = "";
        public string sourceId { set; get; } = "";
        public string targetId { set; get; } = "";
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["sourceId"] = this.sourceId;
            dr["targetId"] = this.targetId;
            dr["created"] = this.targetId;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("sourceId");
            dt.Columns.Add("targetId");
            dt.Columns.Add("created");
            return dt;
        }
    }
}
