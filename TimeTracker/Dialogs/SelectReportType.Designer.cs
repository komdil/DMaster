namespace TimeTracker.Dialogs
{
    partial class SelectReportType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectReportType));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDetailedReport = new System.Windows.Forms.Button();
            this.buttonSummaryReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonDetailedReport);
            this.panel1.Controls.Add(this.buttonSummaryReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 101);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "An breakdown of each days hours";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "An overview of the weeks hours";
            // 
            // buttonDetailedReport
            // 
            this.buttonDetailedReport.Image = global::TimeTracker.Properties.Resources.report_detailed;
            this.buttonDetailedReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetailedReport.Location = new System.Drawing.Point(16, 52);
            this.buttonDetailedReport.Name = "buttonDetailedReport";
            this.buttonDetailedReport.Size = new System.Drawing.Size(124, 37);
            this.buttonDetailedReport.TabIndex = 5;
            this.buttonDetailedReport.Text = "Detailed Report";
            this.buttonDetailedReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDetailedReport.UseVisualStyleBackColor = true;
            this.buttonDetailedReport.Click += new System.EventHandler(this.buttonDetailedReport_Click);
            // 
            // buttonSummaryReport
            // 
            this.buttonSummaryReport.Image = global::TimeTracker.Properties.Resources.report_summary;
            this.buttonSummaryReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSummaryReport.Location = new System.Drawing.Point(16, 10);
            this.buttonSummaryReport.Name = "buttonSummaryReport";
            this.buttonSummaryReport.Size = new System.Drawing.Size(124, 37);
            this.buttonSummaryReport.TabIndex = 4;
            this.buttonSummaryReport.Text = "Summary Report";
            this.buttonSummaryReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSummaryReport.UseVisualStyleBackColor = true;
            this.buttonSummaryReport.Click += new System.EventHandler(this.buttonSummaryReport_Click);
            // 
            // SelectReportType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 101);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectReportType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Report Type";
            this.Load += new System.EventHandler(this.SelectReportType_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDetailedReport;
        private System.Windows.Forms.Button buttonSummaryReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}