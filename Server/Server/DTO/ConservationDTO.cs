using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    class ConservationDTO
    {
        private static DataTable dt;
        public string id { set; get; } = "";
        public string sourceId { set; get; } = "";
        public string targetId { set; get; } = "";
        public string groupId { set; get; } = "";
        public string sourceAlias { set; get; } = "";
        public string targetAlias { set; get; } = "";
        public int status { set; get; } = 0; //-1, 0, 1, 2
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["sourceId"] = this.sourceId;
            dr["targetId"] = this.targetId;
            dr["groupId"] = this.groupId;
            dr["sourceAlias"] = this.sourceAlias;
            dr["targetAlias"] = this.targetAlias;
            dr["status"] = this.status; //-1 source block; -2 target block; 0 target not reply; 1 target rep; 2 accept
            dr["created"] = this.created;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("sourceId");
            dt.Columns.Add("targetId");
            dt.Columns.Add("groupId");
            dt.Columns.Add("sourceAlias");
            dt.Columns.Add("targetAlias");
            dt.Columns.Add("status");
            dt.Columns.Add("created");
            return dt;
        }
    }
}
