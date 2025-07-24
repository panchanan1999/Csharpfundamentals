namespace SeleniumAutomation
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("this is the setup method ");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("this is the test1 method ");
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("this is the test2 method ");
        }
        [TearDown]
        public void TeardownMethod()
        {
            TestContext.Progress.WriteLine("this is the teardown method ");
        }
    }
}