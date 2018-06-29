using Newtonsoft.Json;
using Primates.Mandrill.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Primates.Mandrill
{
    public class Messages
    {
        public static List<SendResult> Send(MessageRequest request)
        {
            var ret = new List<SendResult>();

            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Content-Type", "application/json");

                try
                {
                    var resp = client.UploadString("https://mandrillapp.com/api/1.0/messages/send.json", JsonConvert.SerializeObject(request));
                    ret = JsonConvert.DeserializeObject<List<SendResult>>(resp);
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

        public static SendResult Send(string to, string from, string subject, string html)
        {
            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = new List<To> { new To { email = to, type = "to" } },
                    from_email = from,
                    subject = subject,
                    html = html
                }
            };

            return Send(req)[0];
        }

        public static SendResult Send(string to, string toName, string from, string fromName, string subject, string html)
        {
            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = new List<To> { new To { email = to, name = toName, type = "to" } },
                    from_email = from,
                    from_name = fromName,
                    subject = subject,
                    html = html
                }
            };

            return Send(req)[0];
        }

        public static List<SendResult> Send(List<string> to, string from, string subject, string html, bool preserve = true)
        {
            var rcpt = to.Select(t => new To { email = t, type = "to" }).ToList();

            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = rcpt,
                    from_email = from,
                    subject = subject,
                    html = html,
                    preserve_recipients = preserve
                }
            };

            return Send(req);
        }

        public static List<SendResult> Send(List<string> to, string from, string fromName, string subject, string html, bool preserve = true)
        {
            var rcpt = to.Select(t => new To { email = t, type = "to" }).ToList();

            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = rcpt,
                    from_email = from,
                    from_name = fromName,
                    subject = subject,
                    html = html,
                    preserve_recipients = preserve
                }
            };

            return Send(req);
        }

        public static List<SendResult> Send(List<string> to, List<string> cc, string from, string subject, string html, bool preserve = true)
        {
            var rcpt = to.Select(t => new To { email = t, type = "to" }).ToList();
            rcpt.AddRange(cc.Select(t => new To { email = t, type = "cc" }));

            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = rcpt,
                    from_email = from,
                    subject = subject,
                    html = html,
                    preserve_recipients = preserve
                }
            };

            return Send(req);
        }

        public static List<SendResult> Send(List<string> to, List<string> cc, string from, string fromName, string subject, string html, bool preserve = true)
        {
            var rcpt = to.Select(t => new To { email = t, type = "to" }).ToList();
            rcpt.AddRange(cc.Select(t => new To { email = t, type = "cc" }));

            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = rcpt,
                    from_email = from,
                    from_name = fromName,
                    subject = subject,
                    html = html,
                    preserve_recipients = preserve
                }
            };

            return Send(req);
        }

        public static List<SendResult> Send(List<string> to, List<string> cc, List<string> bcc, string from, string subject, string html, bool preserve = true)
        {
            var rcpt = to.Select(t => new To { email = t, type = "to" }).ToList();
            rcpt.AddRange(cc.Select(t => new To { email = t, type = "cc" }));
            rcpt.AddRange(bcc.Select(t => new To { email = t, type = "bcc" }));

            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = rcpt,
                    from_email = from,
                    subject = subject,
                    html = html,
                    preserve_recipients = preserve
                }
            };

            return Send(req);
        }

        public static List<SendResult> Send(List<string> to, List<string> cc, List<string> bcc, string from, string fromName, string subject, string html, bool preserve = true)
        {
            var rcpt = to.Select(t => new To { email = t, type = "to" }).ToList();
            rcpt.AddRange(cc.Select(t => new To { email = t, type = "cc" }));
            rcpt.AddRange(bcc.Select(t => new To { email = t, type = "bcc" }));

            MessageRequest req = new MessageRequest
            {
                message = new Message
                {
                    to = rcpt,
                    from_email = from,
                    from_name = fromName,
                    subject = subject,
                    html = html,
                    preserve_recipients = preserve
                }
            };

            return Send(req);
        }
    }
}
