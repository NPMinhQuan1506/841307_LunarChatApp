using DevExpress.XtraBars;
using FireSharp.Interfaces;
using FireSharp.Response;
using Server.Core;
using Server.DAO;
using Server.DTO;
using Server.GUI.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Server.GUI
{
    public partial class frmMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
        private static Core.Common func = new Core.Common();
        GUI.Home.ctrHome ctr;
        public frmMenu()
        {
            for (int i = 0; i < 70; i++)
            {
                Thread.Sleep(70);
            }
            InitializeComponent();
            lbName.Text = "Quân Nguyễn";
        }


        private void setImageCurrentPage(string namePage)
        {
            this.lbCurrentListIcon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject(namePage + ".ImageOptions.SvgImage")));
        }


        private void frmMenu_Load(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            ctr = new GUI.Home.ctrHome();
            ctr.Dock = DockStyle.Fill;
            ctr.BringToFront();
            pnContainer.Controls.Add(ctr);
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if(Global.IdLog != 0)
            //{
            //    DateTime dtNow = DateTime.Now;
            //    string query_log = String.Format(@"Update Employee_log set ThoiGianDangXuat = '{0}', TrangThai = 0 where id = {1}", func.DateTimeToString(dtNow), Core.Global.IdLog);
            //    conn.executeDatabase(query_log);
            //    Core.Global.destroy();
            //}  
        }

        private void accConnect_Click(object sender, EventArgs e)
        {
            //setImageCurrentPage("aceImport");
            ctr.BringToFront();
        }
    }
}
