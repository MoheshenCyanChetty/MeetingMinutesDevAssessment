using MeetingMinutes.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MeetingMinutes.DAO
{
    internal class MeetingItemDAO
    {
        string connectionString =
           "datasource=localhost;port=3306;username=root;password=;database=meeting_minutes";

        // unused
        public List<MeetingItem> getAllMeetingItems()
        {
            List<MeetingItem> meetingItems = new List<MeetingItem>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `meetingitem`", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MeetingItem mI = new MeetingItem()
                    {
                        ID = reader.GetInt32(0),
                        MeetingID = reader.GetInt32(1),
                        Description = reader.GetString(2),
                        DateCreated = reader.GetDateTime(3),
                        ResponsiblePerson = reader.GetString(4),
                        ItemName = reader.GetString(5)
                    };
                }
            }
            connection.Close();

            return meetingItems;
        }

        // unused
        public List<MeetingItem> getAllMeetingItemsByMeetingID(int meetingID)
        {
            List<MeetingItem> meetingItems = new List<MeetingItem>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `MeetingItemID`, `MeetingID`, `Description`, `DateCreated`, `ResponsiblePerson`, `ItemName` FROM `meetingitem` WHERE `MeetingID` = @meetingID", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MeetingItem mI = new MeetingItem()
                    {
                        ID = reader.GetInt32(0),
                        MeetingID = reader.GetInt32(1),
                        Description = reader.GetString(2),
                        DateCreated = reader.GetDateTime(3),
                        ResponsiblePerson = reader.GetString(4),
                        ItemName = reader.GetString(5)
                    };
                    meetingItems.Add(mI);
                }
            }
            connection.Close();

            return meetingItems;
        }

        public MeetingItem getMeetingItemById(int meetingItemID)
        {
            MeetingItem meetingItem = null;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `meetingitem` WHERE `MeetingItemID`=@meetingItemID", connection);
            command.Parameters.AddWithValue("@meetingItemID", meetingItemID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    meetingItem = new MeetingItem
                    {
                        ID = reader.GetInt32("MeetingItemID"),
                        MeetingID = reader.GetInt32("MeetingID"),
                        ItemName = reader.GetString("ItemName"),
                        Description = reader.GetString("Description"),
                        ResponsiblePerson = reader.GetString("ResponsiblePerson"),
                        DateCreated = reader.GetDateTime("DateCreated"),
                        Statuses = GetMeetingItemStatuses(meetingItemID)
                    };
                }
            }
            connection.Close();

            return meetingItem;
        }

        private List<MeetingItemStatus> GetMeetingItemStatuses(int meetingItemID)
        {
            List<MeetingItemStatus> statuses = new List<MeetingItemStatus>();

            MySqlConnection connection = new MySqlConnection(connectionString);
           
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM MeetingItemStatus WHERE MeetingItemID = @MeetingItemID", connection);
            command.Parameters.AddWithValue("@MeetingItemID", meetingItemID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MeetingItemStatus status = new MeetingItemStatus
                    {
                        ID = reader.GetInt32("StatusID"),
                        MeetingItemID = reader.GetInt32("MeetingItemID"),
                        MeetingID = reader.GetInt32("MeetingID"),
                        Status = reader.GetString("Status"),
                        ActionRequired = reader.GetString("ActionRequired"),
                        DateUpdated = reader.GetDateTime("DateUpdated")
                    };
                    statuses.Add(status);
                }
            }
            

            connection.Close();

            return statuses;
        }

        public List<MeetingItem> getAllMeetingItemsWithStatusUsingMeetingID(int meetingID)
        {
            List<MeetingItem> meetingItems = new List<MeetingItem>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT mi.MeetingItemID, mis.StatusID, mi.ItemName, mi.Description, mis.Status, mis.ActionRequired, mi.ResponsiblePerson, mi.DateCreated, mis.DateUpdated FROM MeetingItem mi JOIN MeetingItemStatus mis ON mi.MeetingItemID = mis.MeetingItemID AND mi.MeetingID = mis.MeetingID WHERE mi.MeetingID = @meetingID", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    MeetingItem mI = new MeetingItem()
                    {
                        ID = reader.GetInt32("MeetingItemID"),
                        MeetingID = meetingID,
                        Description = reader.GetString("Description"),
                        DateCreated = reader.GetDateTime("DateCreated"),
                        ResponsiblePerson = reader.GetString("ResponsiblePerson"),
                        ItemName = reader.GetString("ItemName")
                    };

                    MeetingItemStatus status = new MeetingItemStatus()
                    {
                        ID = reader.GetInt32("StatusID"),
                        MeetingItemID = reader.GetInt32("MeetingItemID"),
                        MeetingID = meetingID,
                        Status = reader.GetString("Status"),
                        ActionRequired = reader.GetString("ActionRequired"),
                        DateUpdated = reader.GetDateTime("DateUpdated")
                    };

                    mI.Statuses.Add(status);
                    meetingItems.Add(mI);
                }
                
            }

            return meetingItems;
        }

        public int getStatusIDByMeetingItemID(int meetingItemID)
        {
            int statusID = -1;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT mis.StatusID FROM MeetingItem mi JOIN MeetingItemStatus mis ON mi.MeetingItemID = mis.MeetingItemID WHERE mi.MeetingItemID = @meetingItemID", connection);
            command.Parameters.AddWithValue("@meetingItemID", meetingItemID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    statusID = reader.GetInt32("StatusID");
                }
            }
            connection.Close();

            return statusID;
        }

        public MeetingItemStatus getMeetingItemStatusByStatusID(int statusID)
        {
            MeetingItemStatus meetingItemStatus = null;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `meetingitemstatus` WHERE `StatusID`=@statusID", connection);
            command.Parameters.AddWithValue("@statusID", statusID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    meetingItemStatus = new MeetingItemStatus()
                    {
                        ID = reader.GetInt32("StatusID"),
                        MeetingItemID = reader.GetInt32("MeetingItemID"),
                        MeetingID = reader.GetInt32("MeetingID"),
                        Status = reader.GetString("Status"),
                        ActionRequired = reader.GetString("ActionRequired"),
                        DateUpdated = reader.GetDateTime("DateUpdated")
                    };
                }
            }
            connection.Close();

            return meetingItemStatus;
        }


        public int updateMeetingItemStatus(MeetingItemStatus meetingItemStatus, int updateMeetingItemStatusID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            DateTime now = DateTime.Now;

            MySqlCommand command = new MySqlCommand("UPDATE `meetingitemstatus` SET `Status`=@status, `ActionRequired`=@actionRequired, `DateUpdated`=@dateUpdated WHERE `MeetingItemID`=@meetingItemID AND `StatusID`=@statusID", connection);
            command.Parameters.AddWithValue("@statusID", updateMeetingItemStatusID);
            command.Parameters.AddWithValue("@meetingItemID", meetingItemStatus.MeetingItemID);
            command.Parameters.AddWithValue("@status", meetingItemStatus.Status);
            command.Parameters.AddWithValue("@actionRequired", meetingItemStatus.ActionRequired);
            command.Parameters.AddWithValue("@dateUpdated", now);

            int updatedRows = command.ExecuteNonQuery();

            return updatedRows;
        }

        public int createNewMeetingItem(MeetingItem meetingItem)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // item
            MySqlCommand command = new MySqlCommand("INSERT INTO `meetingitem`(`MeetingID`, `Description`, `DateCreated`, `ResponsiblePerson`, `ItemName`) VALUES (@meetingID, @description, @dateCreated, @responsiblePerson, @itemName)", connection);
            command.Parameters.AddWithValue("@meetingID", meetingItem.MeetingID);
            command.Parameters.AddWithValue("@description", meetingItem.Description);
            command.Parameters.AddWithValue("@dateCreated", meetingItem.DateCreated);
            command.Parameters.AddWithValue("@responsiblePerson", meetingItem.ResponsiblePerson);
            command.Parameters.AddWithValue("@itemName", meetingItem.ItemName);
            command.ExecuteNonQuery();


            MySqlCommand idCommand = new MySqlCommand("SELECT LAST_INSERT_ID();", connection);
            int newMeetingItemID = Convert.ToInt32(idCommand.ExecuteScalar());

            // status
            foreach (var status in meetingItem.Statuses)
            {
                MySqlCommand statusCommand = new MySqlCommand(
                    "INSERT INTO `meetingitemstatus` (`MeetingItemID`, `MeetingID`, `Status`, `ActionRequired`, `DateUpdated`) " +
                    "VALUES (@meetingItemID, @meetingID, @status, @actionRequired, @dateUpdated)", connection);
                statusCommand.Parameters.AddWithValue("@meetingItemID", newMeetingItemID);
                statusCommand.Parameters.AddWithValue("@meetingID", meetingItem.MeetingID);
                statusCommand.Parameters.AddWithValue("@status", status.Status);
                statusCommand.Parameters.AddWithValue("@actionRequired", status.ActionRequired);
                statusCommand.Parameters.AddWithValue("@dateUpdated", status.DateUpdated);

                statusCommand.ExecuteNonQuery();
            }


            connection.Close();
            return newMeetingItemID;
        }
    }
}
