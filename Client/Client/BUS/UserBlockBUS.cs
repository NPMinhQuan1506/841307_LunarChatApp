using Client.DAO;
using Client.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.BUS
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

        public async Task<UserBlockDTO> loadDataById(int id)
        {
            return await UserBlockDAO.Instance.loadDataById(id);
        }
        public async Task create(int id, int sourceId, int targetId)
        {
            UserBlockDTO UserBlock = new UserBlockDTO
            {
                id = id,
                sourceId = sourceId,
                targetId = targetId,
            };
            await UserBlockDAO.Instance.create(UserBlock);
        }

        //public async Task update(int id, string name, string phone, string password, int isActive, int isBlocked, string image)
        //{
        //    var item = await UserBlockDAO.Instance.loadDataById(id);

        //    UserBlockDTO UserBlock = new UserBlockDTO()
        //    {
        //        id = (int)item.id,
        //        name = name != null ? name : item.name,
        //        phone = phone != null ? phone : item.phone,
        //        password = password != null ? password : item.password,
        //        isActive = isActive != null ? isActive : item.isActive,
        //        isBlocked = isBlocked != null ? isBlocked : item.isBlocked,
        //        image = image != null ? image : item.image,
        //    };
        //    await UserBlockDAO.Instance.update(UserBlock);
        //}

        public async Task delete(int id)
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
