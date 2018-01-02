namespace Primates.Mandrill.Model
{
    public class BaseRequest
    {
        public string key
        {
            get
            {
                return Config.MandrillKey;
            }
        }
    }
}
