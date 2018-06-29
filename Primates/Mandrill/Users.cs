using Newtonsoft.Json;
using Primates.Mandrill.Model;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Primates.Mandrill
{
    public class Users
    {
        public static Info Info()
        {
            var ret = new Info();

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/json");

                try
                {
                    var resp = client.UploadString("https://mandrillapp.com/api/1.0/users/info.json", JsonConvert.SerializeObject(new BaseRequest()));
                    ret = JsonConvert.DeserializeObject<Info>(resp);
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var resp = reader.ReadToEnd();
                            var error = JsonConvert.DeserializeObject<Error>(resp);
                            throw new Exception($"{error.name}: {error.message}", ex);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
