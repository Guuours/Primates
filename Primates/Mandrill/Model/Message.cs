using System.Collections.Generic;

namespace Primates.Mandrill.Model
{
    public class Message
    {
        public string html { get; set; }

        public string text { get; set; }

        public string subject { get; set; }

        public string from_email { get; set; }

        public string from_name { get; set; }

        public List<To> to { get; set; } = new List<To>();

        public object headers { get; set; }

        public bool? important { get; set; }

        public bool? track_opens { get; set; }

        public bool? track_clicks { get; set; }

        public bool? auto_text { get; set; }

        public bool? auto_html { get; set; }

        public bool? inline_css { get; set; }

        public bool? url_strip_qs { get; set; }

        public bool? preserve_recipients { get; set; }

        public bool? view_content_link { get; set; }

        public string bcc_address { get; set; }

        public string tracking_domain { get; set; }

        public string signing_domain { get; set; }

        public string return_path_domain { get; set; }

        public bool? merge { get; set; }

        public string merge_language { get; set; }

        public List<Var> global_merge_vars { get; set; } = new List<Var>();

        public List<MergeVar> merge_vars { get; set; } = new List<MergeVar>();

        public List<string> tags { get; set; }

        public string subaccount { get; set; }

        public List<string> google_analytics_domains { get; set; }

        public string google_analytics_campaign { get; set; }

        public object metadata { get; set; }

        public List<RcptMetaData> recipient_metadata { get; set; } = new List<RcptMetaData>();

        public List<Attachment> attachments { get; set; }

        public List<Attachment> images { get; set; }
    }
}
