﻿using ITJobs.Models;

namespace ITJobs.DTO
{
    public class NotificationDTO
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool ReadStatus { get; set; } // true la da doc, false la chua doc
    }
}