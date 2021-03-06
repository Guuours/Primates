﻿namespace Primates.Mandrill.Model
{
    public class Info
    {
        public string username { get; set; }

        public string created_at { get; set; }

        public string public_id { get; set; }

        public int reputation { get; set; }

        public int hourly_quota { get; set; }

        public int backlog { get; set; }

        public Stats stats { get; set; }
    }
}
