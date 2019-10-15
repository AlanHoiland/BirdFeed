using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [Ignore]
        [TestMethod]
        public void TestMethod1()
        {
            Assert.Fail("This is a test");
        }
    }
}
