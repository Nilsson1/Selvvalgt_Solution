using Selvvalgt.Models;
using System.Web;

namespace Selvvalgt_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow("username")]
        public void TestMethod1(string userName) //Just setting up a dummy test for azure build purposes...
        {
            Assert.AreEqual(userName, "username");
        }
    }
}