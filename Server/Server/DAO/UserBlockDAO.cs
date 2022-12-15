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

namespace Server.DAO
{
    class UserBlockDAO
    {
        IFirebaseClient Client;
        public UserBlockDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static UserBlockDAO instance;
        public static UserBlockDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserBlockDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"UserBlock/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<UserBlockDTO> loadDataById(int id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"UserBlock/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<UserBlockDTO>(res.Body.ToString());
            return result;
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserBlockDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = UserBlockDTO.convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr);
            }

            return dt;

        }

        public async Task create(UserBlockDTO UserBlock)
        {
            SetResponse response = await Client.SetTaskAsync(@"UserBlock/" + UserBlock.id, UserBlock);
            UserBlockDTO result = response.ResultAs<UserBlockDTO>();
        }

        public async Task update(UserBlockDTO UserBlock)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"UserBlock/" + UserBlock.id, UserBlock);
            UserBlockDTO result = response.ResultAs<UserBlockDTO>();
        }

        public async Task delete(int id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"UserBlock/" + id.ToString());
            UserBlockDTO result = response.ResultAs<UserBlockDTO>();
        }

        public async Task<DataTable> search(string searchstring)
        {
            DataTable dt = await loadData();
            IEnumerable<DataRow> filtered = dt.AsEnumerable()
                .Where(r => r.Field<String>("name").Contains(searchstring)
                       || r.Field<String>("phone").Contains(searchstring));
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
