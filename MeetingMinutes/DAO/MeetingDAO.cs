using MeetingMinutes.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.DAO
{
    internal class MeetingDAO
    {
        string connectionString =
            "datasource=localhost;port=3306;username=root;password=;database=meeting_minutes";

        public List<string> getMeetingTypeNames()
        {
            List<string> meetingTypeNames = new List<string>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `TypeName` FROM `meetingtype`", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string typeName = reader.GetString(0);
                    meetingTypeNames.Add(typeName);
                }
            }
            connection.Close();

            return meetingTypeNames;
        }

        public int CaptureNewMeeting(Meeting meeting)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("INSERT INTO `meeting`(`MeetingTypeID`, `MeetingNumber`, `MeetingDate`, `MeetingTime`) VALUES (@meetingTypeID, @Number, @Date, @Time)", connection);
            command.Parameters.AddWithValue("@meetingTypeID", meeting.MeetingTypeID);
            command.Parameters.AddWithValue("@Number", meeting.MeetingNumber);
            command.Parameters.AddWithValue("@Date", meeting.MeetingDate.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@Time", meeting.MeetingTime);

            command.ExecuteNonQuery();

            MySqlCommand idCommand = new MySqlCommand("SELECT LAST_INSERT_ID();", connection);
            int newMeetingID = Convert.ToInt32(idCommand.ExecuteScalar());

            connection.Close();

            return newMeetingID;
        }

        public int getLatestMeetingID()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand Command = new MySqlCommand("SELECT LAST_INSERT_ID() FROM `meeting`", connection);
            int newMeetingID = Convert.ToInt32(Command.ExecuteScalar());

            connection.Close();
            return newMeetingID;
        }

        public List<Meeting> getAllMeetings()
        {
            List<Meeting> meetings = new List<Meeting>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `meeting`", connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Meeting m = new Meeting()
                    {
                        ID = reader.GetInt32(0),
                        MeetingTypeID = reader.GetInt32(1),
                        MeetingNumber = reader.GetInt32(2),
                        MeetingDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
                        MeetingTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(4))
                    };
                    meetings.Add(m);
                }
            }

            return meetings;
        }

        public int DeleteMeeting(int meetingID)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("DELETE FROM meetingitemstatus WHERE MeetingItemID IN (SELECT MeetingItemID FROM MeetingItem WHERE MeetingID = @meetingID); DELETE FROM meetingitem WHERE MeetingID = @meetingID; DELETE FROM meeting WHERE MeetingID = @meetingID;", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);

            int result = command.ExecuteNonQuery();

            return result;
        }

        public int GetMeetingIDByMeetingNumber(int meetingNumber, int meetingTypeID)
        {
            int meetingID = -1;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `MeetingID` FROM `meeting` WHERE `MeetingNumber`=@meetingNumber AND `MeetingTypeID`=@meetingTypeID", connection);
            command.Parameters.AddWithValue("@meetingNumber", meetingNumber);
            command.Parameters.AddWithValue("@meetingTypeID", meetingTypeID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    meetingID = reader.GetInt32("MeetingID");
                }
            }
            connection.Close();

            return meetingID;
        }

        public int GetMeetingNumberByMeetingID(int meetingID)
        {
            int meetingNumber = 0;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `MeetingNumber` FROM `meeting` WHERE `MeetingID` = @meetingID", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    meetingNumber = reader.GetInt32("MeetingNumber");
                }
            }
            connection.Close();

            return meetingNumber;
        }

        public DateOnly GetMeetingDateByMeetingID(int meetingID)
        {
            DateOnly meetingDate;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `MeetingDate` FROM `meeting` WHERE `MeetingID` = @meetingID", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    meetingDate = DateOnly.FromDateTime(reader.GetDateTime("MeetingDate"));
                }
            }
            connection.Close();

            return meetingDate;
        }

        public int GetMeetingTypeIDByMeetingTypeName(string TypeName)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT `MeetingTypeID` FROM `meetingtype` WHERE `TypeName` = @typeName", connection);
            command.Parameters.AddWithValue("@typeName", TypeName);

            object result = command.ExecuteScalar();
            connection.Close();

            return Convert.ToInt32(result);
        }

        public string GetMeetingTypeNameByMeetingID(int meetingID)
        {
            string typeName = null;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT mt.TypeName FROM Meeting m JOIN MeetingType mt ON m.MeetingTypeID = mt.MeetingTypeID WHERE m.MeetingID = @meetingID", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);
                    
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) 
                {
                    typeName = reader.GetString("TypeName");
                }
            }
            connection.Close(); 

            return typeName;
        }

        public string GetMeetingTypeCodeByMeetingID(int meetingID)
        {
            string typeCode = null;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = new MySqlCommand("SELECT mt.TypeCode FROM Meeting m JOIN MeetingType mt ON m.MeetingTypeID = mt.MeetingTypeID WHERE m.MeetingID = @meetingID", connection);
            command.Parameters.AddWithValue("@meetingID", meetingID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    typeCode = reader.GetString("TypeCode");
                }
            }
            connection.Close();

            return typeCode;
        }


        public int GetNextMeetingNumber(int meetingTypeID)
        {
            int meetingNumber = 1;

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT MAX(`MeetingNumber`) FROM `meeting` WHERE MeetingTypeID = @MeetingTypeID", connection);
            command.Parameters.AddWithValue("@MeetingTypeID", meetingTypeID);

            object result = command.ExecuteScalar();
            if (result != DBNull.Value)
            {
                meetingNumber = Convert.ToInt32(result) + 1;
            }

            connection.Close();

            return meetingNumber;
        }

        internal List<Meeting> getAllMeetingsByMeetingTypeID(int meetingTypeID)
        {
            List<Meeting> sortedMeetings = new List<Meeting>();

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `meeting` WHERE `MeetingTypeID` = @meetingTypeID", connection);
            command.Parameters.AddWithValue("@meetingTypeID", meetingTypeID);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Meeting m = new Meeting()
                    {
                        ID = reader.GetInt32(0),
                        MeetingTypeID = reader.GetInt32(1),
                        MeetingNumber = reader.GetInt32(2),
                        MeetingDate = DateOnly.FromDateTime(reader.GetDateTime(3)),
                        MeetingTime = TimeOnly.FromTimeSpan(reader.GetTimeSpan(4))
                    };
                    sortedMeetings.Add(m);
                }
            }

            return sortedMeetings;
        }
    }
}
