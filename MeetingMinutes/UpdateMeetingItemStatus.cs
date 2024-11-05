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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MeetingMinutes
{
    public partial class UpdateMeetingItemStatus : Form
    {
        public int statusID {  get; set; }
        MeetingItemStatus updateStatus = null;

        public UpdateMeetingItemStatus(int StatusID)
        {
            InitializeComponent();

            statusID = StatusID;

            MeetingItemDAO meetingItemDAO = new MeetingItemDAO();
            updateStatus = meetingItemDAO.getMeetingItemStatusByStatusID(statusID);

            txtStatus.Text = updateStatus.Status.ToString();
            txtActionRequired.Text = updateStatus.ActionRequired.ToString();
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            MeetingItemDAO meetingItemDAO = new MeetingItemDAO();

            MeetingItemStatus newStatus = new MeetingItemStatus()
            {
                ID = statusID,
                MeetingItemID = updateStatus.MeetingItemID,
                MeetingID = updateStatus.MeetingID,
                Status = txtStatus.Text,
                ActionRequired = txtActionRequired.Text,
                DateUpdated = DateTime.Now
            };

            int result = meetingItemDAO.updateMeetingItemStatus(newStatus, statusID);

            if (result > 0)
            {
                MessageBox.Show("Status Updated Successfully", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No Changes Made", "Record Update Failed", MessageBoxButtons.OK);
            }


        }
    }
}
