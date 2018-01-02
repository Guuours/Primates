using System.Collections.Generic;

namespace Primates.MailChimp.Model
{
    public class ListCollection
    {
        public List<List> lists { get; set; }

        public int total_items { get; set; }

        public List<Link> _links { get; set; }
    }
}
