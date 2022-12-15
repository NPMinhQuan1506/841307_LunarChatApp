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
    class UserDAO
    {
        IFirebaseClient Client;
        public UserDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"User/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<UserDTO> loadDataById(int id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"User/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<UserDTO>(res.Body.ToString());
            return result;
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = UserDTO.convertToDataTable();

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
            FirebaseResponse res = await Client.GetTaskAsync(@"User/");
            string resBody = res.Body.ToString();
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(resBody);
            var last = record.Values.Last();


            return last.id + 1;
        }

        public async Task create(UserDTO User)
        {
            User.id = await getLastId();
            SetResponse response = await Client.SetTaskAsync(@"User/" + User.id.ToString(), User);
            UserDTO result = response.ResultAs<UserDTO>();
        }

        public async Task update(UserDTO User)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"User/" + User.id.ToString(), User);
            UserDTO result = response.ResultAs<UserDTO>();
        }

        public async Task delete(int id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"User/" + id.ToString());
            UserDTO result = response.ResultAs<UserDTO>();
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
