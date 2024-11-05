using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Models
{
    public class Meeting
    {
        public int ID { get; set; }
        public int MeetingTypeID { get; set; }
        public int MeetingNumber { get; set; }
        public DateOnly MeetingDate { get; set; }
        public TimeOnly MeetingTime { get; set; }

        public List<MeetingItem> Meetings { get; set; }
    }
}
