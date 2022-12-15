using Client.DAO;
using Client.DTO;
using DevExpress.ClipboardSource.SpreadsheetML;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core
{
    class Global
    {
        public static bool isConnected = false;
        public static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static UserDTO gbUser = new UserDTO();
        private byte[] data = new byte[1024];
        public Global()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("192.168.43.94"), int.Parse("2008"));
            client.BeginConnect(iep, new AsyncCallback(ConnectCallback), null);
        }

        public void ConnectCallback(IAsyncResult iar)
        {
            try
            {
                client.EndConnect(iar);
                isConnected = true;
            }
            catch (SocketException)
            {
            }
        }
    }
}
