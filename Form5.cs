using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Project_8
{
    public partial class Form5 : Form
    {
        private Form form1, form3, form4;
        private string folderPath;

        public Form5()
        {
            InitializeComponent();
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

            MessageBox.Show("You can use Screen number as 0 if you don't want to use that section");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0)
            {
                if (folderPath == null)
                {
                    MessageBox.Show("Advertisement Folder not selected");
                    return;
                }

                if (numericUpDown1.Value <= Screen.AllScreens.Length)
                {
                    numericUpDown1.Enabled = false;
                    var thread1 = new Thread(() =>
                    {
                        form1 = new Form1(folderPath);
                        form1.StartPosition = FormStartPosition.Manual;
                        form1.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown1.Value) - 1].Bounds.Location;
                        form1.ShowDialog();
                    });
                    thread1.SetApartmentState(ApartmentState.STA);
                    thread1.Start();
                }
                else
                {
                    MessageBox.Show("Screen " + numericUpDown1.Value + " is not available !");
                }
            }

            if (numericUpDown2.Value != 0)
            {
                numericUpDown2.Enabled = false;
                var thread2 = new Thread(() =>
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
                thread2.SetApartmentState(ApartmentState.STA);
                thread2.Start();
            }

            if (numericUpDown4.Value != 0)
            {
                if (numericUpDown4.Value <= Screen.AllScreens.Length)
                {
                    numericUpDown4.Value = (numericUpDown4.Value.Equals("")) ? 0 : numericUpDown4.Value;
                    numericUpDown4.Enabled = false;
                    var thread3 = new Thread(() =>
                    {
                        form4 = new Form4();
                        form4.StartPosition = FormStartPosition.Manual;
                        form4.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown4.Value) - 1].Bounds.Location;
                        form4.ShowDialog();
                    });
                    thread3.SetApartmentState(ApartmentState.STA);
                    thread3.Start();
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


        private void button2_Click(object sender, EventArgs e)
        {
            if (form1 != null && form1.InvokeRequired)
            {
                form1.Invoke(new MethodInvoker(delegate { form1.Close(); }));
            }

            if (form3 != null && form3.InvokeRequired)
            {
                form3.Invoke(new MethodInvoker(delegate { form3.Close(); }));
            }

            if (form4 != null && form4.InvokeRequired)
            {
                form4.Invoke(new MethodInvoker(delegate { form4.Close(); }));
            }

            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown4.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                folderPath = folderDialog.SelectedPath;
                string[] pathSplit = folderPath.Split("\\");
                button3.Text = pathSplit[pathSplit.Length - 1];
            }
        }
    }
}
