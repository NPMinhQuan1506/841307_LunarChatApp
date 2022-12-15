using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DirectWrite;
using DevExpress.Office.Tsp;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Templates;
using Newtonsoft.Json;
using Server.BUS;
using Server.DAO;
using Server.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Server.GUI.Home
{
    public partial class ctrHome : DevExpress.XtraEditors.XtraUserControl
    {
        public bool isRun = false;
        private delegate void CallDelegate(string text);
        IPEndPoint iep;
        Socket server;
        Dictionary<int, Socket> ClientSocList = new Dictionary<int, Socket>(); // "id": Socket
        private byte[] data = new byte[1024];
        private int size = 1024;
        public ctrHome()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            string hostName = Dns.GetHostName();
            string myIP = "";
            IPAddress[] IPArray = Dns.GetHostByName(hostName).AddressList;
            foreach (IPAddress ip in IPArray)
            {
                if (ip.ToString().Contains('.'))
                {
                    myIP = ip.ToString();
                    break;
                }
            }
            string value = "\uD83D\uDE42";
            richTextBox1.Text = value;
            //txtIp.Text = myIP;
            txtPort.Text = "2008";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!isRun)
            {
                isRun = true;
                btnOpen.Text = "Tắt Server";
                txtStatus.Text = "Server đang chạy";
                iep = new IPEndPoint(IPAddress.Parse(txtIp.Text), int.Parse(txtPort.Text));
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                server.Bind(iep);
                server.Listen(10);
                server.BeginAccept(new AsyncCallback(AcceptClientThread), null);
            }
            else
            {
                isRun = false;
                btnOpen.Text = "Mở Server";
                txtStatus.Text = "Server tắt";
                server.Close();
            }
        }

        private void AcceptClientThread(IAsyncResult iar)
        {
            try
            {
                Socket client = server.EndAccept(iar);

                server.BeginAccept(new AsyncCallback(AcceptClientThread), null);

                //SetText("Connected from: " + client.RemoteEndPoint.ToString());

                Response res = new Response("Welcome to server");
                PackageModule common = new PackageModule("OK", JsonConvert.SerializeObject(res));
                SendData(client, common);
                ReceiveData(client);
            }
            catch (Exception)
            {
            }
        }
        private void SendData(Socket client, object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            byte[] message1 = Encoding.UTF8.GetBytes(json);
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(SendDataCallback), client);
        }
        private void SendDataCallback(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
        }

        private void ReceiveData(Socket client)
        {
            client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(handleClient), client);
        }

        private async void handleClient(IAsyncResult iar)
        {
            try
            {
                DataTable dtUser = await UserBUS.Instance.loadData();
                Socket client = (Socket)iar.AsyncState;
                int recv = client.EndReceive(iar);
                string jsonString = Encoding.ASCII.GetString(data, 0, recv);
                PackageModule conn = JsonConvert.DeserializeObject<PackageModule>(jsonString);

                if (conn != null && conn.Content != null)
                {
                    switch (conn.Kind)
                    {
                        case "LOGIN":
                            {
                                UserDTO userInfo = JsonConvert.DeserializeObject<UserDTO>(conn.Content);
                                string username = userInfo.phone.ToString();
                                string password = userInfo.password;
                                var dtU = (dtUser.AsEnumerable().Where(row => username == row.Field<String>("phone"))).CopyToDataTable<DataRow>();
                                int clientid = Convert.ToInt32(dtU.Rows[0]["id"].ToString());
                                bool isExist = dtUser.AsEnumerable().Any(row => username == row.Field<String>("phone") && password == row.Field<String>("password"));
                                if (isExist)
                                {

                                    ClientSocList.Remove(clientid);
                                    ClientSocList.Add(clientid, client);
                                    await UserBUS.Instance.update(clientid, null, null, null, 1, 0, null);

                                    ResponseToClient(client, "LOGINSUCC", $"{clientid}");
                                    ReceiveData(client);
                                    //SetText($"{username} logged in!");
                                }
                                else
                                {
                                    ResponseToClient(client, "LOGINFAIL", "Login failed!");
                                    ReceiveData(client);
                                }
                            }
                            break;
                        case "REGISTER":
                            {
                                UserDTO registerInfo = JsonConvert.DeserializeObject<UserDTO>(conn.Content);
                                string username = registerInfo.phone.ToString();
                                string password = registerInfo.password;
                                bool isExist = dtUser.AsEnumerable().Any(row => username == row.Field<String>("phone"));
                                if (isExist)
                                {
                                    ResponseToClient(client, "SIGNINFAIL", "Account has already existed!");
                                    //SetText($"{username} registered!");
                                }
                                else
                                {
                                    await UserBUS.Instance.create(0, registerInfo.name, username, password, 1, 0, registerInfo.image);
                                    ResponseToClient(client, "SIGNINSUCC", "Account was successfully created!");
                                }
                            }
                            break;
                        case "LOGOUT":
                            {
                                UserDTO logout = JsonConvert.DeserializeObject<UserDTO>(conn.Content);
                                string username = logout.phone;
                                int clientid = logout.id;
                                bool isExist = dtUser.AsEnumerable().Any(row => username == row.Field<String>("phone"));
                                if (isExist)
                                {
                                    ResponseToClient(client, "LOGOUT", "Successfully logged out!");
                                    ClientSocList.Remove(clientid);
                                    await UserBUS.Instance.update(clientid, null, null, null, 0, 0, null);
                                    //SetText($"{username} logged out!");
                                }
                            }
                            break;
                        case "CHAT":
                            MessageDTO msg = JsonConvert.DeserializeObject<MessageDTO>(conn.Content);
                            int conservId = msg.conservationId;
                            int sender = msg.senderId;
                            int receiver = msg.receiverId;
                            string content = msg.msg;
                            string msgType = msg.msgType;
                            if (conservId == 0)
                            {
                                if (sender != null && receiver != null && content != null)
                                {
                                    var conser = await ConservationBUS.Instance.create(0, sender, receiver, 0, "empty", "empty", 0);
                                    conservId = conser.id;
                                    await MessageBUS.Instance.create(0, conservId, sender, receiver, "", content, msgType, msg.attachmentUrl, 0);
                                    bool equal = ClientSocList.ContainsKey(receiver);
                                    if (equal)
                                    {
                                        //SetText($"{sender} gui {receiver}: {content + Environment.NewLine}");
                                        Socket friend = ClientSocList[receiver];
                                        SendData(friend, conn);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (sender != null && receiver != null && content != null)
                                {
                                    await MessageBUS.Instance.create(0, conservId, sender, receiver, "", content, msgType, msg.attachmentUrl, 0);
                                    var conser = await ConservationBUS.Instance.loadDataById(conservId);
                                    if (conser.groupId == 0)
                                    {
                                        bool equal = ClientSocList.ContainsKey(receiver);
                                        if (equal)
                                        {
                                            //SetText($"{sender} gui {receiver}: {content + Environment.NewLine}");
                                            Socket friend = ClientSocList[receiver];
                                            SendData(friend, conn);
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        var groupMembers = await GroupMemberBUS.Instance.loadData();
                                        bool isExist = groupMembers.AsEnumerable().Any(row => receiver == row.Field<int>("userId"));

                                        if (isExist)
                                        {
                                            var dt = (groupMembers.AsEnumerable().Where(r => r.Field<int>("GroupId") == conser.groupId)).CopyToDataTable<DataRow>();

                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                if (ClientSocList.ContainsKey(Convert.ToInt32(dr["userId"])))
                                                {
                                                    Socket friend = ClientSocList[Convert.ToInt32(dr["userId"])];
                                                    SendData(friend, conn);
                                                }
                                            }
                                            //SetText($"{sender} send to {receiver}: {content + Environment.NewLine}");
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        case "GROUP":
                            Dictionary<GroupDTO, List<GroupMemberDTO>> group = JsonConvert.DeserializeObject<Dictionary<GroupDTO, List<GroupMemberDTO>>>(conn.Content);
                            var first = group.First();
                            var groupObj = group.Keys.SingleOrDefault();
                            var groupName = groupObj.name;
                            

                            if (groupObj.id != 0)
                            {
                                var member = first.Value;
                                foreach(var item in member)
                                {
                                    await GroupMemberBUS.Instance.create(0, groupObj.id, item.userId, item.role);
                                }
                                ResponseToClient(client, "OK", "Successfully added!");

                            }
                            else
                            {
                                var groupNew = await GroupBUS.Instance.create(0, groupName, groupObj.img, 1);
                                
                                var member = first.Value;
                                foreach (var item in member)
                                {
                                    await GroupMemberBUS.Instance.create(0, groupNew.id, item.userId, item.role);
                                }
                                ResponseToClient(client, "OK", "Successfully added!");
                            }
                            break;
                        case "EDITGROUP":
                            GroupMemberDTO groupEdit = JsonConvert.DeserializeObject<GroupMemberDTO>(conn.Content);

                            if (groupEdit.id != 0)
                            {
                                await GroupMemberBUS.Instance.update(groupEdit.id, groupEdit.groupId, groupEdit.userId, groupEdit.role);
                                ResponseToClient(client, "OK", "Successfully added!");

                            }
                            break;
                        case "DELMEMGROUP":
                            GroupMemberDTO groupDel = JsonConvert.DeserializeObject<GroupMemberDTO>(conn.Content);

                            if (groupDel.id != 0)
                            {
                                await GroupMemberBUS.Instance.delete(groupDel.id);
                                ResponseToClient(client, "OK", "Successfully added!");

                            }
                            break;
                        default:
                            break;
                    }
                }

                ReceiveData(client);
            }
            catch (Exception)
            {
            }
        }
        private void ResponseToClient(Socket client, string statusCode, string message)
        {
            Response res = new Response(message);
            PackageModule common = new PackageModule(statusCode, JsonConvert.SerializeObject(res));
            SendData(client, common);
        }
    }
}
