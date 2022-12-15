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
        public string id { set; get; } = "";
        public string conservationId { set; get; } = "";
        public string senderId { set; get; } = "";
        public string receiverId { set; get; } = "";
        public string seen { set; get; } = "";
       
        public string msg { set; get; } = "";
        public string msgType { set; get; } = "";
        public string attachmentUrl { set; get; } = "";
        public int state { set; get; } = 0; //0, 1
        public int react { set; get; } = 0; 
        public string created { set; get; } = Core.Common.DateTimeTo_ymdhms(DateTime.Now);

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
            dr["react"] = this.state;
            dr["created"] = this.state;
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
            dt.Columns.Add("react");
            dt.Columns.Add("created");
            return dt;
        }
    }
}
