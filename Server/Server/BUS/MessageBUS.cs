using DevExpress.XtraRichEdit.Model;
using Server.DAO;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server.BUS
{
    class MessageBUS
    {
        private static MessageBUS instance;
        public static MessageBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new MessageBUS();
                return instance;
            }
        }

        public async Task<DataTable> loadData()
        {
            return await MessageDAO.Instance.loadData();
        }

        public async Task<MessageDTO> loadDataById(string id)
        {
            return await MessageDAO.Instance.loadDataById(id);
        }
        public async Task<MessageDTO> create(string id, string conservationId, string senderId, string receiverId, string seen, string msg, string msgType, string attachmentUrl, int state, int react)
        {
            MessageDTO Message = new MessageDTO()
            {
                id = id, 
                conservationId = conservationId, 
                senderId = senderId, 
                receiverId = receiverId, 
                seen = seen,
                msg = msg, 
                msgType = msgType, 
                attachmentUrl = attachmentUrl, 
                state = state,
                react = react,
                created = Core.Common.DateTimeTo_ymdhms(DateTime.Now)
            };
            return await MessageDAO.Instance.create(Message);
        }

        public async Task<MessageDTO> update(string id, string conservationId, string senderId, string receiverId, string seen, string msg, string msgType, string attachmentUrl, int state, int react)
        {
            var item = await MessageDAO.Instance.loadDataById(id);

            MessageDTO Message = new MessageDTO()
            {
                id = item.id,
                conservationId = item.conservationId,
                senderId = item.senderId,
                receiverId = item.receiverId,
                seen = seen != null ? seen : item.seen,
                msg = item.msg,
                msgType = item.msgType,
                attachmentUrl = item.attachmentUrl,
                state = state != null ? state : item.state,
                react = react,
                created = item.created,
            };
            return await MessageDAO.Instance.update(Message);
        }

        public async Task<MessageDTO> delete(string id)
        {
            return await MessageDAO.Instance.delete(id).ConfigureAwait(false);
        }

        public async Task<DataTable> search(string search)
        {
            return await MessageDAO.Instance.search(search);
        }

        public async Task<DataTable> searchByField(string search, string field)
        {
            return await MessageDAO.Instance.searchByField(search, field);
        }

    }
}
