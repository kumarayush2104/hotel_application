namespace hotel_application
{
    public partial class Form2 : Form
    {
        private readonly string advertisementFolderLocation;
        public DataTransferDelegate dataTransferDelegate;

        //
        // Form2: Advertisement Screen, which shows infinite slideshow of pictures inside the provided path
        //

        public Form2(string advertisementFolderLocation, DataTransferDelegate dataTransferDelegate)
        {
            InitializeComponent();
            this.advertisementFolderLocation = advertisementFolderLocation;
            this.dataTransferDelegate = dataTransferDelegate;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ShowPictures(this.advertisementFolderLocation);
        }

        // showPictures(string path): Fetchs all the files from the provided path and shows the picture in the PictureBox

        private async void ShowPictures(string path)
        {
            while (true)
            {
                string[] files = Directory.GetFiles(path);
                await Task.Delay(2000);
                foreach (string file in files)
                {
                    if (IsImageFile(file))
                    {
                        try
                        {
                            using FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                            pictureBox1.Image = await Task.Run(() => Image.FromStream(stream));
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

        // IsImageFile(string file): Verifies the provided file if it is a picture or not

        private static bool IsImageFile(string file)
        {
            return file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".png");
        }

        // Implementing interface callbacks and their actions

        private void FormisClosing(object sender, EventArgs e)
        {
            dataTransferDelegate.onFormClose(this);
        }
    }
}
