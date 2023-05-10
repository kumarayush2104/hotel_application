namespace Project_8
{
    public partial class Form1 : Form
    {
        string adPath;
        public Form1(string adPath)
        {
            this.adPath = adPath;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            showPictures(adPath);
        }

        private async void showPictures(string path)
        {
            while(true)
            {
                string[] files = Directory.GetFiles(path);

                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].EndsWith(".jpg") || files[i].EndsWith(".jpeg") || files[i].EndsWith(".png"))
                    {
                        try
                        {
                            using (FileStream stream = new FileStream(files[i], FileMode.Open, FileAccess.Read))
                            {
                                pictureBox1.Image = await Task.Run(() => Image.FromStream(stream));
                            }
                        } catch
                        {
                            Console.WriteLine("There was a problem loading this picture");
                        }
                        
                        await Task.Delay(5000);
                        pictureBox1.Image.Dispose();
                    }
                }
            }
        }

    }
}