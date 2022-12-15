using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Server.Core;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public async Task<UserDTO> loadDataById(string id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"User/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<UserDTO>(res.Body.ToString());
            return result;
        }
        public async Task<UserDTO> loadDataByPhone(string phone)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"User/");
            string resBody = res.Body.ToString();
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(resBody);
            foreach (var item in record)
            {
                if (item.Value.phone == phone)
                {
                    return item.Value;
                }
            }
            return null;
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

        public async Task create(UserDTO User)
        {
            User.id = Core.Common.DateTimeNowToBigInt();
            SetResponse response = await Client.SetTaskAsync(@"User/" + User.id.ToString(), User);
            UserDTO result = response.ResultAs<UserDTO>();
        }

        public async Task update(UserDTO User)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"User/" + User.id.ToString(), User);
            UserDTO result = response.ResultAs<UserDTO>();
        }

        public async Task delete(string id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"User/" + id.ToString());
            UserDTO result = response.ResultAs<UserDTO>();
        }

        public async Task<int> login(string username, string pass)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"User/");
            string resBody = res.Body.ToString();
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserDTO>>(resBody);
            foreach (var item in record)
            {
                if(item.Value.phone == username && item.Value.password != pass)
                {
                    return 1;
                }
                if(item.Value.phone == username && item.Value.password == pass) {
                    return 2;
                }
            }
            return 0;
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
