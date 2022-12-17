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
    class UserLogBUS
    {
        private static UserLogBUS instance;
        public static UserLogBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserLogBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await UserLogDAO.Instance.loadData();
        }

        public async Task<UserLogDTO> loadDataById(string id)
        {
            return await UserLogDAO.Instance.loadDataById(id);
        }
        public async Task create(string id, string Ip, string content, string userId)
        {
            UserLogDTO UserLog = new UserLogDTO
            {
                id = id,
                Ip = Ip,
                content = content,
                userId = userId,
                created = Core.Common.DateTimeTo_ymdhms(DateTime.Now)
            };
            await UserLogDAO.Instance.create(UserLog);
        }

        public async Task delete(string id)
        {
            await UserLogDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await UserLogDAO.Instance.search(search);
        }
 
        public async Task<DataTable> searchByField(string search, string field)
        {
            return await UserLogDAO.Instance.searchByField(search, field);
        }
    }
}
