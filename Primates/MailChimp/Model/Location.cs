namespace Primates.MailChimp.Model
{
    public class Location
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int gmtoff { get; set; }
        public int dstoff { get; set; }
        public string country_code { get; set; }
        public string timezone { get; set; }
    }
}
