using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DirectWrite;
using DevExpress.Office.Tsp;
using DevExpress.Xpo.DB.Helpers;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Templates;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using Server.BUS;
using Server.DAO;
using Server.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Server.GUI.Home
{
    public partial class ctrHome : DevExpress.XtraEditors.XtraUserControl
    {
        public bool isRun = false;
        private delegate void CallDelegate(string text);
        IPEndPoint iep;
        Socket server;
        Dictionary<string, Socket> ClientSocList = new Dictionary<string, Socket>(); // "id": Socket
        private byte[] data = new byte[1024];
        private int size = 1024;
        IFirebaseClient Client;
        Core.Common func = new Core.Common();
        GUI.Home.ctrUserActive ctrActi;
        GUI.Home.ctrUserLog ctrHis;
        public ctrHome()
        {
            InitializeComponent();
            Client = ConnectDatabase.Instance.getClient();
            init();
            tpDetail.Controls.Clear();
            ctrActi = new GUI.Home.ctrUserActive();
            ctrActi.Dock = DockStyle.Fill;
            ctrActi.BringToFront();
            tpDetail.Controls.Add(ctrActi);

            ctrHis = new GUI.Home.ctrUserLog();
            ctrHis.Dock = DockStyle.Fill;
            ctrHis.BringToFront();
            tpOverview.Controls.Add(ctrHis);


            loadData();
        }

        private async void init()
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

            txtIp.Text = myIP;
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
                                var dtU = await UserBUS.Instance.loadDataByPhone(username);
                                string clientid = dtU.id.ToString();
                                int isExist = await UserBUS.Instance.login(username, password);
                                if (isExist == 2)
                                {

                                    ClientSocList.Remove(clientid);
                                    ClientSocList.Add(clientid, client);
                                    await UserBUS.Instance.update(clientid, null, null, null, 1, 0, null);
                                    ResponseToClient(client, "LOGINSUCC", $"{clientid}");
                                    ReceiveData(client);
                                    //SetText($"{username} logged in!");
                                }
                                else if (isExist == 1)
                                {
                                    ResponseToClient(client, "LOGINFAIL", "Sai mật khẩu!");
                                    ReceiveData(client);
                                }
                                else
                                {
                                    ResponseToClient(client, "LOGINFAIL", "User không tồn tại!");
                                    ReceiveData(client);
                                }
                            }
                            break;
                        case "REGISTER":
                            {
                                UserDTO registerInfo = JsonConvert.DeserializeObject<UserDTO>(conn.Content);
                                string username = registerInfo.phone.ToString();
                                string password = registerInfo.password;
                                int isExist = await UserBUS.Instance.login(username, password);
                                if (isExist == 1 || isExist == 2)
                                {
                                    ResponseToClient(client, "SIGNINFAIL", "Account has already existed!");
                                    //SetText($"{username} registered!");
                                }
                                else
                                {
                                    await UserBUS.Instance.create("0", registerInfo.name, username, password, 1, 0, registerInfo.image);
                                    ResponseToClient(client, "SIGNINSUCC", "Account was successfully created!");
                                }
                            }
                            break;
                        case "LOGOUT":
                            {
                                UserDTO logout = JsonConvert.DeserializeObject<UserDTO>(conn.Content);
                                string username = logout.phone;
                                string clientid = logout.id;
                                int isExist = await UserBUS.Instance.login(username, "");
                                if (isExist == 1 || isExist == 2)
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
                            string conservId = msg.conservationId;
                            string sender = msg.senderId;
                            string receiver = msg.receiverId;
                            string content = msg.msg;
                            string msgType = msg.msgType;
                            if (conservId == "0")
                            {
                                if (sender != null && receiver != null && content != null)
                                {
                                    var conser = await ConservationBUS.Instance.create("0", sender, receiver, "0", "", "", 0);
                                    conservId = conser.id;
                                    await MessageBUS.Instance.create("0", conservId, sender, receiver, "", content, msgType, msg.attachmentUrl, 0, 0);
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
                                    await MessageBUS.Instance.create("0", conservId, sender, receiver, "", content, msgType, msg.attachmentUrl, 0, 0);
                                    var conser = await ConservationBUS.Instance.loadDataById(conservId);
                                    if (conser.groupId == "0")
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
                                        bool isExist = groupMembers.AsEnumerable().Any(row => receiver == row.Field<string>("userId"));

                                        if (isExist)
                                        {
                                            var dt = (groupMembers.AsEnumerable().Where(r => r.Field<string>("GroupId") == conser.groupId)).CopyToDataTable<DataRow>();

                                            foreach (DataRow dr in dt.Rows)
                                            {
                                                if (ClientSocList.ContainsKey(dr["userId"].ToString()))
                                                {
                                                    Socket friend = ClientSocList[dr["userId"].ToString()];
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


                            if (groupObj.id != "0")
                            {
                                var member = first.Value;
                                foreach (var item in member)
                                {
                                    await GroupMemberBUS.Instance.create("0", groupObj.id, item.userId, item.role);
                                }
                                ResponseToClient(client, "OK", "Successfully added!");

                            }
                            else
                            {
                                var groupNew = await GroupBUS.Instance.create("0", groupName, groupObj.img, 1);

                                var member = first.Value;
                                foreach (var item in member)
                                {
                                    await GroupMemberBUS.Instance.create("0", groupNew.id, item.userId, item.role);
                                }
                                ResponseToClient(client, "OK", "Successfully added!");
                            }
                            break;
                        case "EDITGROUP":
                            GroupMemberDTO groupEdit = JsonConvert.DeserializeObject<GroupMemberDTO>(conn.Content);

                            if (groupEdit.id != "0")
                            {
                                await GroupMemberBUS.Instance.update(groupEdit.id, groupEdit.groupId, groupEdit.userId, groupEdit.role);
                                ResponseToClient(client, "OK", "Successfully added!");

                            }
                            break;
                        case "DELMEMGROUP":
                            GroupMemberDTO groupDel = JsonConvert.DeserializeObject<GroupMemberDTO>(conn.Content);

                            if (groupDel.id != "0")
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

        private async void txtIp_EditValueChanged(object sender, EventArgs e)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"/Settings/Ip", txtIp.Text);

        }

        private async void txtPort_EditValueChanged(object sender, EventArgs e)
        {
            FirebaseResponse response = await Client.UpdateTaskAsync(@"/Settings/Port", txtPort.Text);
        }

        private void loadData()
        {
            if (tbRevenue.SelectedIndex == 0)
            {
                ctrHis.BringToFront();
            }
            else
            {
                ctrActi.BringToFront();
            }
        }

        private void tbRevenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
