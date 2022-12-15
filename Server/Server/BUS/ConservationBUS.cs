using Server.DAO;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.BUS
{
    class ConservationBUS
    {
        private static ConservationBUS instance;
        public static ConservationBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConservationBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await ConservationDAO.Instance.loadData();
        }

        public async Task<ConservationDTO> loadDataById(int id)
        {
            return await ConservationDAO.Instance.loadDataById(id);
        }
        public async Task<ConservationDTO> create(int id, int sourceId, int targetId, int groupId, string sourceAlias, string targetAlias, int status)
        {
            ConservationDTO Conservation = new ConservationDTO
            {
                id = id, 
                sourceId = sourceId, 
                targetId = targetId, 
                groupId = groupId, 
                sourceAlias = sourceAlias != null ? sourceAlias : "empty", 
                targetAlias = targetAlias != null ? targetAlias : "empty",
                status = status
            };
            var result = await ConservationDAO.Instance.create(Conservation);
            return result;
        }

        public async Task update(int id, int sourceId, int targetId, int groupId, string sourceAlias, string targetAlias, int status)
        {
            var item = await ConservationDAO.Instance.loadDataById(id);
            ConservationDTO Conservation = new ConservationDTO
            {
                id = item.id,
                sourceId = sourceId != null ? sourceId : item.sourceId,
                targetId = targetId != null ? targetId : item.targetId,
                groupId = groupId != null ? groupId : item.groupId,
                sourceAlias = sourceAlias != null ? sourceAlias : item.sourceAlias,
                targetAlias = targetAlias != null ? targetAlias : item.targetAlias,
                status = status != null ? status : item.status,
            };
            await ConservationDAO.Instance.update(Conservation);
        }

        public async Task delete(int id)
        {
            await ConservationDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await ConservationDAO.Instance.search(search);
        }

        public async Task<DataTable> searchByField(string search, string field)
        {
            return await ConservationDAO.Instance.searchByField(search, field);
        }
    }
}
