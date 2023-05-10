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
            WindowState = FormWindowState.Maximized;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            showPictures(adPath);
        }

        //
        // showPictures(string path): Fetchs all the files from the provided path and shows the picture in the PictureBox
        //

        private async void showPictures(string path)
        {
            while (true)
            {
                string[] files = Directory.GetFiles(path);

                foreach (string file in files)
                {
                    if (IsImageFile(file))
                    {
                        try
                        {
                            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                            {
                                pictureBox1.Image = await Task.Run(() => Image.FromStream(stream));
                            }
                        }
                        catch
                        {
                            Console.WriteLine("There was a problem loading this picture");
                        }

                        await Task.Delay(5000);
                        pictureBox1.Image.Dispose();
                    }
                }
            }
        }

        //
        // IsImageFile(string file): Verifies the provided file if it is a picture or not
        //

        private bool IsImageFile(string file)
        {
            return file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png");
        }
    }
}
