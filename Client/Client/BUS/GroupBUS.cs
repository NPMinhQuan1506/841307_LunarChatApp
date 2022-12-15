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
    class GroupBUS
    {
        private static GroupBUS instance;
        public static GroupBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GroupBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await GroupDAO.Instance.loadData();
        }

        public async Task<GroupDTO> loadDataById(int id)
        {
            return await GroupDAO.Instance.loadDataById(id);
        }
        public async Task<GroupDTO> create(int id, string name, string img, int status)
        {
            GroupDTO Group = new GroupDTO
            {
                id = id,
                name = name,
                img = img,
                status = status
            };
            var result = await GroupDAO.Instance.create(Group);
            return result;
        }

        public async Task update(int id, string name, string img, int status)
        {
            var item = await GroupDAO.Instance.loadDataById(id);
            GroupDTO Group = new GroupDTO
            {
                id = item.id,
                name = name != null ? name : item.name,
                img = img != null ? img : item.img,
                status = status != null ? status : item.status,
            };
            await GroupDAO.Instance.update(Group);
        }

        public async Task delete(int id)
        {
            await GroupDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await GroupDAO.Instance.search(search);
        }

        public async Task<DataTable> searchByField(string search, string field)
        {
            return await GroupDAO.Instance.searchByField(search, field);
        }
    }
}
