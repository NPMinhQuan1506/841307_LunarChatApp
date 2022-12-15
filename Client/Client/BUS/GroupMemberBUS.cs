using DevExpress.XtraDiagram.Bars;
using Client.DAO;
using Client.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Client.BUS
{
    class GroupMemberBUS
    {
        private static GroupMemberBUS instance;
        public static GroupMemberBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GroupMemberBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await GroupMemberDAO.Instance.loadData();
        }

        public async Task<GroupMemberDTO> loadDataById(int id)
        {
            return await GroupMemberDAO.Instance.loadDataById(id);
        }

        public async Task create(int id, int groupId, int userId, int role)
        {
            GroupMemberDTO GroupMember = new GroupMemberDTO
            {
                id = id, 
                groupId = id, 
                userId = userId, 
                role = role
            };
            await GroupMemberDAO.Instance.create(GroupMember);
        }

        public async Task update(int id, int groupId, int userId, int role)
        {
            var item = await GroupMemberDAO.Instance.loadDataById(id);

            GroupMemberDTO GroupMember = new GroupMemberDTO()
            {
                id = item.id,
                groupId = groupId != groupId ? groupId : item.groupId,
                userId = userId != userId ? userId : item.userId,
                role = role != role ? role : item.role
            };
            await GroupMemberDAO.Instance.update(GroupMember);
        }

        public async Task delete(int id)
        {
             await GroupMemberDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await GroupMemberDAO.Instance.search(search);
        }

        public async Task<DataTable> searchByField(string search, string field)
        {
            return await GroupMemberDAO.Instance.searchByField(search, field);
        }
    }
}
