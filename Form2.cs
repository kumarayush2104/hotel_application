using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_8
{
    public partial class Form2 : Form
    {

        private bool isDrawing = false;
        private Point capturedPoint;
        private Bitmap signatureBitmap;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            int x = (this.Width - label1.Size.Width) / 2;
            label1.Height = 100;
            label1.Location = new Point(x, 50);
            button1.Location = new Point(50, this.Height - button1.Height - 50);
            button2.Location = new Point(this.Width - button2.Size.Width - 50, this.Height - button2.Height - 50);
            pictureBox1.Width = this.Width - 100;
            pictureBox1.Height = this.Height - 200 - button1.Height - label1.Height;
            pictureBox1.Location = new Point(50, 50 + label1.Height + 50);
            signatureBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            signatureBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            signatureBitmap.Save("D:/Sign.png", ImageFormat.Png);
            MessageBox.Show("Signature Saved Successfully");
            signatureBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_mouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            capturedPoint = e.Location;
        }

        private void pictureBox1_mouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void pictureBox1_mouseMove(object sender, MouseEventArgs e)
        {
            if(isDrawing)
            {
                using (Graphics g = Graphics.FromImage(signatureBitmap))
                {
                    Pen pen = new Pen(Color.White, 3);
                    g.DrawLine(pen, capturedPoint, e.Location);
                    capturedPoint = e.Location;
                }

                pictureBox1.Image = signatureBitmap;
            }
        }
    }
}
