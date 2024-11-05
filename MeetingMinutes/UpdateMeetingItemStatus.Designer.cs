namespace MeetingMinutes
{
    partial class UpdateMeetingItemStatus
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
            txtStatus = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtActionRequired = new TextBox();
            btnSaveEdit = new Button();
            SuspendLayout();
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(138, 32);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(173, 23);
            txtStatus.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 35);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Status";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 81);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 3;
            label2.Text = "Action Required";
            // 
            // txtActionRequired
            // 
            txtActionRequired.Location = new Point(138, 78);
            txtActionRequired.Name = "txtActionRequired";
            txtActionRequired.Size = new Size(173, 23);
            txtActionRequired.TabIndex = 2;
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Location = new Point(32, 141);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(279, 47);
            btnSaveEdit.TabIndex = 4;
            btnSaveEdit.Text = "Save";
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Click += btnSaveEdit_Click;
            // 
            // UpdateMeetingItemStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 210);
            Controls.Add(btnSaveEdit);
            Controls.Add(label2);
            Controls.Add(txtActionRequired);
            Controls.Add(label1);
            Controls.Add(txtStatus);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "UpdateMeetingItemStatus";
            Text = "Update Item Status";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStatus;
        private Label label1;
        private Label label2;
        private TextBox txtActionRequired;
        private Button btnSaveEdit;
    }
}