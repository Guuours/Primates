using System.Collections.Generic;

namespace Primates.MailChimp.Model
{
    public class MemberCollection
    {
        public List<Member> members { get; set; }

        public string list_id { get; set; }

        public int total_items { get; set; }

        public List<Link> _links { get; set; }
    }
}
