using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DTO
{
    class MessageDTO
    {
        private static DataTable dt;
        public int id { set; get; } = 0;
        public int conservationId { set; get; } = 0;
        public int senderId { set; get; } = 0;
        public int receiverId { set; get; } = 0;
        public string seen { set; get; } = "";
       
        public string msg { set; get; } = "";
        public string msgType { set; get; } = "";
        public string attachmentUrl { set; get; } = "";
        public int state { set; get; } = 0; //0, 1

        public DataRow convertToDataRow()
        {
            DataRow dr = dt.NewRow();
            dr["id"] = this.id;
            dr["conservationId"] = this.conservationId;
            dr["senderId"] = this.senderId;
            dr["receiverId"] = this.receiverId;
            dr["seen"] = this.seen;
            dr["msg"] = this.msg;
            dr["msgType"] = this.msgType;
            dr["attachmentUrl"] = this.attachmentUrl;
            dr["state"] = this.state;
            return dr;
        }

        public static DataTable convertToDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("conservationId");
            dt.Columns.Add("senderId");
            dt.Columns.Add("receiverId");
            dt.Columns.Add("seen");
            dt.Columns.Add("msg");
            dt.Columns.Add("msgType");
            dt.Columns.Add("attachmentUrl");
            dt.Columns.Add("state");
            return dt;
        }
    }
}
