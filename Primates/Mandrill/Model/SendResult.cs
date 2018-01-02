namespace Primates.Mandrill.Model
{
    public class SendResult
    {
        public string email { get; set; }

        public string status { get; set; }

        public string reject_reason { get; set; }

        public string _id { get; set; }
    }
}
