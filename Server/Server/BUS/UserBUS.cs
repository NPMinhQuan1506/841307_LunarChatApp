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
    class UserBUS
    {
        private static UserBUS instance;
        public static UserBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await UserDAO.Instance.loadData();
        }

        public async Task<UserDTO> loadDataById(int id)
        {
            return await UserDAO.Instance.loadDataById(id);
        }
        public async Task create(int id, string name, string phone, string password, int isActive, int isBlocked, string image)
        {
            UserDTO User = new UserDTO
            {
                id = id, 
                name = name, 
                phone = phone, 
                password = password , 
                isActive = isActive, 
                isBlocked = isBlocked, 
                image = image
            };
            await UserDAO.Instance.create(User);
        }

        public async Task update(int id, string name, string phone, string password, int isActive, int isBlocked, string image)
        {
            var item = await UserDAO.Instance.loadDataById(id);
            
            UserDTO User = new UserDTO()
            {
                id = (int)item.id,
                name = name != null ? name : item.name,
                phone = phone != null ? phone : item.phone,
                password = password != null ? password : item.password,
                isActive = isActive != null ? isActive : item.isActive,
                isBlocked = isBlocked != null ? isBlocked : item.isBlocked,
                image = image != null ? image : item.image,
            };
            await UserDAO.Instance.update(User);
        }

        public async Task delete(int id)
        {
            await UserDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await UserDAO.Instance.search(search);
        }

        public async Task<DataTable> searchByField(string search, string field)
        {
            return await UserDAO.Instance.searchByField(search, field);
        }
    }
}
