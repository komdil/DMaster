namespace TimeTracker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelCurrentTimer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxAbout = new System.Windows.Forms.PictureBox();
            this.labelScrollText = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonAppSettings = new System.Windows.Forms.Button();
            this.buttonManualEntry = new System.Windows.Forms.Button();
            this.buttonDisplayTimeSheetData = new System.Windows.Forms.Button();
            this.buttonStartTimer = new System.Windows.Forms.Button();
            this.buttonPauseTimer = new System.Windows.Forms.Button();
            this.labelTotalTimeToday = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelCurrentDate = new System.Windows.Forms.Label();
            this.labelTimerDescription = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCurrentTimer
            // 
            this.labelCurrentTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentTimer.ForeColor = System.Drawing.Color.Red;
            this.labelCurrentTimer.Location = new System.Drawing.Point(3, 68);
            this.labelCurrentTimer.Name = "labelCurrentTimer";
            this.labelCurrentTimer.Size = new System.Drawing.Size(427, 47);
            this.labelCurrentTimer.TabIndex = 0;
            this.labelCurrentTimer.Text = "00h : 00m : 00s";
            this.labelCurrentTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCurrentTimer.Click += new System.EventHandler(this.labelCurrentTimer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBoxAbout);
            this.panel1.Controls.Add(this.labelScrollText);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.buttonAppSettings);
            this.panel1.Controls.Add(this.buttonManualEntry);
            this.panel1.Controls.Add(this.buttonDisplayTimeSheetData);
            this.panel1.Controls.Add(this.buttonStartTimer);
            this.panel1.Controls.Add(this.buttonPauseTimer);
            this.panel1.Controls.Add(this.labelTotalTimeToday);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.labelCurrentDate);
            this.panel1.Controls.Add(this.labelTimerDescription);
            this.panel1.Controls.Add(this.labelCurrentTimer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 342);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBoxAbout
            // 
            this.pictureBoxAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAbout.Image = global::TimeTracker.Properties.Resources.help16;
            this.pictureBoxAbout.Location = new System.Drawing.Point(418, 323);
            this.pictureBoxAbout.Name = "pictureBoxAbout";
            this.pictureBoxAbout.Size = new System.Drawing.Size(22, 16);
            this.pictureBoxAbout.TabIndex = 12;
            this.pictureBoxAbout.TabStop = false;
            this.pictureBoxAbout.Click += new System.EventHandler(this.pictureBoxAbout_Click);
            // 
            // labelScrollText
            // 
            this.labelScrollText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScrollText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScrollText.Location = new System.Drawing.Point(0, 0);
            this.labelScrollText.Name = "labelScrollText";
            this.labelScrollText.Size = new System.Drawing.Size(436, 17);
            this.labelScrollText.TabIndex = 11;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(0, 323);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(390, 21);
            this.labelStatus.TabIndex = 10;
            this.labelStatus.Text = "Ready...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAppSettings
            // 
            this.buttonAppSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAppSettings.Enabled = false;
            this.buttonAppSettings.Image = global::TimeTracker.Properties.Resources.appsettings24;
            this.buttonAppSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAppSettings.Location = new System.Drawing.Point(7, 278);
            this.buttonAppSettings.Name = "buttonAppSettings";
            this.buttonAppSettings.Size = new System.Drawing.Size(101, 35);
            this.buttonAppSettings.TabIndex = 9;
            this.buttonAppSettings.Text = "App Settings";
            this.buttonAppSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAppSettings.UseVisualStyleBackColor = true;
            this.buttonAppSettings.Click += new System.EventHandler(this.buttonAppSettings_Click);
            // 
            // buttonManualEntry
            // 
            this.buttonManualEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonManualEntry.Image = global::TimeTracker.Properties.Resources.left_right;
            this.buttonManualEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonManualEntry.Location = new System.Drawing.Point(218, 278);
            this.buttonManualEntry.Name = "buttonManualEntry";
            this.buttonManualEntry.Size = new System.Drawing.Size(101, 35);
            this.buttonManualEntry.TabIndex = 8;
            this.buttonManualEntry.Text = "Manual Entry";
            this.buttonManualEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonManualEntry.UseVisualStyleBackColor = true;
            this.buttonManualEntry.Click += new System.EventHandler(this.buttonManualEntry_Click);
            // 
            // buttonDisplayTimeSheetData
            // 
            this.buttonDisplayTimeSheetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisplayTimeSheetData.Image = global::TimeTracker.Properties.Resources.time;
            this.buttonDisplayTimeSheetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDisplayTimeSheetData.Location = new System.Drawing.Point(325, 278);
            this.buttonDisplayTimeSheetData.Name = "buttonDisplayTimeSheetData";
            this.buttonDisplayTimeSheetData.Size = new System.Drawing.Size(101, 35);
            this.buttonDisplayTimeSheetData.TabIndex = 7;
            this.buttonDisplayTimeSheetData.Text = "Reporting";
            this.buttonDisplayTimeSheetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDisplayTimeSheetData.UseVisualStyleBackColor = true;
            this.buttonDisplayTimeSheetData.Click += new System.EventHandler(this.buttonDisplayTimeSheetData_Click);
            // 
            // buttonStartTimer
            // 
            this.buttonStartTimer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonStartTimer.Image = global::TimeTracker.Properties.Resources.start_new;
            this.buttonStartTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStartTimer.Location = new System.Drawing.Point(87, 174);
            this.buttonStartTimer.Name = "buttonStartTimer";
            this.buttonStartTimer.Size = new System.Drawing.Size(128, 46);
            this.buttonStartTimer.TabIndex = 6;
            this.buttonStartTimer.Text = "Start New\r\nTimer";
            this.buttonStartTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStartTimer.UseVisualStyleBackColor = true;
            this.buttonStartTimer.Click += new System.EventHandler(this.buttonStartTimer_Click);
            // 
            // buttonPauseTimer
            // 
            this.buttonPauseTimer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonPauseTimer.Image = global::TimeTracker.Properties.Resources.pause;
            this.buttonPauseTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPauseTimer.Location = new System.Drawing.Point(221, 174);
            this.buttonPauseTimer.Name = "buttonPauseTimer";
            this.buttonPauseTimer.Size = new System.Drawing.Size(128, 46);
            this.buttonPauseTimer.TabIndex = 5;
            this.buttonPauseTimer.Text = "Pause Current \r\nTimer";
            this.buttonPauseTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPauseTimer.UseVisualStyleBackColor = true;
            this.buttonPauseTimer.Click += new System.EventHandler(this.buttonPauseTimer_Click);
            // 
            // labelTotalTimeToday
            // 
            this.labelTotalTimeToday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalTimeToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalTimeToday.Location = new System.Drawing.Point(0, 240);
            this.labelTotalTimeToday.Name = "labelTotalTimeToday";
            this.labelTotalTimeToday.Size = new System.Drawing.Size(436, 21);
            this.labelTotalTimeToday.TabIndex = 4;
            this.labelTotalTimeToday.Text = "You have put X hours in today. Keep up the good work!";
            this.labelTotalTimeToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Image = global::TimeTracker.Properties.Resources.settings;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(114, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Setup Timers";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCurrentDate
            // 
            this.labelCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentDate.Location = new System.Drawing.Point(6, 33);
            this.labelCurrentDate.Name = "labelCurrentDate";
            this.labelCurrentDate.Size = new System.Drawing.Size(430, 31);
            this.labelCurrentDate.TabIndex = 2;
            this.labelCurrentDate.Text = "labelCurrentDate";
            this.labelCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTimerDescription
            // 
            this.labelTimerDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimerDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerDescription.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelTimerDescription.Location = new System.Drawing.Point(0, 115);
            this.labelTimerDescription.Name = "labelTimerDescription";
            this.labelTimerDescription.Size = new System.Drawing.Size(433, 36);
            this.labelTimerDescription.TabIndex = 1;
            this.labelTimerDescription.Text = "Work Area1";
            this.labelTimerDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 342);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Time Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonStartTimer;
        private System.Windows.Forms.Button buttonPauseTimer;
        private System.Windows.Forms.Label labelTotalTimeToday;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCurrentDate;
        private System.Windows.Forms.Label labelTimerDescription;
        private System.Windows.Forms.Button buttonDisplayTimeSheetData;
        private System.Windows.Forms.Button buttonManualEntry;
        private System.Windows.Forms.Button buttonAppSettings;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelScrollText;
        private System.Windows.Forms.PictureBox pictureBoxAbout;
    }
}

