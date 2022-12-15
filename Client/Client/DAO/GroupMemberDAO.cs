using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Client.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DAO
{
    class GroupMemberDAO
    {
        IFirebaseClient Client;
        public GroupMemberDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static GroupMemberDAO instance;
        public static GroupMemberDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GroupMemberDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"GroupMember/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<GroupMemberDTO> loadDataById(int id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"GroupMember/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<GroupMemberDTO>(res.Body.ToString());
            return result;
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, GroupMemberDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = GroupMemberDTO.convertToDataTable();

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
            FirebaseResponse res = await Client.GetTaskAsync(@"GroupMember/");
            string resBody = res.Body.ToString();
            var record = JsonConvert.DeserializeObject<Dictionary<string, GroupMemberDTO>>(resBody);
            var last = record.Values.Last();
            

            return last.id + 1;
        }

        public async Task create(GroupMemberDTO GroupMember)
        {
            GroupMember.id = await getLastId();
            SetResponse response = await Client.SetTaskAsync(@"GroupMember/" + GroupMember.id.ToString(), GroupMember);
            GroupMemberDTO result = response.ResultAs<GroupMemberDTO>();
        }

        public async Task update(GroupMemberDTO GroupMember)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"GroupMember/" + GroupMember.id.ToString(), GroupMember);
            GroupMemberDTO result = response.ResultAs<GroupMemberDTO>();
        }

        public async Task delete(int id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"GroupMember/" + id.ToString());
            GroupMemberDTO result = response.ResultAs<GroupMemberDTO>();
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
