using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Primates.Test
{
    [TestClass]
    public class MandrillTest
    {
        [TestMethod]
        public void InfoTest()
        {
            var info = Mandrill.Users.Info();
        }

        [TestMethod]
        public void SendTest()
        {
            var ret = Mandrill.Messages.Send("joe@sportshero.mobi", "support@sportshero.mobi", "hello", "hello");
        }
    }
}
