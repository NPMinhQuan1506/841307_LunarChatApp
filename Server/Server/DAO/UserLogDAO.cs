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
    public class UserLogDAO
    {
        IFirebaseClient Client;
        public UserLogDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static UserLogDAO instance;
        public static UserLogDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserLogDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"UserLog/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<UserLogDTO> loadDataById(string id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"UserLog/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<UserLogDTO>(res.Body.ToString());
            return result;
        }
        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, UserLogDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = record.Values.FirstOrDefault().convertToDataTable();

            foreach (var item in record)
            {
                DataRow dr = dt.NewRow();
                dr = item.Value.convertToDataRow();
                dt.Rows.Add(dr.ItemArray);
            }

            return dt;

        }

        public async Task create(UserLogDTO UserLog)
        {
            UserLog.id = Core.Common.DateTimeNowToBigInt();
            SetResponse response = await Client.SetTaskAsync(@"UserLog/" + UserLog.id.ToString(), UserLog);
            UserLogDTO result = response.ResultAs<UserLogDTO>();
        }

        public async Task update(UserLogDTO UserLog)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"UserLog/" + UserLog.id.ToString(), UserLog);
            UserLogDTO result = response.ResultAs<UserLogDTO>();
        }

        public async Task delete(string id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"UserLog/" + id.ToString());
            UserLogDTO result = response.ResultAs<UserLogDTO>();
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
