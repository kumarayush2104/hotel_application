using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_8
{
    public partial class Form4 : Form
    {
        private NetworkStream networkStream;
        private TcpClient tcpClient;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            tcpClient.Connect("localhost", 1234);

            networkStream = tcpClient.GetStream();

            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                MessageBox.Show(data);
            }
        }

        private void renderData()
        {

        }

        public void closeConnection()
        {
            networkStream?.Close();
            tcpClient.Close();
        }
    }
}
