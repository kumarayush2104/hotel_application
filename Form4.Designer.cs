namespace hotel_application
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(660, 522);
            label1.Name = "label1";
            label1.Size = new Size(494, 62);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Our Hotel";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(374, 21);
            label2.Name = "label2";
            label2.Size = new Size(393, 41);
            label2.TabIndex = 1;
            label2.Text = "Please Confirm your Identity";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(809, 532);
            label3.Name = "label3";
            label3.Size = new Size(97, 38);
            label3.TabIndex = 2;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(794, 532);
            label4.Name = "label4";
            label4.Size = new Size(196, 38);
            label4.TabIndex = 3;
            label4.Text = "Email Address:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(752, 542);
            label5.Name = "label5";
            label5.Size = new Size(227, 38);
            label5.TabIndex = 4;
            label5.Text = "Contact Number:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(792, 542);
            label6.Name = "label6";
            label6.Size = new Size(114, 38);
            label6.TabIndex = 5;
            label6.Text = "Gender:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(836, 542);
            label7.Name = "label7";
            label7.Size = new Size(180, 38);
            label7.TabIndex = 6;
            label7.Text = "Date of Birth:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(783, 542);
            label8.Name = "label8";
            label8.Size = new Size(185, 38);
            label8.TabIndex = 7;
            label8.Text = "Staying From:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(859, 542);
            label9.Name = "label9";
            label9.Size = new Size(157, 38);
            label9.TabIndex = 8;
            label9.Text = "Staying Till:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GradientActiveCaption;
            pictureBox1.Location = new Point(337, 368);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(850, 450);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += DrawingStarted;
            pictureBox1.MouseMove += IsDrawing;
            pictureBox1.MouseUp += DrawingStopped;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(664, 149);
            button1.Name = "button1";
            button1.Size = new Size(192, 48);
            button1.TabIndex = 10;
            button1.Text = "Incorrect Info";
            button1.UseVisualStyleBackColor = true;
            button1.Click += OnincorrectInfoClick;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(481, 288);
            button2.Name = "button2";
            button2.Size = new Size(192, 48);
            button2.TabIndex = 11;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += OnSubmit;
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(284, 168);
            button3.Name = "button3";
            button3.Size = new Size(137, 33);
            button3.TabIndex = 12;
            button3.Text = "Clear Signature";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ClearSignature;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1155, 625);
            ControlBox = false;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form4";
            StartPosition = FormStartPosition.Manual;
            Text = "Customer Confirmation Screen";
            WindowState = FormWindowState.Maximized;
            Load += Form4_Load;
            FormClosing += FormisClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}