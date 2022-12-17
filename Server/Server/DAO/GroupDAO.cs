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
    class GroupDAO
    {
        IFirebaseClient Client;
        public GroupDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static GroupDAO instance;
        public static GroupDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GroupDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Group/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<GroupDTO> loadDataById(string id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Group/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<GroupDTO>(res.Body.ToString());
            return result;
        }


        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, GroupDTO>>(resBody);
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
        public async Task<GroupDTO> create(GroupDTO Group)
        {
            Group.id = Core.Common.DateTimeNowToBigInt();
            SetResponse response = await Client.SetTaskAsync(@"Group/" + Group.id.ToString(), Group);
            GroupDTO result = response.ResultAs<GroupDTO>();
            return result;
        }

        public async Task update(GroupDTO Group)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Group/" + Group.id.ToString(), Group);
            GroupDTO result = response.ResultAs<GroupDTO>();
        }

        public async Task delete(string id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"Group/" + id.ToString());
            GroupDTO result = response.ResultAs<GroupDTO>();
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
