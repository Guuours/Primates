using Newtonsoft.Json;
using Primates.MailChimp.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Primates.MailChimp
{
    public class Lists
    {
        private static MD5CryptoServiceProvider MD5Provider
        {
            get
            {
                return new MD5CryptoServiceProvider();
            }
        }

        private static string MD5(string input)
        {
            byte[] bytes = MD5Provider.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public static ListCollection Read()
        {
            var ret = new ListCollection();

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", Config.Authorization);

                try
                {
                    var resp = client.DownloadString($"{Config.APIRoot}lists");
                    ret = JsonConvert.DeserializeObject<ListCollection>(resp);
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var resp = reader.ReadToEnd();
                            var error = JsonConvert.DeserializeObject<Error>(resp);
                            throw new Exception($"{error.title}: {error.detail}", ex);
                        }
                    }
                }
            }

            return ret;
        }

        public static List Read(string id)
        {
            var ret = new List();

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", Config.Authorization);

                try
                {
                    var resp = client.DownloadString($"{Config.APIRoot}lists/{id}");
                    ret = JsonConvert.DeserializeObject<List>(resp);
                }
                catch (WebException ex)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var resp = reader.ReadToEnd();
                            var error = JsonConvert.DeserializeObject<Error>(resp);
                            throw new Exception($"{error.title}: {error.detail}", ex);
                        }
                    }
                }
            }

            return ret;
        }

        public class Members
        {
            public static MemberCollection Read(string list_id)
            {
                var ret = new MemberCollection();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var resp = client.DownloadString($"{Config.APIRoot}lists/{list_id}/members");
                        ret = JsonConvert.DeserializeObject<MemberCollection>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }

            public static Member Read(string list_id, string email)
            {
                var ret = new Member();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var resp = client.DownloadString($"{Config.APIRoot}lists/{list_id}/members/{MD5(email.ToLower())}");
                        ret = JsonConvert.DeserializeObject<Member>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }

            public static Member Create(string list_id, Member member)
            {
                var ret = new Member();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var resp = client.UploadString($"{Config.APIRoot}lists/{list_id}/members", "POST", JsonConvert.SerializeObject(member, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        ret = JsonConvert.DeserializeObject<Member>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }

            public static BatchResult Create(string list_id, List<Member> members)
            {
                var ret = new BatchResult();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var operations = members.Select(member => new
                        {
                            method = "POST",
                            path = $"lists/{list_id}/members",
                            body = JsonConvert.SerializeObject(member, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                        }).ToList();

                        var resp = client.UploadString($"{Config.APIRoot}batches", "POST", JsonConvert.SerializeObject(new { operations }));
                        ret = JsonConvert.DeserializeObject<BatchResult>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }

            public static Member Edit(string list_id, Member member)
            {
                var ret = new Member();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var resp = client.UploadString($"{Config.APIRoot}lists/{list_id}/members/{MD5(member.email_address.ToLower())}", "PATCH", JsonConvert.SerializeObject(member, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        ret = JsonConvert.DeserializeObject<Member>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }

            public static BatchResult Edit(string list_id, List<Member> members)
            {
                var ret = new BatchResult();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var operations = members.Select(member => new
                        {
                            method = "PATCH",
                            path = $"lists/{list_id}/members/{MD5(member.email_address.ToLower())}",
                            body = JsonConvert.SerializeObject(member, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })
                        }).ToList();

                        var resp = client.UploadString($"{Config.APIRoot}batches", "POST", JsonConvert.SerializeObject(new { operations }));
                        ret = JsonConvert.DeserializeObject<BatchResult>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }

            public static void Delete(string list_id, string email)
            {
                using (WebClient client = new WebClient())
                {
                    //client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var resp = client.UploadValues($"{Config.APIRoot}lists/{list_id}/members/{MD5(email.ToLower())}", "DELETE", new NameValueCollection());
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }
            }

            public static BatchResult Delete(string list_id, List<string> emails)
            {
                var ret = new BatchResult();

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", Config.Authorization);

                    try
                    {
                        var operations = emails.Select(email => new
                        {
                            method = "DELETE",
                            path = $"lists/{list_id}/members/{MD5(email.ToLower())}"
                        }).ToList();

                        var resp = client.UploadString($"{Config.APIRoot}batches", "POST", JsonConvert.SerializeObject(new { operations }));
                        ret = JsonConvert.DeserializeObject<BatchResult>(resp);
                    }
                    catch (WebException ex)
                    {
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var resp = reader.ReadToEnd();
                                var error = JsonConvert.DeserializeObject<Error>(resp);
                                throw new Exception($"{error.title}: {error.detail}", ex);
                            }
                        }
                    }
                }

                return ret;
            }
        }
    }
}
