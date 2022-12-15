using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    class ConservationDTO
    {
        private static DataTable dt;
        public int id { set; get; } = 0;
        public int sourceId { set; get; } = 0;
        public int targetId { set; get; } = 0;
        public int groupId { set; get; } = 0;
        public string sourceAlias { set; get; } = "empty";
        public string targetAlias { set; get; } = "empty";
        public int status { set; get; } = 0; //-1, 0, 1, 2

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
            return dt;
        }
    }
}
