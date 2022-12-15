using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Client.GUI.Custom
{
    public partial class UCConservation : UserControl
    {
        public UCConservation()
        {
            InitializeComponent();
            pnGrid.BackColor = Color.FromArgb(0, 0, 0, 0);
        }
        public Image ProfilePic
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public string txtName
        {
            get { return lbContent.Text; }
            set { lbContent.Text = value; }
        }
        public string txtStatus
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }       
        public string txtTimer
        {
            get { return lbTime.Text; }
            set { lbTime.Text = value; }
        }

        public int conserId { get; set; } = 0;
        public int groupId { get; set; } = 0;

        private void btnChat_Click(object sender, EventArgs e)
        {

        }
    }
}
