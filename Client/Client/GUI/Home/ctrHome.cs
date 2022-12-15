using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.DirectWrite;
using DevExpress.Office.Tsp;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Templates;
using Newtonsoft.Json;
using Client.BUS;
using Client.DAO;
using Client.DTO;
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

namespace Client.GUI.Home
{
    public partial class ctrHome : DevExpress.XtraEditors.XtraUserControl
    {
        public bool isRun = false;
        private delegate void CallDelegate(string text);
        IPEndPoint iep;
        Socket Client;
        Dictionary<int, Socket> ClientSocList = new Dictionary<int, Socket>(); // "id": Socket
        private byte[] data = new byte[1024];
        private int size = 1024;
        public ctrHome()
        {
            InitializeComponent();
        }
    }
}
