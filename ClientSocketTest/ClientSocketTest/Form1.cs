using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ClientSocketTest {
    public partial class Form1 : Form {

        string serverIP = "190.192.194.99";

        int port = 61000;

        public Form1() {
            InitializeComponent();          
        }

        private void Submit_Click(object sender, EventArgs e) {
            try {
                TcpClient client = new TcpClient(serverIP, port);

                int byteCount = Encoding.ASCII.GetByteCount(message.Text);

                byte[] sendData = new byte[byteCount];

                sendData = Encoding.ASCII.GetBytes(message.Text);

                NetworkStream stream = client.GetStream();

                stream.Write(sendData, 0, sendData.Length);

                stream.Close();

                client.Close();
            }
            catch (Exception ex) {
                Console.WriteLine("Failed to contact the server. Reason: " + ex.ToString());
            }
            


        }
    }
}
