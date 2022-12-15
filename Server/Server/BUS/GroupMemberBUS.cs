using DevExpress.XtraDiagram.Bars;
using Server.DAO;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Server.BUS
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

        public async Task<GroupMemberDTO> loadDataById(string id)
        {
            return await GroupMemberDAO.Instance.loadDataById(id);
        }

        public async Task create(string id, string groupId, string userId, int role)
        {
            GroupMemberDTO GroupMember = new GroupMemberDTO
            {
                id = id, 
                groupId = id, 
                userId = userId, 
                role = role,
                created = Core.Common.DateTimeTo_ymdhms(DateTime.Now)
            };
            await GroupMemberDAO.Instance.create(GroupMember);
        }

        public async Task update(string id, string groupId, string userId, int role)
        {
            var item = await GroupMemberDAO.Instance.loadDataById(id);

            GroupMemberDTO GroupMember = new GroupMemberDTO()
            {
                id = item.id,
                groupId = groupId != groupId ? groupId : item.groupId,
                userId = userId != userId ? userId : item.userId,
                role = role != role ? role : item.role,
                created = item.created
            };
            await GroupMemberDAO.Instance.update(GroupMember);
        }

        public async Task delete(string id)
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
