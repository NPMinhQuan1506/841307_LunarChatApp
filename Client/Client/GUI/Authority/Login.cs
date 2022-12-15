using Client.BUS;
using Client.DAO;
using Client.DTO;
using Client.GUI.Notification;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraBars.Customization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.Authority
{
    public partial class Login : Form
    {
        private byte[] data = new byte[1024];
        Boolean dragging = false;
        Point startPoint = new Point(0, 0);
        private delegate void hideForm();
        public Login()
        {
            InitializeComponent();
        }
        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)13)
            {
                if (Core.Global.isConnected)
                {
                    string username = txtAccount.Text;
                    string password = txtPassword.Text;

                    if (username != null && password != null)
                    {
                        UserDTO userInfo = new UserDTO
                        {
                            phone = username,
                            password = password
                        };
                        PackageModule common = new PackageModule("LOGIN", JsonConvert.SerializeObject(userInfo));
                        SendData(Core.Global.client, common);
                        ReceiveData(Core.Global.client);
                    }
                }
            }
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (Core.Global.isConnected)
            {
                string username = txtAccount.Text;
                string password = txtPassword.Text;

                if (username != null && password != null)
                {
                    UserDTO userInfo = new UserDTO
                    {
                        phone = username,
                        password = password
                    };
                    PackageModule common = new PackageModule("LOGIN", JsonConvert.SerializeObject(userInfo));
                    SendData(Core.Global.client, common);
                    ReceiveData(Core.Global.client);
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
                        case "LOGINSUCC":
                            {
                                Response response = JsonConvert.DeserializeObject<Response>(conn.Content);
                                var id = Convert.ToInt32(response.Content);
                                var user = await UserBUS.Instance.loadDataById(id);
                                var usr = await UserBUS.Instance.loadData();
                                MyMessageBox.ShowMessage($"{user.name} đăng nhập thành công!");

                                frmMain frm = new frmMain(id);
                                ShowHideForm(this, false);
                                frm.ShowDialog();
                                this.Show();

                            }
                            break;
                        case "LOGINFAIL":
                            {
                                Response response = JsonConvert.DeserializeObject<Response>(conn.Content);
                                MyMessageBox.ShowMessage(response.Content);
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

        private void ShowHideForm(Form form, bool show /* otherwise hide */)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new Action<Form, bool>((formInstance, isShow) => {
                    if (isShow)
                        formInstance.Show();
                    else
                        formInstance.Hide();
                }), form, show);
            }
            else
            {
                if (show)
                    form.Show();
                else
                    form.Hide();
            } //if
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);

        }

        private void Login_Shown(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);

        }

        private void pnHeader_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnHeader_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point screenPoint = PointToScreen(e.Location);
                Location = new Point(screenPoint.X - this.startPoint.X, screenPoint.Y - this.startPoint.Y);
            }
        }
    }
}
