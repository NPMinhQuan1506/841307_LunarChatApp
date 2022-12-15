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
        public int id { set; get; } = 0;
        public int sourceId { set; get; } = 0;
        public int targetId { set; get; } = 0;

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["sourceId"] = this.sourceId;
            dr["targetId"] = this.targetId;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("sourceId");
            dt.Columns.Add("targetId");
            return dt;
        }
    }
}
