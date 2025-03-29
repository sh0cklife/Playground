using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorkingWithWebTable
{
    public class WebTable_Tests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }

        [TearDown]
        public void Teardown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}