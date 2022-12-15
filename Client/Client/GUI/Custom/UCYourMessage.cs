using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GUI.Custom
{
    public partial class UCYourMessage : UserControl
    {
        public UCYourMessage()
        {
            InitializeComponent();
        }
        public Image ProfilePic
        {
            get { return pbAvatar.Image; }
            set { pbAvatar.Image = value; }
        }
        public string txtName
        {
            get { return labelName.Text; }
            set { labelName.Text = value; }
        }
        public string sendertxt
        {
            get { return txtSender.Text; }
            set { txtSender.Text = value; }
        }
    }
}
