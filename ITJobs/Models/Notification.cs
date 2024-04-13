namespace ITJobs.Models
{
    public class Notification
    {
        public long Id { get; set; }
        public User Users { get; set; }
        public Company Companies { get; set; }
        public Application Applications { get; set; }
        public string? Content { get; set; }
        //public long? Applied { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool ReadStatus { get; set; } // true la da doc, false la chua doc
        public Status_Noti Status { get; set; } = Status_Noti.Accept;
    }

    public enum Status_Noti
    {
        Accept,
        Reject
    }

    public class Noti_Create
    {
        //public long? Applied { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool ReadStatus { get; set; } // true la da doc, false la chua doc
        public Status_Noti Status { get; set; } = Status_Noti.Accept;
    }

   
}
