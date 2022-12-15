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

namespace Client.DAO
{
    class ConservationDAO
    {
        IFirebaseClient Client;
        public ConservationDAO()
        {
            Client = ConnectDatabase.Instance.getClient();
        }
        private static ConservationDAO instance;
        public static ConservationDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConservationDAO();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Conservation/");
            string resBody = res.Body.ToString();
            return populateData(resBody);
        }

        public async Task<ConservationDTO> loadDataById(int id)
        {
            FirebaseResponse res = await Client.GetTaskAsync(@"Conservation/" + id.ToString() + @"/");
            var result = JsonConvert.DeserializeObject<ConservationDTO>(res.Body.ToString());
            return result;
        }

        private DataTable populateData(string resBody)
        {
            var record = JsonConvert.DeserializeObject<Dictionary<string, ConservationDTO>>(resBody);
            DataTable dt = new DataTable();
            dt = ConservationDTO.convertToDataTable();

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
            FirebaseResponse res = await Client.GetTaskAsync(@"Conservation/");
            string resBody = res.Body.ToString();
            var record = JsonConvert.DeserializeObject<Dictionary<string, ConservationDTO>>(resBody);
            var last = record.Values.Last();


            return last.id + 1;
        }
        public async Task<ConservationDTO> create(ConservationDTO Conservation)
        {
            Conservation.id = await getLastId();
            SetResponse response = await Client.SetTaskAsync(@"Conservation/" + Conservation.id.ToString(), Conservation);
            ConservationDTO result = response.ResultAs<ConservationDTO>();
            return result;
        }

        public async Task update(ConservationDTO Conservation)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Conservation/" + Conservation.id.ToString(), Conservation);
            ConservationDTO result = response.ResultAs<ConservationDTO>();
        }

        public async Task delete(int id)
        {
            FirebaseResponse response = await Client.DeleteTaskAsync(@"Conservation/" + id.ToString());
            ConservationDTO result = response.ResultAs<ConservationDTO>();
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
