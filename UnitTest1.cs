namespace SeleniumAutomationWithCSharp
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

            TestContext.Progress.WriteLine("I am in Setup");
        }

        [Test]
        public void Test1()
        {

            TestContext.Progress.WriteLine("I am in Test1");
            //Assert.Pass();
        }

        [Test]
        public void Test2()
        {

            TestContext.Progress.WriteLine("I am in Test2");
            //Assert.Pass();
        }
        [TearDown]
        public void TearDown()
        {

            TestContext.Progress.WriteLine("I am in TearDown");
            
        }
    }
}