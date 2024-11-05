using MeetingMinutes.DAO;
using MeetingMinutes.Models;
using Org.BouncyCastle.Crypto.Agreement.Kdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingMinutes
{
    public partial class Minutes : Form
    {
        public int meetingID { get; set; }
        public string meetingTypeName { get; set; }
        public string meetingTypeCode { get; set; }
        public int meetingNumber { get; set; }
        public DateOnly meetingDate { get; set; }
        public Meeting newMeeting { get; set; }
        public int previousMeetingID { get; set; }
        bool isSelectConstructor { get; set; }

        BindingSource meetingItemsBindingSource = new BindingSource();

        List<MeetingItem> meetingItems = new List<MeetingItem>();
        List<int> selectedMeetingItemIDs = new List<int>();

        // from view minutes button
        public Minutes(int MeetingID, string MeetingTypeName, string MeetingTypeCode, int MeetingNumber, DateOnly MeetingDate)
        {
            InitializeComponent();
            isSelectConstructor = false;

            meetingID = MeetingID;
            meetingTypeName = MeetingTypeName;
            meetingTypeCode = MeetingTypeCode;
            meetingNumber = MeetingNumber;
            meetingDate = MeetingDate;

            dgvMeetingItems.ReadOnly = true;
            lblMeetingTitle.Text = $"{meetingTypeName} {meetingTypeCode}{meetingNumber}";
            lblMeetingDate.Text = meetingDate.ToString();
            lblMeetingDate.Visible = true;
            btnConfirmItems.Visible = false;


            LoadMeetingItemData();
        }

        // from capture meeting button (select records and push forward to create meeting)
        public Minutes(Meeting NewMeeting, int PreviousMeetingID)
        {
            InitializeComponent();
            isSelectConstructor = true;

            newMeeting = NewMeeting;
            previousMeetingID = PreviousMeetingID;
            Text = "Confirm Meeting Items";

            dgvMeetingItems.ReadOnly = true;
            lblMeetingTitle.Text = "Select Meeting Items";
            lblMeetingDate.Visible = false;
            btnCreateMeetingItem.Visible = false;
            btnEditStatus.Visible = false;
            btnRefresh.Visible = false;

            LoadPreviousMeetingItemData();
        }

        private void SetUpDataGridViewColumns()
        {
            dgvMeetingItems.Columns.Add("MeetingItemID", "Item ID");
            dgvMeetingItems.Columns.Add("ItemName", "Meeting Item");
            dgvMeetingItems.Columns.Add("Description", "Description");
            dgvMeetingItems.Columns.Add("Status", "Status");
            dgvMeetingItems.Columns.Add("ActionRequired", "Action Required");
            dgvMeetingItems.Columns.Add("ResponsiblePerson", "Person Responsible");
            dgvMeetingItems.Columns.Add("DateCreated", "Date Created");
            dgvMeetingItems.Columns.Add("DateUpdated", "Date Updated");
        }

        private void LoadPreviousMeetingItemData()
        {
            MeetingItemDAO meetingItemDAO = new MeetingItemDAO();
            List<MeetingItem> meetingItems = meetingItemDAO.getAllMeetingItemsWithStatusUsingMeetingID(previousMeetingID);

            dgvMeetingItems.AllowUserToAddRows = false;
            dgvMeetingItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeetingItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMeetingItems.MultiSelect = true;

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Select",
                Width = 50,
                Name = "SelectColumn"
            };
            dgvMeetingItems.Columns.Clear();
            dgvMeetingItems.Columns.Add(selectColumn);
            dgvMeetingItems.Columns["SelectColumn"].ReadOnly = false;

            SetUpDataGridViewColumns();

            foreach (var item in meetingItems)
            {
                foreach (var status in item.Statuses)
                {
                    dgvMeetingItems.Rows.Add(
                        false,
                        item.ID,
                        item.ItemName,
                        item.Description,
                        status.Status,
                        status.ActionRequired,
                        item.ResponsiblePerson,
                        item.DateCreated,
                        status.DateUpdated
                    );
                }
            }
        }

        private void LoadMeetingItemData()
        {
            MeetingItemDAO meetingItemDAO = new MeetingItemDAO();
            List<MeetingItem> meetingItems = meetingItemDAO.getAllMeetingItemsWithStatusUsingMeetingID(meetingID);

            dgvMeetingItems.AllowUserToAddRows = false;
            dgvMeetingItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeetingItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMeetingItems.Columns.Clear();
            SetUpDataGridViewColumns();

            foreach (var item in meetingItems)
            {
                foreach (var status in item.Statuses)
                {
                    dgvMeetingItems.Rows.Add(
                        item.ID,
                        item.ItemName,
                        item.Description,
                        status.Status,
                        status.ActionRequired,
                        item.ResponsiblePerson,
                        item.DateCreated,
                        status.DateUpdated
                    );
                }
            }
        }
        private void btnEditStatus_Click(object sender, EventArgs e)
        {
            MeetingItemDAO meetingItemDAO = new MeetingItemDAO();
            int rowClicked = dgvMeetingItems.CurrentRow.Index;
            int meetingItemID = (int)dgvMeetingItems.Rows[rowClicked].Cells[0].Value;
            int statusID = meetingItemDAO.getStatusIDByMeetingItemID(meetingItemID);

            UpdateMeetingItemStatus updateStatusForm = new UpdateMeetingItemStatus(statusID);
            updateStatusForm.ShowDialog();

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMeetingItemData();
        }
        private void btnCreateMeetingItem_Click(object sender, EventArgs e)
        {
            if (meetingID > 0)
            {
                CreateMeetingItemForm createMeetingItemForm = new CreateMeetingItemForm(meetingID);
                createMeetingItemForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Meeting ID.", "Error", MessageBoxButtons.OK);
            }

        }

        private List<int> GetSelectedMeetingItemIDs()
        {
            List<int> selectedMeetingItemIDs = new List<int>();

            foreach (DataGridViewRow row in dgvMeetingItems.Rows)
            {
                if (Convert.ToBoolean(row.Cells["SelectColumn"].Value) == true && row.Index >= 0)
                {
                    if (row.Cells["MeetingItemID"].Value != null &&
                        int.TryParse(row.Cells["MeetingItemID"].Value.ToString(), out int meetingItemID))
                    {
                        selectedMeetingItemIDs.Add(meetingItemID);
                    }
                }
            }

            return selectedMeetingItemIDs;
        }

        private void btnConfirmItems_Click(object sender, EventArgs e)
        {
            selectedMeetingItemIDs = GetSelectedMeetingItemIDs();
            //string message = string.Join(Environment.NewLine, selectedMeetingItemIDs);
            //MessageBox.Show(message, "Selected IDs");

            MeetingDAO meetingDAO = new MeetingDAO();


            if (newMeeting != null)
            {
                int newMeetingID = meetingDAO.CaptureNewMeeting(newMeeting);

                if (newMeetingID > 0)
                {
                    foreach (int meetingItemID in selectedMeetingItemIDs)
                    {
                        MeetingItemDAO meetingItemDAO = new MeetingItemDAO();
                        MeetingItem meetingItem = meetingItemDAO.getMeetingItemById(meetingItemID);

                        meetingItem.MeetingID = newMeetingID;

                        meetingItemDAO.createNewMeetingItem(meetingItem);
                    }
                    MessageBox.Show("New Meeting Created!", "Success", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed To Add Meeting Items to Meeting", "Items NOT added", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Meeting Object Invalid/Null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMeetingItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isSelectConstructor)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvMeetingItems.Columns["SelectColumn"].Index)
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvMeetingItems.Rows[e.RowIndex].Cells["SelectColumn"];
                    checkBoxCell.Value = !(checkBoxCell.Value != null && (bool)checkBoxCell.Value);

                    dgvMeetingItems.EndEdit();
                } 
            }
        }
    }
}
