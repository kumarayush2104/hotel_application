using Newtonsoft.Json;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace Project_8
{
    public partial class Form3 : Form
    {
        TcpListener tcpListener;
        TcpClient tcpClient;
        NetworkStream networkStream;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 1234);
            tcpListener.Start();
            tcpClient = tcpListener.AcceptTcpClient();
            networkStream = tcpClient.GetStream();


            FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            dateTimePicker1.MinDate = DateTime.Now.AddYears(-60);
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);

            dateTimePicker2.MinDate = DateTime.Now.Date;
            dateTimePicker2.MaxDate = DateTime.Now.AddYears(1);

            dateTimePicker3.MinDate = dateTimePicker2.Value.Date.AddDays(1);
            dateTimePicker3.MaxDate = dateTimePicker2.MaxDate.Date.AddMonths(1);

            label7.Location = new Point(this.Width / 2 - label7.Width / 2, 50);

            label1.Location = new Point(50, 150 + label7.Height);
            textBox1.Location = new Point(label2.Width + 70, 150 + label7.Height);
            label5.Location = new Point(label2.Width + textBox1.Width + 100, 150 + label7.Height);
            dateTimePicker1.Location = new Point(label2.Width + textBox1.Width + label5.Width + 120, 150 + label7.Height);

            label2.Location = new Point(50, label1.Height + label7.Height + 200);
            dateTimePicker2.Location = new Point(label2.Width + 70, label1.Height + label7.Height + 200);
            label3.Location = new Point(label2.Width + dateTimePicker2.Width + 100, label1.Height + label7.Height + 200);
            dateTimePicker3.Location = new Point(label2.Width + dateTimePicker2.Width + 150 + label3.Width, label1.Height + label7.Height + 200);

            label4.Location = new Point(50, label1.Height + label7.Height + 250 + label2.Height);
            radioButton1.Location = new Point(label2.Width + 70, (label4.Height - radioButton2.Height) + label1.Height + label7.Height + 250 + label2.Height);
            radioButton2.Location = new Point(label2.Width + 100 + radioButton1.Width, (label4.Height - radioButton2.Height) + label1.Height + label7.Height + 250 + label2.Height);
            radioButton3.Location = new Point(label2.Width + +130 + radioButton1.Width + radioButton2.Width, (label4.Height - radioButton2.Height) + label1.Height + label7.Height + 250 + label2.Height);

            label6.Location = new Point(50, label1.Height + label7.Height + 300 + label4.Height + label2.Height);
            textBox3.Location = new Point(label6.Width + 70, label1.Height + label7.Height + 300 + label4.Height + label2.Height);
            label8.Location = new Point(label6.Width + textBox3.Width + 100, label1.Height + label7.Height + 300 + label4.Height + label2.Height);
            textBox4.Location = new Point(label6.Width + textBox3.Width + label8.Width + 120, label1.Height + label7.Height + 300 + label4.Height + label2.Height);

            button1.Location = new Point(this.Width / 2 - button1.Width / 2, this.Height - button1.Height - 50);
        }

        private bool validation()
        {
            if (!Regex.IsMatch(textBox1.Text, @"(\w){2,}")) return false;
            else if (!Regex.IsMatch(textBox3.Text, @"^[6789](\d){9}")) return false;
            else if (!Regex.IsMatch(textBox4.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) return false;
            return true;
        }

        public string genderBox()
        {
            if (radioButton1.Checked) return radioButton1.Text;
            else if(radioButton2.Checked) return radioButton2.Text;
            else return radioButton3.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!validation())
            {
                MessageBox.Show("Invalid Data !!");
            } else
            {
                CustomerData customerData = new CustomerData { name = textBox1.Text, contact = textBox3.Text, gender = genderBox(), email = textBox4.Text, fromDate = dateTimePicker2.Value.ToShortDateString(), dob = dateTimePicker1.Value.ToShortDateString(), toDate = dateTimePicker3.Value.ToShortDateString()};
                string jsonData = JsonConvert.SerializeObject(customerData);
                byte[] buffer = Encoding.ASCII.GetBytes(jsonData);
                networkStream.Write(buffer);
            }
        }

        public void closeNetwork()
        {
            networkStream.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
