using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.DAO
{
    class MessageDAO
    {
        IFirebaseClient Client;
        public MessageDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static MessageDAO instance;
        public static MessageDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MessageDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Message/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<MessageDTO> loadDataById(string id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Message/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<MessageDTO>(res.Body.ToString());
            return result;
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, MessageDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = MessageDTO.convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async Task<MessageDTO> create(MessageDTO Message)
        {
            Message.id = Core.Common.DateTimeNowToBigInt();
            SetResponse response = await Client.SetTaskAsync(@"Message/" + Message.id.ToString(), Message);
            MessageDTO result = response.ResultAs<MessageDTO>();
            return result;
        }

        public async Task<MessageDTO> update(MessageDTO Message)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Message/" + Message.id.ToString(), Message);
            MessageDTO result = response.ResultAs<MessageDTO>();
            return result;
        }

        public async Task<MessageDTO> delete(string id)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Message/" + id.ToString() + "/state", 0);
            MessageDTO result = response.ResultAs<MessageDTO>();
            return result;
        }

        public async Task<DataTable> search(string searchstring)
        {
            DataTable dt = await loadData();
            IEnumerable<DataRow> filtered = dt.AsEnumerable()
                .Where(r => r.Field<String>("msg").Contains(searchstring));
            return filtered.CopyToDataTable<DataRow>();
        }

        public async Task<DataTable> searchByField(string searchstring, string field)
        {
            DataTable dt = await loadData();
            IEnumerable<DataRow> filtered = dt.AsEnumerable()
                .Where(r => r.Field<String>($"{field}").Contains(searchstring));
            return filtered.CopyToDataTable<DataRow>();
        }
    }
}
