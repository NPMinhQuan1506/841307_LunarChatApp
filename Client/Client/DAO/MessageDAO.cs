using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Client.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Client.DAO
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

        public async Task<MessageDTO> loadDataById(int id)
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
        private async Task<int> getLastId()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Message/");
            string resBody = res.Body.ToString();
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(resBody);
            var last = record.Values.Last();


            return last.id + 1;
        }

        public async Task create(MessageDTO Message)
        {
            Message.id = await getLastId();
            SetResponse response = await Client.SetTaskAsync(@"Message/" + Message.id.ToString(), Message);
            MessageDTO result = response.ResultAs<MessageDTO>();
        }

        public async Task update(MessageDTO Message)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Message/" + Message.id.ToString(), Message);
            MessageDTO result = response.ResultAs<MessageDTO>();
        }

        public async Task delete(int id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"Message/" + id.ToString());
            MessageDTO result = response.ResultAs<MessageDTO>();
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
