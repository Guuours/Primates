namespace Primates.Mandrill.Model
{
    public class MessageRequest : BaseRequest
    {
        public Message message { get; set; } = new Message();

        public bool? async { get; set; }

        public string ip_pool { get; set; }

        public string send_at { get; set; }
    }
}
