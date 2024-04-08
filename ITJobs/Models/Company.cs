﻿namespace ITJobs.Models
{
    public class Company
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public long size { get; set; }
        public User User { get; set; }
    }
}