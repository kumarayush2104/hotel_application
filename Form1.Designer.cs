namespace hotel_application
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(244, 25);
            label1.Name = "label1";
            label1.Size = new Size(340, 38);
            label1.TabIndex = 0;
            label1.Text = "Hotel Booking Application";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(57, 84);
            label2.Name = "label2";
            label2.Size = new Size(202, 28);
            label2.TabIndex = 1;
            label2.Text = "Advertisement Screen";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(57, 140);
            label3.Name = "label3";
            label3.Size = new Size(267, 28);
            label3.TabIndex = 2;
            label3.Text = "Customer Information Screen";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(45, 201);
            label4.Name = "label4";
            label4.Size = new Size(279, 28);
            label4.TabIndex = 3;
            label4.Text = "Customer Confirmation Screen";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(57, 247);
            label5.Name = "label5";
            label5.Size = new Size(280, 28);
            label5.TabIndex = 4;
            label5.Text = "Advertisement Folder Location";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(57, 328);
            label6.Name = "label6";
            label6.Size = new Size(259, 28);
            label6.TabIndex = 5;
            label6.Text = "User Details Saving Location";
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(472, 266);
            button1.Name = "button1";
            button1.Size = new Size(94, 30);
            button1.TabIndex = 4;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AdvertisementLocationPicker_Click;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(472, 331);
            button2.Name = "button2";
            button2.Size = new Size(94, 30);
            button2.TabIndex = 5;
            button2.Text = "Browse";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UserDetailsLocationPicker_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(44, 388);
            button3.Name = "button3";
            button3.Size = new Size(210, 50);
            button3.TabIndex = 6;
            button3.Text = "Start Application";
            button3.UseVisualStyleBackColor = true;
            button3.Click += StartApplications;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(536, 388);
            button4.Name = "button4";
            button4.Size = new Size(210, 50);
            button4.TabIndex = 7;
            button4.Text = "Stop Application";
            button4.UseVisualStyleBackColor = true;
            button4.Click += StopApplications;
            // 
            // numericUpDown1
            // 
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Location = new Point(457, 78);
            numericUpDown1.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(150, 27);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown2.Location = new Point(457, 127);
            numericUpDown2.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(150, 27);
            numericUpDown2.TabIndex = 2;
            numericUpDown2.TextAlign = HorizontalAlignment.Right;
            // 
            // numericUpDown3
            // 
            numericUpDown3.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown3.Location = new Point(457, 188);
            numericUpDown3.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(150, 27);
            numericUpDown3.TabIndex = 3;
            numericUpDown3.TextAlign = HorizontalAlignment.Right;
            // 
            // button5
            // 
            button5.Location = new Point(652, 76);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 8;
            button5.Text = "Stop";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += AdvertisementWindowClose;
            // 
            // button6
            // 
            button6.Location = new Point(652, 125);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 9;
            button6.Text = "Stop";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += CustomerInformationWindowClose;
            // 
            // button7
            // 
            button7.Location = new Point(652, 186);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 10;
            button7.Text = "Stop";
            button7.UseVisualStyleBackColor = true;
            button7.Visible = false;
            button7.Click += CustomerConfirmationWindowClose;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Hotel Application";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
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
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}