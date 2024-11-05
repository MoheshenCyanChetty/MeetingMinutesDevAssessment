namespace MeetingMinutes
{
    partial class MeetingMinutes
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
            groupBox1 = new GroupBox();
            btnCaptureNewMeeting = new Button();
            label3 = new Label();
            label2 = new Label();
            dtMeetingTime = new DateTimePicker();
            label1 = new Label();
            dtMeetingDate = new DateTimePicker();
            cbMeetingType = new ComboBox();
            dgvMeeting = new DataGridView();
            btnRefresh = new Button();
            btnShowMinutes = new Button();
            btnDeleteMeeting = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMeeting).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCaptureNewMeeting);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtMeetingTime);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtMeetingDate);
            groupBox1.Controls.Add(cbMeetingType);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(287, 220);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Schedule A Meeting";
            // 
            // btnCaptureNewMeeting
            // 
            btnCaptureNewMeeting.Location = new Point(15, 177);
            btnCaptureNewMeeting.Name = "btnCaptureNewMeeting";
            btnCaptureNewMeeting.Size = new Size(250, 23);
            btnCaptureNewMeeting.TabIndex = 5;
            btnCaptureNewMeeting.Text = "Capture New Meeting";
            btnCaptureNewMeeting.UseVisualStyleBackColor = true;
            btnCaptureNewMeeting.Click += btnCaptureNewMeeting_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 134);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 5;
            label3.Text = "Set Meeting Time:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 85);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 4;
            label2.Text = "Set Meeting Date:";
            // 
            // dtMeetingTime
            // 
            dtMeetingTime.CustomFormat = "hh:mmtt";
            dtMeetingTime.Format = DateTimePickerFormat.Custom;
            dtMeetingTime.Location = new Point(144, 129);
            dtMeetingTime.Name = "dtMeetingTime";
            dtMeetingTime.ShowUpDown = true;
            dtMeetingTime.Size = new Size(121, 23);
            dtMeetingTime.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 36);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 3;
            label1.Text = "Select Meeting Type:";
            // 
            // dtMeetingDate
            // 
            dtMeetingDate.CustomFormat = "yyyy-MM-dd";
            dtMeetingDate.Format = DateTimePickerFormat.Custom;
            dtMeetingDate.Location = new Point(144, 81);
            dtMeetingDate.Name = "dtMeetingDate";
            dtMeetingDate.Size = new Size(121, 23);
            dtMeetingDate.TabIndex = 3;
            // 
            // cbMeetingType
            // 
            cbMeetingType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMeetingType.FormattingEnabled = true;
            cbMeetingType.Location = new Point(144, 33);
            cbMeetingType.Name = "cbMeetingType";
            cbMeetingType.Size = new Size(121, 23);
            cbMeetingType.TabIndex = 1;
            cbMeetingType.SelectedIndexChanged += cbMeetingType_SelectedIndexChanged;
            // 
            // dgvMeeting
            // 
            dgvMeeting.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeeting.Location = new Point(305, 21);
            dgvMeeting.Name = "dgvMeeting";
            dgvMeeting.RowTemplate.Height = 25;
            dgvMeeting.Size = new Size(528, 182);
            dgvMeeting.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(750, 209);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(83, 23);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnShowMinutes
            // 
            btnShowMinutes.Location = new Point(305, 209);
            btnShowMinutes.Name = "btnShowMinutes";
            btnShowMinutes.Size = new Size(141, 23);
            btnShowMinutes.TabIndex = 5;
            btnShowMinutes.Text = "Show Minutes";
            btnShowMinutes.UseVisualStyleBackColor = true;
            btnShowMinutes.Click += btnShowMinutes_Click;
            // 
            // btnDeleteMeeting
            // 
            btnDeleteMeeting.Location = new Point(452, 209);
            btnDeleteMeeting.Name = "btnDeleteMeeting";
            btnDeleteMeeting.Size = new Size(145, 23);
            btnDeleteMeeting.TabIndex = 6;
            btnDeleteMeeting.Text = "Delete Selected Meeting";
            btnDeleteMeeting.UseVisualStyleBackColor = true;
            btnDeleteMeeting.Click += btnDeleteMeeting_Click;
            // 
            // MeetingMinutes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(850, 246);
            Controls.Add(btnDeleteMeeting);
            Controls.Add(btnShowMinutes);
            Controls.Add(btnRefresh);
            Controls.Add(dgvMeeting);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MeetingMinutes";
            Text = "Meeting Minutes";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMeeting).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Label label1;
        private DateTimePicker dtMeetingDate;
        private ComboBox cbMeetingType;
        private DataGridView dgvMeeting;
        private DateTimePicker dtMeetingTime;
        private Label label3;
        private Label label2;
        private Button btnCaptureNewMeeting;
        private Button btnRefresh;
        private Button btnShowMinutes;
        private Button btnDeleteMeeting;
        private RadioButton rbEditMode;
    }
}
