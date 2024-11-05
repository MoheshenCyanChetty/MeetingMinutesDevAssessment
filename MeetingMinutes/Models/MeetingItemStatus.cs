using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Models
{
    public class MeetingItemStatus
    {
        public int ID { get; set; }
        public int MeetingItemID { get; set; }
        public int MeetingID { get; set; }
        public string Status { get; set; }
        public string ActionRequired { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
