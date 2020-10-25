namespace TimeTracker.Dialogs
{
    partial class ReportDetailed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportDetailed));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonPrevDay = new System.Windows.Forms.Button();
            this.buttonNextDay = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WorkId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMODesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeAccrued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.buttonEdit);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.labelDescription);
            this.panel1.Controls.Add(this.buttonPrevDay);
            this.panel1.Controls.Add(this.buttonNextDay);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 281);
            this.panel1.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::TimeTracker.Properties.Resources.edit_delete24;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(5, 82);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(96, 33);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Image = global::TimeTracker.Properties.Resources.edit_go24;
            this.buttonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEdit.Location = new System.Drawing.Point(5, 43);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(96, 33);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::TimeTracker.Properties.Resources.edit_add24;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(5, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(96, 33);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelDescription.Location = new System.Drawing.Point(209, 238);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(440, 31);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Today";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPrevDay
            // 
            this.buttonPrevDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrevDay.Image = global::TimeTracker.Properties.Resources.previous_record;
            this.buttonPrevDay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrevDay.Location = new System.Drawing.Point(107, 236);
            this.buttonPrevDay.Name = "buttonPrevDay";
            this.buttonPrevDay.Size = new System.Drawing.Size(96, 33);
            this.buttonPrevDay.TabIndex = 2;
            this.buttonPrevDay.Text = "Prev Day";
            this.buttonPrevDay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPrevDay.UseVisualStyleBackColor = true;
            this.buttonPrevDay.Click += new System.EventHandler(this.buttonPrevDay_Click);
            // 
            // buttonNextDay
            // 
            this.buttonNextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNextDay.Image = global::TimeTracker.Properties.Resources.start_new;
            this.buttonNextDay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonNextDay.Location = new System.Drawing.Point(655, 236);
            this.buttonNextDay.Name = "buttonNextDay";
            this.buttonNextDay.Size = new System.Drawing.Size(96, 33);
            this.buttonNextDay.TabIndex = 1;
            this.buttonNextDay.Text = "Next Day";
            this.buttonNextDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNextDay.UseVisualStyleBackColor = true;
            this.buttonNextDay.Click += new System.EventHandler(this.buttonNextDay_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkId,
            this.Date,
            this.WorkStartTime,
            this.WorkEndTime,
            this.PMONumber,
            this.PMODesc,
            this.TimeAccrued});
            this.dataGridView1.Location = new System.Drawing.Point(107, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(656, 230);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // WorkId
            // 
            this.WorkId.HeaderText = "WorkId";
            this.WorkId.Name = "WorkId";
            this.WorkId.Width = 60;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 80;
            // 
            // WorkStartTime
            // 
            this.WorkStartTime.HeaderText = "WorkStartTime";
            this.WorkStartTime.Name = "WorkStartTime";
            this.WorkStartTime.Width = 120;
            // 
            // WorkEndTime
            // 
            this.WorkEndTime.HeaderText = "WorkEndTime";
            this.WorkEndTime.Name = "WorkEndTime";
            this.WorkEndTime.Width = 120;
            // 
            // PMONumber
            // 
            this.PMONumber.HeaderText = "PMONumber";
            this.PMONumber.Name = "PMONumber";
            // 
            // PMODesc
            // 
            this.PMODesc.HeaderText = "PMODesc";
            this.PMODesc.Name = "PMODesc";
            // 
            // TimeAccrued
            // 
            this.TimeAccrued.HeaderText = "TimeAccrued";
            this.TimeAccrued.Name = "TimeAccrued";
            this.TimeAccrued.Width = 90;
            // 
            // ReportDetailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 281);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportDetailed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detailed Report";
            this.Load += new System.EventHandler(this.DetailedReport_Load);
            this.Shown += new System.EventHandler(this.DetailedReport_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonPrevDay;
        private System.Windows.Forms.Button buttonNextDay;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMODesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeAccrued;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
    }
}