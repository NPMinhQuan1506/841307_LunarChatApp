using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DTO
{
    class GroupMemberDTO
    {
        private static DataTable dt;
        public int id { set; get; } = 0;
        public int groupId { set; get; } = 0;
        public int userId { set; get; } = 0;
        public int role { set; get; } = 0;

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["groupId"] = this.groupId;
            dr["userId"] = this.userId;
            dr["role"] = this.role;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("groupId");
            dt.Columns.Add("userId");
            dt.Columns.Add("role");
            return dt;
        }
    }
}
