using MeetingMinutes.DAO;
using MeetingMinutes.Models;

namespace MeetingMinutes
{
    public partial class MeetingMinutes : Form
    {
        BindingSource meetingBindingSource = new BindingSource();

        List<Meeting> meetings = new List<Meeting>();
        public MeetingMinutes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadMeetingData();
        }

        #region Load
        private void LoadMeetingData()
        {
            MeetingDAO meetingDAO = new MeetingDAO();

            meetings = meetingDAO.getAllMeetings();

            meetingBindingSource.DataSource = meetings;
            dgvMeeting.DataSource = meetingBindingSource;
            dgvMeeting.AllowUserToAddRows = false;
            dgvMeeting.ReadOnly = true;

            dgvMeeting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMeeting.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeeting.Columns["MeetingTypeID"].Visible = false;

        }

        private void LoadMeetingDataByMeetingType(int meetingTypeID)
        {
            MeetingDAO meetingDAO = new MeetingDAO();
            string meetingTypeName = cbMeetingType.Text;
            int selectedID = meetingDAO.GetMeetingTypeIDByMeetingTypeName(meetingTypeName);


            meetings = meetingDAO.getAllMeetingsByMeetingTypeID(selectedID);

            meetingBindingSource.DataSource = meetings;
            dgvMeeting.DataSource = meetingBindingSource;
        }

        private void LoadComboBoxData()
        {
            MeetingDAO meetingDAO = new MeetingDAO();

            List<string> meetingTypeNames = meetingDAO.getMeetingTypeNames();

            cbMeetingType.DataSource = meetingTypeNames;
            cbMeetingType.SelectedIndex = -1;
        }
        #endregion


        private void btnCaptureNewMeeting_Click(object sender, EventArgs e)
        {
            MeetingDAO meetingDAO = new MeetingDAO();

            string meetingTypeName = cbMeetingType.Text;
            DateTime MeetingDate = dtMeetingDate.Value;
            DateTime MeetingTime = dtMeetingTime.Value;
            DateOnly dateOnly = DateOnly.FromDateTime(MeetingDate);
            TimeOnly timeOnly = TimeOnly.FromDateTime(MeetingTime);

            DialogResult confirmCreate = MessageBox.Show("Create This Meeting?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmCreate == DialogResult.Yes)
            {
                try
                {
                    int selectedID = meetingDAO.GetMeetingTypeIDByMeetingTypeName(meetingTypeName);
                    int meetingNumber = meetingDAO.GetNextMeetingNumber(selectedID);
                    int previousMeetingNumber;
                    int previousMeetingID;

                    Meeting meeting = new Meeting()
                    {
                        MeetingTypeID = selectedID,
                        MeetingNumber = meetingNumber,
                        MeetingDate = DateOnly.FromDateTime(MeetingDate),
                        MeetingTime = TimeOnly.FromDateTime(MeetingTime)
                    };

                    if (meeting.MeetingNumber > 1)
                    {
                        previousMeetingNumber = meeting.MeetingNumber - 1;
                        previousMeetingID = meetingDAO.GetMeetingIDByMeetingNumber(previousMeetingNumber, selectedID);

                        Minutes mins = new Minutes(meeting, previousMeetingID);
                        mins.ShowDialog();
                    }
                    else
                    {
                        previousMeetingNumber = meeting.MeetingNumber;
                        var result = MessageBox.Show("Create new Meeting with No Items?", "No Previous Meeting Found", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            int newMeeting = meetingDAO.CaptureNewMeeting(meeting);
                            LoadMeetingData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Select a Meeting Type", "Missing Type");
                }
            }
            else
            {
                MessageBox.Show("Meeting Capture Cancelled", "Cancelled");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMeetingData();
        }

        private void btnDeleteMeeting_Click(object sender, EventArgs e)
        {
            int rowClicked = dgvMeeting.CurrentRow.Index;
            int meetingID = (int)dgvMeeting.Rows[rowClicked].Cells[0].Value;

            MeetingDAO meetingDAO = new MeetingDAO();

            DialogResult confirmResult = MessageBox.Show("Are You Sure You Want To Delete This Meeting?", "Confirm", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    meetingDAO.DeleteMeeting(meetingID);
                    MessageBox.Show("Meeting Deleted");

                    dgvMeeting.DataSource = null;
                    LoadMeetingData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Deletion Cancelled", "Cancelled");
            }
        }

        private void cbMeetingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeetingDAO meetingDAO = new MeetingDAO();

            string meetingTypeName = cbMeetingType.Text;
            int selectedID = meetingDAO.GetMeetingTypeIDByMeetingTypeName(meetingTypeName);

            LoadMeetingDataByMeetingType(selectedID);
        }

        private void btnShowMinutes_Click(object sender, EventArgs e)
        {
            if (dgvMeeting.CurrentRow != null)
            {
                MeetingDAO meetingDAO = new MeetingDAO();

                int rowClicked = dgvMeeting.CurrentRow.Index;
                int meetingID = (int)dgvMeeting.Rows[rowClicked].Cells[0].Value;

                string meetingTypeName = meetingDAO.GetMeetingTypeNameByMeetingID(meetingID);
                string meetingTypeCode = meetingDAO.GetMeetingTypeCodeByMeetingID(meetingID);
                int meetingNumber = meetingDAO.GetMeetingNumberByMeetingID(meetingID);
                DateOnly meetingDate = meetingDAO.GetMeetingDateByMeetingID(meetingID);


                Minutes mins = new Minutes(meetingID, meetingTypeName , meetingTypeCode, meetingNumber, meetingDate);
                mins.Show();
            }
            else
            {
                MessageBox.Show("Please select a Meeting.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
