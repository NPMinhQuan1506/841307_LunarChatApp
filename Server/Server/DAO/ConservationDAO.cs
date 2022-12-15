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

        public async Task<ConservationDTO> loadDataById(string id)
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

        public async Task<ConservationDTO> create(ConservationDTO Conservation)
        {
            Conservation.id = Core.Common.DateTimeNowToBigInt();
            SetResponse response = await Client.SetTaskAsync(@"Conservation/" + Conservation.id.ToString(), Conservation);
            ConservationDTO result = response.ResultAs<ConservationDTO>();
            return result;
        }

        public async Task<ConservationDTO> update(ConservationDTO Conservation)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"Conservation/" + Conservation.id.ToString(), Conservation);
            ConservationDTO result = response.ResultAs<ConservationDTO>();
            return result;
        }

        public async Task delete(string id)
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
