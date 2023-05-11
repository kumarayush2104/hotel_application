using System.Net.Sockets;

namespace Project_8
{
    public partial class Form5 : Form
    {
        private Form1? form1;
        private Form3? form3;
        private Form4? form4;
        private string? folderPath;
        private TcpListener tcpListener;
        private List<TcpClient> clients;
        private NetworkStream? networkStream;

        //
        // Form5: Launcher Screen of the application, it allows the user to set screen number for individual modules and
        //        it also allows the user to set advertisement folder path for advertisement screen.
        //

        public Form5()
        {
            InitializeComponent();
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 1234);
            tcpListener.Start();
            clients = new List<TcpClient>();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label5.Location = new Point(this.Width / 2 - label5.Width / 2, 20);
            numericUpDown1.Minimum = numericUpDown2.Minimum = numericUpDown4.Minimum = 0;
            numericUpDown1.Maximum = numericUpDown2.Maximum = numericUpDown4.Maximum = 6;

            label1.Location = new Point(this.Width / 4 - label1.Width / 2, 50 + label5.Height);
            numericUpDown1.Location = new Point(this.Width / 4 + label3.Width / 2 + 150, 50 + label5.Height);

            label2.Location = new Point(this.Width / 4 - label1.Width / 2, 80 + label5.Height + label1.Height);
            numericUpDown2.Location = new Point(this.Width / 4 + label3.Width / 2 + 150, 80 + label5.Height + label1.Height);

            label3.Location = new Point(this.Width / 4 - label1.Width / 2, 110 + label5.Height + label1.Height + label2.Height);
            numericUpDown4.Location = new Point(this.Width / 4 + label3.Width / 2 + 150, 110 + label5.Height + label1.Height + label2.Height);

            label4.Location = new Point(this.Width / 4 - label1.Width / 2, 140 + label5.Height + label1.Height + label2.Height + label3.Height);
            button3.Location = new Point(this.Width / 4 + label3.Width / 2 + 150, 140 + label5.Height + label1.Height + label2.Height + label3.Height);

            button1.Location = new Point(100, this.Height - button1.Height - 100);
            button2.Location = new Point(this.Width - button2.Width - 100, this.Height - button1.Height - 100);
            AcceptClients();
        }

        //
        // async AcceptClients(): Starts accepting tcpclients
        //

        private async void AcceptClients()
        {
            while (true)
            {
                try
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    clients.Add(client);
                    await Task.Run(() =>
                    {
                        networkStream = client.GetStream();
                        FetchData();
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        //
        // async FetchData(): Starts a Service which recieves data from clients
        //

        private async void FetchData()
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (clients.Count() > 0 && networkStream != null)
                {
                    int bytesRead = await networkStream!.ReadAsync(buffer, 0, buffer.Length);
                    if(bytesRead > 0) passMessage(buffer, bytesRead);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while receiving data: " + ex.Message);
            }
        }

        //
        // async passMessage(byte[] buffer, int bufferSize): Pass all the recieved message to all the clients,
        //                                                   letting client handle which data they need or which they don't need
        //

        private async void passMessage(byte[] buffer, int bufferSize)
        {
            foreach (TcpClient client in clients)
            {
                await client.GetStream().WriteAsync(buffer, 0, bufferSize);
            }
        }

        //
        // button1_Click(object sender, EventArgs e): Checks for Screen values and advertisement path
        //

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                if (folderPath == null)
                {
                    MessageBox.Show("Advertisement Folder not selected !");
                    return;
                }

                if (numericUpDown1.Value <= Screen.AllScreens.Length)
                {
                    numericUpDown1.Enabled = false;
                    CreateThread(() =>
                    {
                        form1 = new Form1(folderPath);
                        form1.StartPosition = FormStartPosition.Manual;
                        form1.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown1.Value) - 1].Bounds.Location;
                        form1.ShowDialog();
                    });
                }
                else
                {
                    MessageBox.Show("Screen " + numericUpDown1.Value + " is not available !");
                }
            }

            if (numericUpDown2.Value != 0)
            {
                numericUpDown2.Enabled = false;
                CreateThread(() =>
                {
                    if (numericUpDown2.Value <= Screen.AllScreens.Length)
                    {
                        form3 = new Form3();
                        form3.StartPosition = FormStartPosition.Manual;
                        form3.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown2.Value) - 1].Bounds.Location;
                        form3.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Screen " + numericUpDown2.Value + " is not available !");
                    }
                });
            }

            if (numericUpDown4.Value != 0)
            {
                if (numericUpDown4.Value <= Screen.AllScreens.Length)
                {
                    numericUpDown4.Value = (numericUpDown4.Value.Equals("")) ? 0 : numericUpDown4.Value;
                    numericUpDown4.Enabled = false;
                    CreateThread(() =>
                    {
                        form4 = new Form4();
                        form4.StartPosition = FormStartPosition.Manual;
                        form4.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown4.Value) - 1].Bounds.Location;
                        form4.ShowDialog();
                    });
                }
                else
                {
                    MessageBox.Show("Screen " + numericUpDown4.Value + " is not available !");
                }
            }

            button1.Enabled = false;
            button3.Enabled = false;

            this.WindowState = FormWindowState.Minimized;
        }

        //
        // CreateThread(ThreadStart threadStart): Method to start the thread
        //

        private void CreateThread(ThreadStart threadStart)
        {
            var thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //
        // button3_Click(object sender, EventArgs e): Opens folderDialog and sets the advertisement folder's path
        //

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                folderPath = folderDialog.SelectedPath;
                string[] pathSplit = folderPath.Split("\\");
                string folderName = pathSplit[pathSplit.Length - 1];
                button3.Text = folderName;
            }
        }

        //
        // button2_Click(object sender, EventArgs e): closes all the form, clears all TcpClients and resets every numericUpDown
        //

        private void button2_Click(object sender, EventArgs e)
        {
            CloseFormIfNotNull(form1!);
            CloseFormNetwork(form3!);
            CloseFormIfNotNull(form3!);
            CloseFormNetwork(form4!);
            CloseFormIfNotNull(form4!);

            clients.Clear();

            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown4.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
        }

        //
        // CloseFormIfNotNull(Form form): Check if form is not null and closes it
        //

        private void CloseFormIfNotNull(Form form)
        {
            if (form != null && form.InvokeRequired)
            {
                form.Invoke(new MethodInvoker(delegate { form.Close(); }));
            }
            else if (form != null)
            {
                form.Close();
            }
        }

        //
        // CloseFormNetwork(Form3, Form4) *Overloading Method: closes connections throughout the forms
        //

        private void CloseFormNetwork(Form3 form)
        {
            if (form != null && form.InvokeRequired)
            {
                form.closeNetwork();
            }
        }

        private void CloseFormNetwork(Form4 form)
        {
            if (form != null && form.InvokeRequired)
            {
                form.closeNetwork();
            }
        }
    }
}
