using MeetingMinutes.DAO;
using MeetingMinutes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingMinutes
{
    public partial class CreateMeetingItemForm : Form
    {
        private int meetingID;

        public CreateMeetingItemForm(int MeetingID)
        {
            InitializeComponent();
            meetingID = MeetingID;
        }

        private void btnCreateMeetingItem_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            string description = rtxtDescription.Text;
            string status = txtStatus.Text;
            string responsiblePerson = txtResponsiblePerson.Text;
            string requiredAction = rtxtRequiredAction.Text;

            // Create a new MeetingItem
            MeetingItem meetingItem = new MeetingItem
            {
                MeetingID = meetingID,
                ItemName = itemName,
                Description = description,
                DateCreated = DateTime.Now,
                ResponsiblePerson = responsiblePerson,
                Statuses = new List<MeetingItemStatus>
            {
                new MeetingItemStatus
                {
                    Status = status,
                    ActionRequired = requiredAction,
                    DateUpdated = DateTime.Now
                }
            }
            };

            MeetingItemDAO meetingItemDAO = new MeetingItemDAO();
            int newMeetingItemID = meetingItemDAO.createNewMeetingItem(meetingItem);

            if (newMeetingItemID > 0)
            {
                MessageBox.Show("Meeting Item created successfully!", "Success", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to create Meeting Item.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
