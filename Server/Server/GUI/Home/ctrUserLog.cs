using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraWaitForm;
using FireSharp.Interfaces;
using Server.BUS;
using Server.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Server.GUI.Home
{
    public partial class ctrUserLog : DevExpress.XtraEditors.XtraUserControl
    {
        private delegate void tbDelegate(IEnumerable dt);
        public bool isRun = false;
        private volatile bool isWorking = false;
        IFirebaseClient Client;
        //defind variable
        string emptyGridText = "Không có dữ liệu";
        DataTable dtContent;
        Core.Common func = new Core.Common();
        Timer timer1;
        int count = 0;
        public ctrUserLog()
        {
            InitializeComponent();

            progressPanel1.Visible = true;
            Client = ConnectDatabase.Instance.getClient();
            string placehoder = txtSearch.Properties.NullText;
            func.createPlaceHolderControl(txtSearch, placehoder);
            isWorking = true;
            Thread trd = new Thread(new ThreadStart(this.loadData));
            trd.IsBackground = true;
            trd.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count > 1)
            {
                progressPanel1.Visible = false;
                timer2.Enabled = false;
            }
        }
        #region //Setup GridView
        //Create Serial No For GridView
        private void gvEmployeeLog_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == NO)
            {
                if (e.RowHandle > -1)
                {
                    e.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        //Setup Text Align For Grid Column
        private void gvEmployeeLog_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.Name == "NO")
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            if (e.Column.Name == "EmployeeLogName")
            {
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            }

            //if (e.Column.Name == "Status")
            //{
            //    if (e.RowHandle >= 0)
            //    {
            //        if (dtContent.Rows[e.RowHandle]["TrangThai"].ToString() == "Đang Hoạt Động")
            //        {
            //            e.Appearance.BackColor = Color.FromArgb(122, 16, 16);
            //            e.Appearance.ForeColor = Color.FromArgb(255, 239, 239);
            //        }
            //    }
            //}
        }


        private void gvEmployeeLog_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            Rectangle emptyGridTextBounds;
            int offsetFromTop = 10;
            e.DefaultDraw();
            Size size = e.Appearance.CalcTextSize(e.Cache, emptyGridText, e.Bounds.Width).ToSize();
            int x = (e.Bounds.Width - size.Width) / 2;
            int y = e.Bounds.Y + offsetFromTop;
            emptyGridTextBounds = new Rectangle(new Point(x, y), size);
            e.Appearance.DrawString(e.Cache, emptyGridText, emptyGridTextBounds, Brushes.Gray);
        }
        #endregion

        #region //Read

        private void gcEmployeeLog_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            while (isWorking)
            {
                await Task.Delay(1000);
                var userLogs = await UserLogBUS.Instance.loadData();
                var user = await UserBUS.Instance.loadData();
                IEnumerable result = from ul in userLogs.AsEnumerable()
                                     join u in user.AsEnumerable() on ul.Field<string>("userId") equals u.Field<string>("id")
                                     select new
                                     {
                                         id = ul.Field<string>("id"),
                                         Ip = ul.Field<string>("Ip"),
                                         created = ul.Field<string>("created"),
                                         content = ul.Field<string>("content"),
                                         username = u.Field<string>("name"),
                                     };

                //gcEmployeeLog.DataSource = null;
                //gcEmployeeLog.DataSource = result;
                SetDataTb(result);
            }
        }

        #endregion

        #region //Search and Filter

        private void txtSearch_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != txtSearch.Properties.NullText)
            {
                if (txtSearch.Text == "")
                {
                    txtSearch.EditValue = "";
                }
                txtSearch.ForeColor = Color.FromArgb(0, 0, 20);
            }
            else
            {
                txtSearch.ForeColor = Color.FromArgb(144, 142, 144);
            }
            gvEmployeeLog.FindFilterText = string.Format("\"{0}\"", txtSearch.EditValue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtSearch.EditValue = "";
        }
        #endregion

        #region //Export
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            DateTime dtNow = DateTime.Now;
            saveDialog.FileName = "Danh_sach_logs_" + dtNow.Day.ToString() + "_" + dtNow.Month.ToString() + "_" + dtNow.Year.ToString()
                                                     + "_" + dtNow.Hour.ToString() + "_" + dtNow.Minute.ToString() + "_" + dtNow.Second.ToString();
            saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |Excel (1997-2003)(.xls)|*.xls|RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            {
                string exportFilePath = saveDialog.FileName;
                string fileExtenstion = new FileInfo(exportFilePath).Extension;

                switch (fileExtenstion)
                {
                    case ".xls":
                        gvEmployeeLog.OptionsPrint.PrintDetails = true;
                        XlsxExportOptionsEx opt = new XlsxExportOptionsEx();
                        opt.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        gvEmployeeLog.ExportToXlsx(exportFilePath, opt);
                        Process.Start(exportFilePath);
                        break;
                    case ".xlsx":
                        gvEmployeeLog.OptionsPrint.PrintDetails = true;
                        XlsxExportOptionsEx opt1 = new XlsxExportOptionsEx();
                        opt1.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                        gvEmployeeLog.ExportToXlsx(exportFilePath, opt1);
                        Process.Start(exportFilePath);
                        break;
                    case ".rtf":
                        gvEmployeeLog.ExportToRtf(exportFilePath);
                        break;
                    case ".pdf":
                        gvEmployeeLog.ExportToPdf(exportFilePath);
                        break;
                    case ".html":
                        gvEmployeeLog.ExportToHtml(exportFilePath);
                        break;
                    case ".mht":
                        gvEmployeeLog.ExportToMht(exportFilePath);
                        break;
                    default:
                        break;
                }

                if (File.Exists(exportFilePath))
                {
                    try
                    {
                        //Try to open the file and let windows decide how to open it.
                        System.Diagnostics.Process.Start(exportFilePath);
                    }
                    catch
                    {
                        String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                    MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        #endregion
        private void SetDataTb(IEnumerable dt)
        {
            if (gcEmployeeLog.InvokeRequired)
            {
                var dlg = new tbDelegate(SetDataTb);
                gcEmployeeLog.Invoke(dlg, new object[] { dt });
            }
            else
            {
                gcEmployeeLog.DataSource = null;
                gcEmployeeLog.DataSource = dt;
            }
        }
    }
}
