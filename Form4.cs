using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Security;

namespace hotel_application
{
    public partial class Form4 : Form
    {
        private string userDetailsSaveLocation;
        private Bitmap? signatureBitmap = null;
        private bool isDrawing = false;
        private Point capturedPoint;
        private CustomerData? currentCustomerData = null;
        public DataTransferDelegate dataTransferDelegate;

        //
        // Form4: Customer Confirmation Window, this window is used by the customer to confirm their identity by providing a signature
        //        it also generates a receipt after the customer has confirmed their identity.
        //

        public Form4(string userDetailsSaveLocation, DataTransferDelegate dataTransferDelegate)
        {
            InitializeComponent();
            this.userDetailsSaveLocation = userDetailsSaveLocation;
            this.dataTransferDelegate = dataTransferDelegate;
            SwitchFields(false);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Main title at initial Screen
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
        }

        // PositionFields(): This function position the fields after setting their data
        private void PositionFields()
        {
            // Confirmation Screen Title
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, 20);

            // Name Field
            label3.Location = new Point(50, 70 + label2.Height);

            // Email Address Field
            label4.Location = new Point(50, 100 + label2.Height + label3.Height);

            // Contact Number Field
            label5.Location = new Point(50, 130 + label2.Height + label3.Height * 2);

            // Gender and Date of Birth Field
            label6.Location = new Point(50, 160 + label2.Height + label3.Height * 3);
            label7.Location = new Point(100 + label6.Width, 160 + label2.Height + label3.Height * 3);

            // Staying From and Staying Till Field
            label8.Location = new Point(50, 190 + label2.Height + label3.Height * 4);
            label9.Location = new Point(100 + label8.Width, 190 + label2.Height + label3.Height * 4);

            // Incorrect Info and Submit Button
            button1.Location = new Point(this.Width - button1.Width - 50, (label2.Height + label3.Height * 7) / 2);
            button2.Location = new Point(this.Width - button1.Width - 50, this.Height - button2.Height - 50);

            // Signature Box and clear signature button
            pictureBox1.Location = new Point(50, 240 + label2.Height + label3.Height * 5);
            button3.Location = new Point(50, 240 + label2.Height + label3.Height * 5 + pictureBox1.Height - button3.Height);
            button3.BringToFront();
        }

        // SwitchFields(bool key): used to switch between fields to render.
        private void SwitchFields(bool key)
        {
            // Initial Screen Title
            label1.Visible = !key;

            // Confirmation Screen Title
            label2.Visible = key;

            // Information Fields
            label3.Visible = key;
            label4.Visible = key;
            label5.Visible = key;
            label6.Visible = key;
            label7.Visible = key;
            label8.Visible = key;
            label9.Visible = key;

            // Signature Box
            pictureBox1.Visible = key;

            // Submission, Rejection, Clear Signature Button
            button1.Visible = key;
            button2.Visible = key;
            button3.Visible = key;
        }

        // SetCustomerData(CustomerData customerData): when data is recieved from customer information window it renders the data for user confirmation
        public void SetCustomerData(CustomerData customerData)
        {
            currentCustomerData = customerData;
            label3.Text = "Name:   " + customerData.name;
            label4.Text = "Email Address:   " + customerData.email;
            label5.Text = "Contact Number:   " + customerData.contact;
            label6.Text = "Gender:   " + customerData.gender;
            label7.Text = "Date of Birth:   " + customerData.dob;
            label8.Text = "Staying From:   " + customerData.stayFromDate;
            label9.Text = "Staying Till: " + customerData.stayTillDate;

            pictureBox1.Image = null;
            signatureBitmap = null;

            SwitchFields(true);
            PositionFields();
        }

        // below 3 methods are used to control the drawing events of signature.
        private void DrawingStarted(object sender, MouseEventArgs e)
        {
            if (signatureBitmap == null) signatureBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            isDrawing = true;
            capturedPoint = e.Location;
        }

        private void IsDrawing(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                using (Graphics graphic = Graphics.FromImage(signatureBitmap!))
                {
                    Pen pen = new Pen(Color.Black, 3);
                    graphic.DrawLine(pen, capturedPoint, e.Location);
                    capturedPoint = e.Location;
                }

                pictureBox1.Image = signatureBitmap;
            }
        }

        private void DrawingStopped(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        // ClearSignature(object sender, EventArgs e): clear the signature and resets the picturebox
        private void ClearSignature(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            signatureBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        // OnincorrectInfoClick(object sender, EventArgs e): Sends a message to the Customer Information Window when user denied their identity
        private void OnincorrectInfoClick(object sender, EventArgs e)
        {
            SwitchFields(false);
            Task.Run(() => dataTransferDelegate.UserMessage(false));
        }

        // OnSubmit(object sender, EventArgs e): Checks for the signature, generates a receipt and confirms the registration
        private void OnSubmit(object sender, EventArgs e)
        {

            if (signatureBitmap == null)
            {
                Task.Run(() => MessageBox.Show("Signature is missing\nPlease Provide your signature to continue!", "Missing Signature", MessageBoxButtons.OK, MessageBoxIcon.Error));
                return;
            }

            Task.Run(() =>
            {
                // Creating a Pdf document, its page, setting their properties and a pdfImage
                PdfBitmap pdfSignature = new PdfBitmap(signatureBitmap);
                PdfDocument document = new PdfDocument();
                PdfPage page = document.Pages.Add();
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                PdfGraphics graphics = page.Graphics;

                // Drawing Customer Data in the page
                graphics.DrawString("Name: " + currentCustomerData?.name, font, PdfBrushes.Black, new PointF(0, 0));
                graphics.DrawString("Date of Birth: " + currentCustomerData?.dob, font, PdfBrushes.Black, new PointF(0, 20));
                graphics.DrawString("Gender: " + currentCustomerData?.gender, font, PdfBrushes.Black, new PointF(0, 40));
                graphics.DrawString("Email Address: " + currentCustomerData?.email, font, PdfBrushes.Black, new PointF(0, 60));
                graphics.DrawString("Contact Number: " + currentCustomerData?.contact, font, PdfBrushes.Black, new PointF(0, 80));
                graphics.DrawString("Staying from: " + currentCustomerData?.stayFromDate, font, PdfBrushes.Black, new PointF(0, 100));
                graphics.DrawString("Staying till: " + currentCustomerData?.stayTillDate, font, PdfBrushes.Black, new PointF(0, 120));

                // Create a new digital signature
                PdfCertificate certificate = new PdfCertificate("D:/certificate.pfx", "utu@amtics");
                PdfSignature signature = new PdfSignature(document, page, certificate, currentCustomerData?.contact);
                signature.SignedName = currentCustomerData?.name;
                signature.ContactInfo = currentCustomerData?.email;
                signature.LocationInfo = "Gujarat, India";
                graphics.DrawImage(pdfSignature, 0, 160);

                // Saving the document
                string dateNow = DateTime.Now.ToString();
                dateNow = dateNow.Replace("/", "").Replace(":", "").Replace(" ", "_");

                document.Save(userDetailsSaveLocation + "\\" + currentCustomerData?.contact + "_" + dateNow + ".pdf");
            });

            SwitchFields(false);
            dataTransferDelegate.UserMessage(true);
            MessageBox.Show("Thank you for choosing our hotel !", "Booking Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormisClosing(object sender, EventArgs e)
        {
            dataTransferDelegate.onFormClose(this);
        }
    }
}
