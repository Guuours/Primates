namespace Primates.Mandrill.Model
{
    public class Stats
    {
        public StatsDetail today { get; set; }

        public StatsDetail last_7_days { get; set; }

        public StatsDetail last_30_days { get; set; }

        public StatsDetail last_60_days { get; set; }

        public StatsDetail last_90_days { get; set; }

        public StatsDetail all_time { get; set; }
    }
}
