namespace Primates.Mandrill.Model
{
    public class StatsDetail
    {
        public int sent { get; set; }

        public int hard_bounces { get; set; }

        public int soft_bounces { get; set; }

        public int rejects { get; set; }

        public int complaints { get; set; }

        public int unsubs { get; set; }

        public int opens { get; set; }

        public int unique_opens { get; set; }

        public int clicks { get; set; }

        public int unique_clicks { get; set; }
    }
}
