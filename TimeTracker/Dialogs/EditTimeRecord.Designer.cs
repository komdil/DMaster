namespace TimeTracker.Dialogs
{
    partial class EditTimeRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTimeRecord));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWorkId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxWorkStartDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxWorkEndTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPMONumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTimeAccrued = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFriendlyTime = new System.Windows.Forms.TextBox();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(358, 254);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(277, 254);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Work Id";
            // 
            // textBoxWorkId
            // 
            this.textBoxWorkId.Enabled = false;
            this.textBoxWorkId.Location = new System.Drawing.Point(130, 23);
            this.textBoxWorkId.Name = "textBoxWorkId";
            this.textBoxWorkId.Size = new System.Drawing.Size(135, 20);
            this.textBoxWorkId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(130, 49);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(135, 20);
            this.textBoxDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Work Start Time";
            // 
            // textBoxWorkStartDate
            // 
            this.textBoxWorkStartDate.Location = new System.Drawing.Point(128, 135);
            this.textBoxWorkStartDate.Name = "textBoxWorkStartDate";
            this.textBoxWorkStartDate.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkStartDate.TabIndex = 7;
            this.textBoxWorkStartDate.TextChanged += new System.EventHandler(this.textBoxWorkStartDate_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Work End Time";
            // 
            // textBoxWorkEndTime
            // 
            this.textBoxWorkEndTime.Location = new System.Drawing.Point(128, 161);
            this.textBoxWorkEndTime.Name = "textBoxWorkEndTime";
            this.textBoxWorkEndTime.Size = new System.Drawing.Size(137, 20);
            this.textBoxWorkEndTime.TabIndex = 9;
            this.textBoxWorkEndTime.TextChanged += new System.EventHandler(this.textBoxWorkEndTime_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "PMO Number";
            // 
            // textBoxPMONumber
            // 
            this.textBoxPMONumber.Enabled = false;
            this.textBoxPMONumber.Location = new System.Drawing.Point(346, 78);
            this.textBoxPMONumber.Name = "textBoxPMONumber";
            this.textBoxPMONumber.Size = new System.Drawing.Size(79, 20);
            this.textBoxPMONumber.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Location = new System.Drawing.Point(38, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Time Accrued";
            // 
            // textBoxTimeAccrued
            // 
            this.textBoxTimeAccrued.Enabled = false;
            this.textBoxTimeAccrued.Location = new System.Drawing.Point(128, 189);
            this.textBoxTimeAccrued.Name = "textBoxTimeAccrued";
            this.textBoxTimeAccrued.Size = new System.Drawing.Size(137, 20);
            this.textBoxTimeAccrued.TabIndex = 15;
            this.textBoxTimeAccrued.TextChanged += new System.EventHandler(this.textBoxTimeAccrued_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Location = new System.Drawing.Point(271, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Friendly Time";
            // 
            // textBoxFriendlyTime
            // 
            this.textBoxFriendlyTime.Location = new System.Drawing.Point(346, 188);
            this.textBoxFriendlyTime.Name = "textBoxFriendlyTime";
            this.textBoxFriendlyTime.Size = new System.Drawing.Size(79, 20);
            this.textBoxFriendlyTime.TabIndex = 21;
            this.textBoxFriendlyTime.TextChanged += new System.EventHandler(this.textBoxFriendlyTime_TextChanged);
            // 
            // comboBoxDescription
            // 
            this.comboBoxDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(129, 77);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(136, 21);
            this.comboBoxDescription.TabIndex = 22;
            this.comboBoxDescription.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescription_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "PMO Description";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelError);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.comboBoxDescription);
            this.panel1.Controls.Add(this.textBoxFriendlyTime);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxTimeAccrued);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxPMONumber);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBoxWorkEndTime);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxWorkStartDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxWorkId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 293);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TimeTracker.Properties.Resources.settings;
            this.pictureBox2.Location = new System.Drawing.Point(7, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 30);
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TimeTracker.Properties.Resources.time;
            this.pictureBox1.Location = new System.Drawing.Point(7, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 24);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(15, 259);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(34, 13);
            this.labelError.TabIndex = 24;
            this.labelError.Text = "Error";
            // 
            // EditTimeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 293);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditTimeRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Time Record";
            this.Load += new System.EventHandler(this.EditTimeRecord_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxWorkId;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxWorkStartDate;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBoxWorkEndTime;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBoxPMONumber;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox textBoxTimeAccrued;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox textBoxFriendlyTime;
        private System.Windows.Forms.ComboBox comboBoxDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}