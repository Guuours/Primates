﻿namespace Primates.MailChimp.Model
{
    public class ListStats
    {
        public int member_count { get; set; }

        public int unsubscribe_count { get; set; }

        public int cleaned_count { get; set; }

        public int member_count_since_send { get; set; }

        public int unsubscribe_count_since_send { get; set; }

        public int cleaned_count_since_send { get; set; }

        public int campaign_count { get; set; }

        public string campaign_last_sent { get; set; }

        public int merge_field_count { get; set; }

        public decimal avg_sub_rate { get; set; }

        public decimal avg_unsub_rate { get; set; }

        public decimal target_sub_rate { get; set; }

        public decimal open_rate { get; set; }

        public decimal click_rate { get; set; }

        public string last_sub_date { get; set; }

        public string last_unsub_date { get; set; }
    }
}
