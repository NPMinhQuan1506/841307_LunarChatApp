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
    class UserBlockBUS
    {
        private static UserBlockBUS instance;
        public static UserBlockBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserBlockBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await UserBlockDAO.Instance.loadData();
        }

        public async Task<UserBlockDTO> loadDataById(string id)
        {
            return await UserBlockDAO.Instance.loadDataById(id);
        }
        public async Task create(string id, string sourceId, string targetId)
        {
            UserBlockDTO UserBlock = new UserBlockDTO
            {
                id = id,
                sourceId = sourceId,
                targetId = targetId,
                created = Core.Common.DateTimeTo_ymdhms(DateTime.Now)
            };
            await UserBlockDAO.Instance.create(UserBlock);
        }

        public async Task delete(string id)
        {
            await UserBlockDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await UserBlockDAO.Instance.search(search);
        }

        public async Task<DataTable> searchByField(string search, string field)
        {
            return await UserBlockDAO.Instance.searchByField(search, field);
        }
    }
}
