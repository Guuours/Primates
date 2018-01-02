using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Primates.MailChimp.Model;

namespace Primates.Test
{
    [TestClass]
    public class MailChimpTest
    {
        [TestMethod]
        public void ListTest()
        {
            var lists = MailChimp.Lists.Read();

            var list = MailChimp.Lists.Read(lists.lists[0].id);
        }

        [TestMethod]
        public void MemberTest()
        {
            var members = MailChimp.Lists.Members.Read("80c8020450");

            var member = MailChimp.Lists.Members.Read("7bfdc8d341", "joe@sportshero.mobi");
        }

        [TestMethod]
        public void AddMemberTest()
        {
            var member = MailChimp.Lists.Members.Create("7bfdc8d341", new Member {
                email_address = "joe@sportshero.mobi",
                status = "subscribed"
            });
        }

        [TestMethod]
        public void AddBatchMemberTest()
        {
            var member = MailChimp.Lists.Members.Create("7bfdc8d341", new List<Member> {
                new Member
                {
                    email_address = "joe@sportshero.mobi",
                    status = "subscribed"
                },
                new Member
                {
                    email_address = "ken@sportshero.mobi",
                    status = "subscribed"
                }
            });
        }

        [TestMethod]
        public void UpdateBatchMemberTest()
        {
            var member = MailChimp.Lists.Members.Edit("7bfdc8d341", new List<Member> {
                new Member
                {
                    email_address = "joe@sportshero.mobi",
                    status = "subscribed"
                },
                new Member
                {
                    email_address = "ken@sportshero.mobi",
                    status = "subscribed"
                }
            });
        }
        [TestMethod]
        public void DeleteMemberTest()
        {
            MailChimp.Lists.Members.Delete("7bfdc8d341", new List<string> { "joe@sportshero.mobi", "ken@sportshero.mobi" });
            //MailChimp.Lists.Members.Delete("7bfdc8d341", "joe@sportshero.mobi");
        }

    }
}
