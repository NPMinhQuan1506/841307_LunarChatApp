using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    class GroupMemberDTO
    {
        public string id { set; get; } = "";
        public string groupId { set; get; } = "";
        public string userId { set; get; } = "";
        public int role { set; get; } = 0;
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

        public DataRow convertToDataRow()
        {
            DataTable dt = new DataTable();
            dt = convertToDataTable();
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["groupId"] = this.groupId;
            dr["userId"] = this.userId;
            dr["role"] = this.role;
            dr["created"] = this.created;
            return dr;
        }

        public DataTable convertToDataTable()
        {
            DataTable dt = new DataTable();
            dt = convertToDataTable();
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("groupId");
            dt.Columns.Add("userId");
            dt.Columns.Add("role");
            dt.Columns.Add("created");
            return dt;
        }
    }
}
