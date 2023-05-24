using System.Text.RegularExpressions;

namespace hotel_application
{
    public partial class Form3 : Form
    {
        public DataTransferDelegate dataTransferDelegate;

        //
        // Form3: Customer Information Window, its takes information of customers and pass on to Customer confirmation window for confirmation
        //

        public Form3(DataTransferDelegate customerDataTransferDelegate)
        {
            InitializeComponent();
            dataTransferDelegate = customerDataTransferDelegate;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Configuring Date Pickers
            dateTimePicker1.MinDate = DateTime.Now.AddYears(-60);
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);

            dateTimePicker2.MinDate = DateTime.Now.Date;
            dateTimePicker2.MaxDate = DateTime.Now.AddYears(1);

            dateTimePicker3.MinDate = dateTimePicker2.Value.Date.AddDays(1);
            dateTimePicker3.MaxDate = dateTimePicker2.MaxDate.Date.AddMonths(1);

            // Main Title
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, 50);

            // Name Label and its Input field, Date of Birth label and its datepicker
            label2.Location = new Point(50, 150 + label1.Height);
            textBox1.Location = new Point(label4.Width + 70, 150 + label1.Height);
            label3.Location = new Point(label4.Width + textBox1.Width + 100, 150 + label1.Height);
            dateTimePicker1.Location = new Point(label4.Width + textBox1.Width + label3.Width + 120, 150 + label1.Height);

            // Staying from and Staying till label and their datepicker
            label4.Location = new Point(50, label1.Height + label2.Height + 200);
            dateTimePicker2.Location = new Point(label4.Width + 70, label1.Height + label2.Height + 200);
            label5.Location = new Point(label4.Width + textBox1.Width + 100, label1.Height + label2.Height + 200);
            dateTimePicker3.Location = new Point(label4.Width + textBox1.Width + label3.Width + 120, label1.Height + label2.Height + 200);

            // Gender label and its selectors
            label6.Location = new Point(50, label1.Height + label2.Height * 2 + 250);
            radioButton1.Location = new Point(label4.Width + 70, label1.Height + label2.Height * 2 + 250);
            radioButton2.Location = new Point(label4.Width + radioButton1.Width + 100, label1.Height + label2.Height * 2 + 250);
            radioButton3.Location = new Point(label4.Width + radioButton1.Width + radioButton2.Width + 130, label1.Height + label2.Height * 2 + 250);

            // Contact number and email address label and their textfields
            label7.Location = new Point(50, label1.Height + label2.Height * 3 + 300);
            textBox2.Location = new Point(label7.Width + 70, label1.Height + label2.Height * 3 + 300);
            label8.Location = new Point(label7.Width + textBox2.Width + 100, label1.Height + label2.Height * 3 + 300);
            textBox3.Location = new Point(label7.Width + textBox2.Width + label8.Width + 130, label1.Height + label2.Height * 3 + 300);

            // Submit button
            button1.Location = new Point(this.Width / 2 - button1.Width / 2, this.Height - button1.Height - 50);
        }

        // ValidateTextfields(): Validates the textfields
        private bool ValidateTextfields()
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[A-Za-z\s]+$")) return false;
            else if (!Regex.IsMatch(textBox2.Text, @"^[6789](\d){9}")) return false;
            else if (!Regex.IsMatch(textBox3.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")) return false;
            return true;
        }

        // GenderBoxResult(): Checks and returns the selected gender
        private string GenderBoxResult()
        {
            if (radioButton1.Checked) return radioButton1.Text;
            else if (radioButton2.Checked) return radioButton2.Text;
            else return radioButton3.Text;
        }

        // onSubmitButton(object sender, EventArgs e): sends data for the customer's confirmation through callbacks
        private void onSubmitButton(object sender, EventArgs e)
        {
            if (ValidateTextfields())
            {
                // Get values entered by user
                string name = textBox1.Text;
                string contact = textBox2.Text;
                string email = textBox3.Text;
                string gender = GenderBoxResult().ToString();
                string dob = dateTimePicker1.Value.ToShortDateString();
                string stayFromDate = dateTimePicker2.Value.ToShortDateString();
                string stayTillDate = dateTimePicker3.Value.ToShortDateString();

                CustomerData customer = new(name, contact, email, gender, dob, stayFromDate, stayTillDate);
                dataTransferDelegate.onCustomerDataAcquire(customer);
            }
            else
            {
                Task.Run(() => MessageBox.Show("There is some problem with the Form data\nPlease correct it and resubmit !", "Invalid Form Data", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        // Implementing interface callbacks and their actions
        public void UserAgreedWithIdentity()
        {
            MessageBox.Show(this, "User has submitted their data !", "User data submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void UserDeniedTheIdentity()
        {
            MessageBox.Show(this, "User's Data is incorrect\nPlease correct it and resubmit !", "Incorrent UserData", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormisClosing(object sender, EventArgs e)
        {
            dataTransferDelegate.onFormClose(this);
        }
    }
}
