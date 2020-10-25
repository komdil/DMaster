namespace TimeTracker.Dialogs
{
    partial class UnpauseTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnpauseTimer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton60Mins = new System.Windows.Forms.RadioButton();
            this.radioButton30Mins = new System.Windows.Forms.RadioButton();
            this.radioButtonCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonNever = new System.Windows.Forms.RadioButton();
            this.radioButton15Mins = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCustomMins = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.radioButton60Mins);
            this.panel1.Controls.Add(this.radioButton30Mins);
            this.panel1.Controls.Add(this.radioButtonCustom);
            this.panel1.Controls.Add(this.radioButtonNever);
            this.panel1.Controls.Add(this.radioButton15Mins);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxCustomMins);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 158);
            this.panel1.TabIndex = 2;
            // 
            // radioButton60Mins
            // 
            this.radioButton60Mins.AutoSize = true;
            this.radioButton60Mins.Location = new System.Drawing.Point(104, 48);
            this.radioButton60Mins.Name = "radioButton60Mins";
            this.radioButton60Mins.Size = new System.Drawing.Size(62, 17);
            this.radioButton60Mins.TabIndex = 14;
            this.radioButton60Mins.TabStop = true;
            this.radioButton60Mins.Text = "60 Mins";
            this.radioButton60Mins.UseVisualStyleBackColor = true;
            this.radioButton60Mins.CheckedChanged += new System.EventHandler(this.radioButton60Mins_CheckedChanged);
            // 
            // radioButton30Mins
            // 
            this.radioButton30Mins.AutoSize = true;
            this.radioButton30Mins.Location = new System.Drawing.Point(104, 29);
            this.radioButton30Mins.Name = "radioButton30Mins";
            this.radioButton30Mins.Size = new System.Drawing.Size(62, 17);
            this.radioButton30Mins.TabIndex = 13;
            this.radioButton30Mins.TabStop = true;
            this.radioButton30Mins.Text = "30 Mins";
            this.radioButton30Mins.UseVisualStyleBackColor = true;
            this.radioButton30Mins.CheckedChanged += new System.EventHandler(this.radioButton30Mins_CheckedChanged);
            // 
            // radioButtonCustom
            // 
            this.radioButtonCustom.AutoSize = true;
            this.radioButtonCustom.Location = new System.Drawing.Point(104, 68);
            this.radioButtonCustom.Name = "radioButtonCustom";
            this.radioButtonCustom.Size = new System.Drawing.Size(60, 17);
            this.radioButtonCustom.TabIndex = 12;
            this.radioButtonCustom.TabStop = true;
            this.radioButtonCustom.Text = "Custom";
            this.radioButtonCustom.UseVisualStyleBackColor = true;
            this.radioButtonCustom.CheckedChanged += new System.EventHandler(this.radioButtonCustom_CheckedChanged);
            // 
            // radioButtonNever
            // 
            this.radioButtonNever.AutoSize = true;
            this.radioButtonNever.Location = new System.Drawing.Point(104, 87);
            this.radioButtonNever.Name = "radioButtonNever";
            this.radioButtonNever.Size = new System.Drawing.Size(54, 17);
            this.radioButtonNever.TabIndex = 10;
            this.radioButtonNever.TabStop = true;
            this.radioButtonNever.Text = "Never";
            this.radioButtonNever.UseVisualStyleBackColor = true;
            this.radioButtonNever.CheckedChanged += new System.EventHandler(this.radioButtonNever_CheckedChanged);
            // 
            // radioButton15Mins
            // 
            this.radioButton15Mins.AutoSize = true;
            this.radioButton15Mins.Location = new System.Drawing.Point(104, 10);
            this.radioButton15Mins.Name = "radioButton15Mins";
            this.radioButton15Mins.Size = new System.Drawing.Size(62, 17);
            this.radioButton15Mins.TabIndex = 9;
            this.radioButton15Mins.TabStop = true;
            this.radioButton15Mins.Text = "15 Mins";
            this.radioButton15Mins.UseVisualStyleBackColor = true;
            this.radioButton15Mins.CheckedChanged += new System.EventHandler(this.radioButton15Mins_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mins";
            // 
            // textBoxCustomMins
            // 
            this.textBoxCustomMins.Location = new System.Drawing.Point(171, 68);
            this.textBoxCustomMins.Name = "textBoxCustomMins";
            this.textBoxCustomMins.Size = new System.Drawing.Size(48, 20);
            this.textBoxCustomMins.TabIndex = 5;
            this.textBoxCustomMins.TextChanged += new System.EventHandler(this.textBoxCustomMins_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unpause After:";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(98, 123);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(179, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UnpauseTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 158);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UnpauseTimer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Unpause Timer";
            this.Load += new System.EventHandler(this.UnpauseTimer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.RadioButton radioButtonNever;
        private System.Windows.Forms.RadioButton radioButton15Mins;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCustomMins;
        private System.Windows.Forms.RadioButton radioButtonCustom;
        private System.Windows.Forms.RadioButton radioButton60Mins;
        private System.Windows.Forms.RadioButton radioButton30Mins;
    }
}