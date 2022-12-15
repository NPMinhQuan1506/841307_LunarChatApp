using Client.BUS;
using Client.DTO;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
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

namespace Client.GUI
{
    public partial class frmMain : Form
    {
        int panelWidth;
        bool Hidden;
        int userId;
        Boolean dragging = false;
        Point startPoint = new Point(0, 0);
        UserDTO gbUser = new UserDTO();
        private delegate void AddChatDelegate(string name, string content, string pic, int userId, int groupId);
        public frmMain()
        {
            InitializeComponent();

        }
        public frmMain(int id) : this()
        {
            userId = id;
            panelWidth = PanelSlide.Width;
            Hidden = false;
            loadData();
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private async Task loadData()
        {
            var dtCons = await ConservationBUS.Instance.loadData();
            var dtUser = await UserBUS.Instance.loadData();
            var dtMsg = await MessageBUS.Instance.loadData();
            gbUser = await UserBUS.Instance.loadDataById(userId);
            var dtGroup = await GroupBUS.Instance.loadData();
            var dtGM = await GroupMemberBUS.Instance.loadData();
            var JoinResult = (dtCons.AsEnumerable().Where(p => p.Field<string>("sourceId") == gbUser.id.ToString()
                                    || p.Field<string>("targetId") == gbUser.id.ToString()
                                    || p.Field<string>("groupId") != "0"));
            var dt = JoinResult.CopyToDataTable<DataRow>();
            foreach (DataRow dr in dt.Rows)
            {
                var msgObj = (dtMsg.AsEnumerable().Where(p => p.Field<string>("conservationId") == dr["id"].ToString()))
                            .CopyToDataTable<DataRow>();
                var msg = msgObj.Rows[msgObj.Rows.Count - 1]["msg"].ToString();
                if (Convert.ToInt32(dr["groupId"]) == 0)
                {
                    if(Convert.ToInt32(dr["sourceId"]) != gbUser.id && Convert.ToInt32(dr["targetId"]) == gbUser.id)
                    {
                        var source = await UserBUS.Instance.loadDataById(Convert.ToInt32(dr["sourceId"]));
                        var sourcename = source.name.ToString();
                        msg = msg.Length > 20 ? msg.Substring(0, 20) : msg;
                        addConservation(sourcename, msg, source.image, Convert.ToInt32(dr["id"].ToString()), Convert.ToInt32(dr["groupId"].ToString()));
                    }
                    else if (Convert.ToInt32(dr["sourceId"]) == gbUser.id && Convert.ToInt32(dr["targetId"]) != gbUser.id)
                    {
                        var source = await UserBUS.Instance.loadDataById(Convert.ToInt32(dr["targetId"]));
                        var sourcename = source.name.ToString();
                        msg = msg.Length > 20 ? msg.Substring(0, 20) : msg;
                        addConservation(sourcename, msg, source.image, Convert.ToInt32(dr["id"].ToString()), Convert.ToInt32(dr["groupId"].ToString()));
                    }
                }
                else
                {
                    var group = await GroupBUS.Instance.loadDataById(Convert.ToInt32(dr["groupId"]));
                    var groupname = group.name.ToString();
                    msg = msg.Length > 20 ? msg.Substring(0, 20) : msg;
                    addConservation("Nhóm " + groupname, msg, group.img, Convert.ToInt32(dr["id"].ToString()), Convert.ToInt32(dr["groupId"].ToString()));
                }
            }
        }

        private void addConservation(string name, string content, string pic, int conserId, int groupId)
        {
            if (pnConser.InvokeRequired)
            {
                var dlg = new AddChatDelegate(addConservation);
                pnConser.Invoke(dlg, new object[] { name, content, pic, conserId, groupId });
            }
            else
            {
                Custom.UCConservation item = new Client.GUI.Custom.UCConservation();
                item.BackColor = System.Drawing.Color.DimGray;
                item.Dock = System.Windows.Forms.DockStyle.Top;
                item.Location = new System.Drawing.Point(0, 53);
                item.ProfilePic = null;
                item.Size = new System.Drawing.Size(269, 81);
                item.TabIndex = 3;
                item.txtName = name;
                item.txtStatus = content;
                item.conserId = conserId;
                item.groupId = groupId;

                //DevExpress.XtraEditors.SimpleButton btnChat = new DevExpress.XtraEditors.SimpleButton();
                //btnChat.Location = new System.Drawing.Point(170, 47);
                //btnChat.Size = new System.Drawing.Size(94, 29);
                //btnChat.TabIndex = 0;
                //btnChat.Text = "chat";
                //item.Controls.Add(btnChat);
                //btnChat.BringToFront();

                //btnChat.Click += new System.EventHandler(this.UserControler_Click);
                pnConser.Controls.Add(item);
                item.pnGrid.Click += new System.EventHandler(this.UserControler_Click);
            }

        }
        private void UserControler_Click(Object sender, EventArgs e)
        {
            var obj = (SimpleButton)sender;
            var uc = (Custom.UCConservation)obj.Parent;
            panel4.Controls.Clear();
            GUI.Custom.UCChatItem ctr = new GUI.Custom.UCChatItem(uc.conserId, uc.groupId, userId);
            ctr.Dock = DockStyle.Fill;
            panel4.Controls.Add(ctr);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                PanelSlide.Width = PanelSlide.Width + 10;
                if (PanelSlide.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                PanelSlide.Width = PanelSlide.Width - 10;
                if (PanelSlide.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucConservation1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);

        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Region = DevExpress.Utils.Drawing.Helpers.NativeMethods.CreateRoundRegion(new Rectangle(Point.Empty, Size), 9);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point screenPoint = PointToScreen(e.Location);
                Location = new Point(screenPoint.X - this.startPoint.X, screenPoint.Y - this.startPoint.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }
    }
}
