namespace MeetingMinutes
{
    partial class CreateMeetingItemForm
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
            txtItemName = new TextBox();
            rtxtDescription = new RichTextBox();
            txtStatus = new TextBox();
            txtResponsiblePerson = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            rtxtRequiredAction = new RichTextBox();
            btnCreateMeetingItem = new Button();
            SuspendLayout();
            // 
            // txtItemName
            // 
            txtItemName.Location = new Point(21, 35);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(266, 23);
            txtItemName.TabIndex = 0;
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(21, 83);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(266, 211);
            rtxtDescription.TabIndex = 1;
            rtxtDescription.Text = "";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(318, 159);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(266, 23);
            txtStatus.TabIndex = 2;
            // 
            // txtResponsiblePerson
            // 
            txtResponsiblePerson.Location = new Point(318, 209);
            txtResponsiblePerson.Name = "txtResponsiblePerson";
            txtResponsiblePerson.Size = new Size(266, 23);
            txtResponsiblePerson.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 17);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 5;
            label1.Text = "Meeting Item Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 65);
            label2.Name = "label2";
            label2.Size = new Size(126, 15);
            label2.TabIndex = 6;
            label2.Text = "Description/Comment";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(318, 17);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 7;
            label3.Text = "Required Action";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(318, 141);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 8;
            label4.Text = "Status";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(318, 191);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 9;
            label5.Text = "Person Responsible";
            // 
            // rtxtRequiredAction
            // 
            rtxtRequiredAction.Location = new Point(318, 35);
            rtxtRequiredAction.Name = "rtxtRequiredAction";
            rtxtRequiredAction.Size = new Size(266, 102);
            rtxtRequiredAction.TabIndex = 10;
            rtxtRequiredAction.Text = "";
            // 
            // btnCreateMeetingItem
            // 
            btnCreateMeetingItem.Location = new Point(318, 248);
            btnCreateMeetingItem.Name = "btnCreateMeetingItem";
            btnCreateMeetingItem.Size = new Size(266, 46);
            btnCreateMeetingItem.TabIndex = 12;
            btnCreateMeetingItem.Text = "Create Meeting Item";
            btnCreateMeetingItem.UseVisualStyleBackColor = true;
            btnCreateMeetingItem.Click += btnCreateMeetingItem_Click;
            // 
            // CreateMeetingItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 311);
            Controls.Add(btnCreateMeetingItem);
            Controls.Add(rtxtRequiredAction);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtResponsiblePerson);
            Controls.Add(txtStatus);
            Controls.Add(rtxtDescription);
            Controls.Add(txtItemName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CreateMeetingItemForm";
            Text = "Create Meeting Item";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtItemName;
        private RichTextBox rtxtDescription;
        private TextBox txtStatus;
        private TextBox txtResponsiblePerson;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox rtxtRequiredAction;
        private Button btnCreateMeetingItem;
    }
}