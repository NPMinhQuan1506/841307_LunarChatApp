using Client.BUS;
using Client.DAO;
using Client.DTO;
using Client.GUI.Notification;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils.Drawing.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Client.GUI.Custom
{
    public partial class UCChatItem : UserControl
    {
        private byte[] data = new byte[1024];
        private int conserId;
        private int groupId;
        private int currentId;
        private delegate void AddChatDelegate(string name, string content, string pic);
        private delegate void AddChatDelegate1(string name, string content, string pic);
        private UserDTO gbUser;
        private ConservationDTO gbCons;
        public UCChatItem()
        {
            InitializeComponent();
        }
        public UCChatItem(int conserId, int groupId, int currentId) : this()
        {
            this.conserId = conserId;
            this.groupId = groupId;
            this.currentId = currentId;
            loadData();
        }

        private async void loadData()
        {
            gbUser = await UserBUS.Instance.loadDataById(currentId);
            gbCons = await ConservationBUS.Instance.loadDataById(conserId);
            var dtMsg = await MessageBUS.Instance.loadData();
            var msgObj = (dtMsg.AsEnumerable().Where(p => p.Field<string>("conservationId") == conserId.ToString()))
                           .CopyToDataTable<DataRow>();
                if(groupId == 0)
                {
                    var recever = await UserBUS.Instance.loadDataById(gbCons.targetId);
                    lbName.Text = recever.name;
                }
                else
                {
                    var group = await GroupBUS.Instance.loadDataById(groupId);
                    lbName.Text = group.name;
                }
            foreach (DataRow dr in msgObj.Rows)
            {
                if (Convert.ToInt32(dr["senderId"]) == gbUser.id)
                {
                    addMyChat(gbUser.name, dr["msg"].ToString(), gbUser.image);
                }
                else
                {
                    var senderobj = await UserBUS.Instance.loadDataById(Convert.ToInt32(dr["senderId"]));

                    addYourChat(senderobj.name,dr["msg"].ToString(), senderobj.image);
                }
            }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Core.Global.isConnected)
            {
                string chat = txtChat.Text;
                

                if (chat != null)
                {
                    MessageDTO userInfo = new MessageDTO
                    {
                        conservationId = conserId,
                        senderId = gbUser.id,
                        receiverId = groupId == 0 ? gbCons.targetId : gbCons.groupId,
                        msg = chat,
                        msgType = "text",
                        state = 0
                    };
                    PackageModule common = new PackageModule("CHAT", JsonConvert.SerializeObject(userInfo));
                    SendData(Core.Global.client, common);
                    ReceiveData(Core.Global.client);
                    addMyChat(gbUser.name, chat, gbUser.image);
                    txtChat.Text = "";
                }
            }
        }

        private void txtChat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (Core.Global.isConnected)
                {
                    string chat = txtChat.Text;


                    if (chat != null)
                    {
                        MessageDTO userInfo = new MessageDTO
                        {
                            conservationId = conserId,
                            senderId = gbUser.id,
                            receiverId = groupId == 0 ? gbCons.targetId : gbCons.groupId,
                            msg = chat,
                            msgType = "text",
                            state = 0
                        };
                        PackageModule common = new PackageModule("CHAT", JsonConvert.SerializeObject(userInfo));
                        SendData(Core.Global.client, common);
                        ReceiveData(Core.Global.client);
                        addMyChat(gbUser.name, chat, gbUser.image);
                        txtChat.Text = "";
                    }
                }
            }
        }
        private void SendData(Socket client, object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            byte[] message1 = Encoding.ASCII.GetBytes(json);
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(SendDataCallback), client);
        }
        private void SendDataCallback(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
        }
        private void ReceiveData(Socket socket)
        {
            socket.BeginReceive(data, 0, data.Length, SocketFlags.None, new AsyncCallback(ThreadTask), socket);
        }
        private async void ThreadTask(IAsyncResult iar)
        {
            try
            {
                Socket remote = (Socket)iar.AsyncState;
                int recv = remote.EndReceive(iar);
                string json = Encoding.UTF8.GetString(data, 0, recv);
                PackageModule conn = JsonConvert.DeserializeObject<PackageModule>(json);

                if (conn != null)
                {
                    switch (conn.Kind)
                    {
                        case "CHAT":
                            {
                                MessageDTO msg = JsonConvert.DeserializeObject<MessageDTO>(conn.Content);
                                int sender = msg.senderId;
                                if(sender == gbUser.id)
                                {
                                    //addMyChat(gbUser.name, msg.msg, gbUser.image);
                                }
                                else
                                {
                                    var senderobj = await UserBUS.Instance.loadDataById(msg.senderId);
                                   
                                    addYourChat(senderobj.name, msg.msg, senderobj.image);
                                }
                            }
                            break;
                        default:
                            {
                                //Response response = JsonConvert.DeserializeObject<Response>(conn.Content);
                                //MyMessageBox.ShowMessage("No");
                                Console.WriteLine(json);
                            }
                            break;
                    }
                }

                ReceiveData(Core.Global.client);
            }
            catch (Exception)
            {
            }
        }

        private void addMyChat(string name, string content, string pic)
        {
            if (pnMsg.InvokeRequired)
            {
                var dlg = new AddChatDelegate(addMyChat);
                pnMsg.Invoke(dlg, new object[] { name, content, pic });
            }
            else
            {
                Custom.UCMyMessage item = new Client.GUI.Custom.UCMyMessage();
                item.BackColor = System.Drawing.Color.DimGray;
                item.Dock = System.Windows.Forms.DockStyle.Bottom;
                item.Location = new System.Drawing.Point(0, 53);
                item.ProfilePic = null;
                item.Size = new System.Drawing.Size(269, 81);
                item.txtName = content;
                item.sendertxt = name;
                pnMsg.Controls.Add(item);
            }

        }
        private void addYourChat(string name, string content, string pic)
        {
            if (pnMsg.InvokeRequired)
            {
                var dlg = new AddChatDelegate1(addYourChat);
                pnMsg.Invoke(dlg, new object[] { name, content, pic });
            }
            else
            {
                Custom.UCYourMessage item = new Client.GUI.Custom.UCYourMessage();
                item.BackColor = System.Drawing.Color.DimGray;
                item.Dock = System.Windows.Forms.DockStyle.Bottom;
                item.Location = new System.Drawing.Point(0, 53);
                item.ProfilePic = null;
                item.Size = new System.Drawing.Size(269, 81);
                item.txtName = content;
                item.sendertxt = name;
                pnMsg.Controls.Add(item);
            }

        }
    }
}
