namespace MeetingMinutes
{
    partial class Minutes
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
            dgvMeetingItems = new DataGridView();
            btnCreateMeetingItem = new Button();
            lblMeetingTitle = new Label();
            btnEditStatus = new Button();
            lblMeetingDate = new Label();
            btnRefresh = new Button();
            btnConfirmItems = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMeetingItems).BeginInit();
            SuspendLayout();
            // 
            // dgvMeetingItems
            // 
            dgvMeetingItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMeetingItems.Location = new Point(12, 45);
            dgvMeetingItems.Name = "dgvMeetingItems";
            dgvMeetingItems.RowTemplate.Height = 25;
            dgvMeetingItems.Size = new Size(776, 327);
            dgvMeetingItems.TabIndex = 0;
            dgvMeetingItems.CellContentClick += dgvMeetingItems_CellContentClick;
            // 
            // btnCreateMeetingItem
            // 
            btnCreateMeetingItem.Location = new Point(12, 378);
            btnCreateMeetingItem.Name = "btnCreateMeetingItem";
            btnCreateMeetingItem.Size = new Size(161, 23);
            btnCreateMeetingItem.TabIndex = 1;
            btnCreateMeetingItem.Text = "Create Meeting Item";
            btnCreateMeetingItem.UseVisualStyleBackColor = true;
            btnCreateMeetingItem.Click += btnCreateMeetingItem_Click;
            // 
            // lblMeetingTitle
            // 
            lblMeetingTitle.AutoSize = true;
            lblMeetingTitle.Location = new Point(22, 16);
            lblMeetingTitle.Name = "lblMeetingTitle";
            lblMeetingTitle.Size = new Size(73, 15);
            lblMeetingTitle.TabIndex = 2;
            lblMeetingTitle.Text = "MeetingTitle";
            // 
            // btnEditStatus
            // 
            btnEditStatus.Location = new Point(179, 378);
            btnEditStatus.Name = "btnEditStatus";
            btnEditStatus.Size = new Size(121, 23);
            btnEditStatus.TabIndex = 3;
            btnEditStatus.Text = "Edit Status";
            btnEditStatus.UseVisualStyleBackColor = true;
            btnEditStatus.Click += btnEditStatus_Click;
            // 
            // lblMeetingDate
            // 
            lblMeetingDate.AutoSize = true;
            lblMeetingDate.Location = new Point(710, 16);
            lblMeetingDate.Name = "lblMeetingDate";
            lblMeetingDate.Size = new Size(78, 15);
            lblMeetingDate.TabIndex = 4;
            lblMeetingDate.Text = "Meeting Date";
            lblMeetingDate.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(710, 377);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnConfirmItems
            // 
            btnConfirmItems.Location = new Point(12, 378);
            btnConfirmItems.Name = "btnConfirmItems";
            btnConfirmItems.Size = new Size(161, 23);
            btnConfirmItems.TabIndex = 6;
            btnConfirmItems.Text = "Confirm Items";
            btnConfirmItems.UseVisualStyleBackColor = true;
            btnConfirmItems.Click += btnConfirmItems_Click;
            // 
            // Minutes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 412);
            Controls.Add(btnConfirmItems);
            Controls.Add(btnRefresh);
            Controls.Add(lblMeetingDate);
            Controls.Add(btnEditStatus);
            Controls.Add(lblMeetingTitle);
            Controls.Add(btnCreateMeetingItem);
            Controls.Add(dgvMeetingItems);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Minutes";
            Text = "Minutes";
            ((System.ComponentModel.ISupportInitialize)dgvMeetingItems).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMeetingItems;
        private Button btnCreateMeetingItem;
        private Label lblMeetingTitle;
        private Button btnEditStatus;
        private Label lblMeetingDate;
        private Button btnRefresh;
        private Button btnConfirmItems;
    }
}