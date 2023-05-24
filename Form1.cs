using System.Windows.Forms;

namespace hotel_application
{
    public partial class Form1 : Form, DataTransferDelegate
    {
        string? advertisementFolderLocation;
        string? userDetailsSavingLocation;
        Form? advertisementWindow;
        Form3? customerInformationWindow;
        Form4? customerConfirmationWindow;

        //
        // Form1: Launcher screen, which controls the activity of the other windows and check their dependencies are satisfied or not.
        //
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Main Title
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 20);

            // Advertisement Screen label, its screen number and its stop button
            label2.Location = new Point(this.Width / 4 - label4.Width / 2, 50 + label1.Height);
            numericUpDown1.Location = new Point(this.Width / 4 + label4.Width / 2 + 150, 50 + label1.Height);
            button5.Location = new Point(this.Width / 4 + label4.Width + numericUpDown1.Width + 50, 50 + label1.Height);

            // Customer Information Screen label, its screen number and its stop button
            label3.Location = new Point(this.Width / 4 - label4.Width / 2, 70 + label1.Height * 2);
            numericUpDown2.Location = new Point(this.Width / 4 + label4.Width / 2 + 150, 70 + label1.Height * 2);
            button6.Location = new Point(this.Width / 4 + label4.Width + numericUpDown2.Width + 50, 70 + label1.Height * 2);

            // Customer Confirmation Screen label, its screen number and its stop button
            label4.Location = new Point(this.Width / 4 - label4.Width / 2, 90 + label1.Height * 3);
            numericUpDown3.Location = new Point(this.Width / 4 + label4.Width / 2 + 150, 90 + label1.Height * 3);
            button7.Location = new Point(this.Width / 4 + label4.Width + numericUpDown3.Width + 50, 90 + label1.Height * 3);

            // Advertisment Folder Location label and its picker
            label5.Location = new Point(this.Width / 4 - label4.Width / 2, 110 + label1.Height * 4);
            button1.Location = new Point(this.Width / 4 + label4.Width / 2 + 150, 110 + label1.Height * 4);

            // User Details Saving Location label and its picker
            label6.Location = new Point(this.Width / 4 - label4.Width / 2, 130 + label1.Height * 5);
            button2.Location = new Point(this.Width / 4 + label4.Width / 2 + 150, 130 + label1.Height * 5);

            // Start Application and Stop Application Button
            button3.Location = new Point(50, this.Height - button3.Height * 2 - 20);
            button4.Location = new Point(this.Width - button3.Width - 50, this.Height - button4.Height * 2 - 20);
        }

        // AdvertisementLocationPicker_Click(object sender, EventArgs e): Used to pick up advertisement folder location
        private void AdvertisementLocationPicker_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string? path = FolderPicker(button!);
                if (path != null) this.advertisementFolderLocation = path;
            }
        }

        // UserDetailsLocationPicker_Click(object sender, EventArgs e): Used to pick up user details saving location
        private void UserDetailsLocationPicker_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string? path = FolderPicker(button!);
                if (path != null) this.userDetailsSavingLocation = path;
            }
        }

        // FolderPicker(Button button): Folder picker helper
        private string? FolderPicker(Button button)
        {
            FolderBrowserDialog folderDialog = new();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
            {
                string folderPath = folderDialog.SelectedPath;
                string[] pathSplit = folderPath.Split("\\");
                string folderName = pathSplit[^1];
                button.Text = folderName;
                return folderPath;
            }

            return null;
        }

        // StartApplications(object sender, EventArgs e): Checks for individual window's screen numbers and their dependencies and start them

        private void StartApplications(object sender, EventArgs e)
        {
            // Checking for AdvertisementWindow ScreenNumber and starting it
            if (numericUpDown1.Value != 0)
            {
                if (numericUpDown1.Value > Screen.AllScreens.Length)
                {
                    Task.Run(() => MessageBox.Show("Screen Number " + numericUpDown1.Value + " is currently not available", "Screen Not Available For Advertisement Window", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
                else
                {
                    if (advertisementFolderLocation == null)
                    {
                        Task.Run(() => MessageBox.Show("Advertisement Folder Path has not been selected\nPlease select it and try again!", "Advertisement Folder is unset", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    }
                    else
                    {
                        if (!IsFormAlreadyOpen<Form2>())
                        {
                            advertisementWindow = new Form2(this.advertisementFolderLocation!, this);
                            numericUpDown1.Enabled = false;
                            button5.Visible = true;
                            button1.Enabled = false;
                            advertisementWindow.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown1.Value) - 1].Bounds.Location;
                            Task.Run(advertisementWindow.ShowDialog);
                        }
                    }
                }
            }

            // Checking for customerInformationWindow ScreenNumber and starting it
            if (numericUpDown2.Value != 0)
            {
                if (numericUpDown2.Value > Screen.AllScreens.Length)
                {
                    Task.Run(() => MessageBox.Show("Screen Number " + numericUpDown2.Value + " is currently not available", "Screen Not Available for Customer Information Window", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
                else
                {
                    if (!IsFormAlreadyOpen<Form3>())
                    {
                        customerInformationWindow = new Form3(this);
                        numericUpDown2.Enabled = false;
                        button6.Visible = true;
                        customerInformationWindow.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown2.Value) - 1].Bounds.Location;
                        Task.Run(customerInformationWindow.ShowDialog);
                    }
                }
            }

            // Checking for customerConfirmationWindow ScreenNumber and starting it
            if (numericUpDown3.Value != 0)
            {
                if (numericUpDown3.Value > Screen.AllScreens.Length)
                {
                    Task.Run(() => MessageBox.Show("Screen Number " + numericUpDown3.Value + " is currently not available", "Screen Not Available for Customer Confirmation Window", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
                else
                {
                    if (userDetailsSavingLocation == null)
                    {
                        Task.Run(() => MessageBox.Show("User details folder path has not been selected.\nPlease select it and try again!", "User Details Folder Location is unset", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    }
                    else
                    {
                        if (!IsFormAlreadyOpen<Form4>())
                        {
                            customerConfirmationWindow = new Form4(userDetailsSavingLocation, this);
                            numericUpDown3.Enabled = false;
                            button2.Enabled = false;
                            button7.Visible = true;
                            customerConfirmationWindow.Location = Screen.AllScreens[Convert.ToInt32(numericUpDown3.Value) - 1].Bounds.Location;
                            Task.Run(customerConfirmationWindow.ShowDialog);
                        }
                    }
                }
            }
        }

        // IsFormAlreadyOpen<T>() where T : Form: Helper method to check if a form of the specified type is already open
        private bool IsFormAlreadyOpen<T>() where T : Form
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is T) return true;
            }

            return false;
        }

        // StopApplications(object sender, EventArgs e): Stops all the window on button click
        private void StopApplications(object sender, EventArgs e)
        {
            if (advertisementWindow != null && advertisementWindow!.IsHandleCreated)
            {
                advertisementWindow!.Invoke(new Action(() =>
                {
                    advertisementWindow.Close();
                    advertisementWindow = null;
                }));

                numericUpDown1.Enabled = true;
                button1.Enabled = true;
                button5.Visible = false;
            }

            if (customerInformationWindow != null && customerInformationWindow!.IsHandleCreated)
            {
                customerInformationWindow?.Invoke(new Action(() =>
                {
                    customerInformationWindow.Close();
                    customerInformationWindow = null;
                }));

                numericUpDown2.Enabled = true;
                if (button6.Visible) button6.Visible = false;
            }

            if (customerConfirmationWindow != null && customerConfirmationWindow!.IsHandleCreated)
            {
                customerConfirmationWindow?.Invoke(new Action(() =>
                {
                    customerConfirmationWindow.Close();
                    customerInformationWindow = null;
                }));

                numericUpDown3.Enabled = true;
                button2.Enabled = true;
                if (button7.Visible) button7.Visible = false;
            }

            Close();
        }

        // Window Individual closing buttons
        private void AdvertisementWindowClose(object sender, EventArgs e)
        {
            if (advertisementWindow != null && advertisementWindow!.IsHandleCreated)
            {
                advertisementWindow!.Invoke(new Action(() =>
                {
                    advertisementWindow.Close();
                    advertisementWindow = null;
                }));
            }

            numericUpDown1.Enabled = true;
            button1.Enabled = true;
            if (button5.Visible) button5.Visible = false;
        }

        private void CustomerInformationWindowClose(object sender, EventArgs e)
        {
            if (customerInformationWindow != null && customerInformationWindow!.IsHandleCreated)
            {
                customerInformationWindow?.Invoke(new Action(() =>
                {
                    customerInformationWindow.Close();
                    customerInformationWindow = null;
                }));
            }

            numericUpDown2.Enabled = true;
            if (button6.Visible) button6.Visible = false;
        }

        private void CustomerConfirmationWindowClose(object sender, EventArgs e)
        {
            if (customerConfirmationWindow != null && customerConfirmationWindow!.IsHandleCreated)
            {
                customerConfirmationWindow?.Invoke(new Action(() =>
                {
                    customerConfirmationWindow.Close();
                    customerInformationWindow = null;
                }));
            }

            numericUpDown3.Enabled = true;
            button2.Enabled = true;
            if (button7.Visible) button7.Visible = false;
        }

        // Implementations of DataTransferDelegate interface: They are used to create commnuication between forms using callbacks
        public void onCustomerDataAcquire(CustomerData customerData)
        {
            if (customerConfirmationWindow != null && customerConfirmationWindow!.IsHandleCreated)
                customerConfirmationWindow.Invoke(new Action(() => customerConfirmationWindow.SetCustomerData(customerData)));
            else
                MessageBox.Show("Customer Confirmation Window is not running !", "Customer Confirmation Window", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public void UserMessage(bool agree)
        {
            Task.Run(() =>
            {
                if (customerInformationWindow != null && customerInformationWindow.IsHandleCreated)
                {
                    if (agree)
                        customerInformationWindow.Invoke(new Action(customerInformationWindow.UserAgreedWithIdentity));
                    else
                        customerInformationWindow.Invoke(new Action(customerInformationWindow.UserDeniedTheIdentity));
                }
                else
                {
                    MessageBox.Show("Customer Information Window is not running!", "Customer Information Window", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            });
        }

        public void onFormClose(Form form)
        {
            if (form == advertisementWindow && !advertisementWindow.IsDisposed)
            {
                BeginInvoke(new Action(() =>
                {
                    numericUpDown1.Enabled = true;
                    button1.Enabled = true;
                    if (button5.Visible) button5.Visible = false;
                }));
            }
            else if (form == customerInformationWindow && !customerInformationWindow.IsDisposed)
            {
                BeginInvoke(new Action(() =>
                {
                    numericUpDown2.Enabled = true;
                    if (button6.Visible) button6.Visible = false;
                }));
            }
            else if (form == customerConfirmationWindow && !customerConfirmationWindow.IsDisposed)
            {
                BeginInvoke(new Action(() =>
                {
                    numericUpDown3.Enabled = true;
                    button2.Enabled = true;
                    if (button7.Visible) button7.Visible = false;
                }));
            }
        }
    }
}