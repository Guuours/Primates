using System;
using System.Collections.Generic;

namespace Primates.MailChimp.Model
{
    public class BatchResult
    {
        public string id { get; set; }

        public string status { get; set; }

        public int total_operations { get; set; }

        public int finished_operations { get; set; }

        public int errored_operations { get; set; }

        public DateTime submitted_at { get; set; }

        public string completed_at { get; set; }

        public string response_body_url { get; set; }

        public List<Link> _links { get; set; }
    }
}
