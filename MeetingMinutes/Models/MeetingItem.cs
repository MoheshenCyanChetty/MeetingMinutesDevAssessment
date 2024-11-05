using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes.Models
{
    public class MeetingItem
    {
        public int ID { get; set; }
        public int MeetingID { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string ResponsiblePerson { get; set; }
        public string ItemName { get; set; }

        public List<MeetingItemStatus> Statuses { get; set; } = new List<MeetingItemStatus>();
    }
}
