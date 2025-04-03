using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Herokuapp
{
    public class Herokuapp_Tests
    {
        WebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void ABTesting()
        {
            Assert.Pass();
        }

        [Test]
        public void AddRemoveElements()
        {
            Assert.Pass();
        }

        [Test]
        public void test()
        {
            Assert.Pass();
        }

        [Test]
        public void BasicAuthentication()
        {
            Assert.Pass();
        }

        [Test]
        public void BrokenImages()
        {
            Assert.Pass();
        }

        [Test]
        public void CHallengingDom()
        {
            Assert.Pass();
        }

        [Test]
        public void Checkboxes()
        {
            Assert.Pass();
        }

        [Test]
        public void ContentMenu()
        {
            Assert.Pass();
        }

        [Test]
        public void DigestAuthentication()
        {
            Assert.Pass();
        }

        [Test]
        public void DisappearingElements()
        {
            Assert.Pass();
        }

        [Test]
        public void DrapAndDrop()
        {
            Assert.Pass();
        }

        [Test]
        public void Dropdown()
        {
            Assert.Pass();
        }

        [Test]
        public void DynamicContent()
        {
            Assert.Pass();
        }

        [Test]
        public void DynamicControls()
        {
            Assert.Pass();
        }

        [Test]
        public void DynamicLoading()
        {
            Assert.Pass();
        }

        [Test]
        public void EntryAd()
        {
            Assert.Pass();
        }

        [Test]
        public void ExitIntent()
        {
            Assert.Pass();
        }

        [Test]
        public void FileDownload()
        {
            Assert.Pass();
        }

        [Test]
        public void FileUpload()
        {
            Assert.Pass();
        }

        [Test]
        public void FloatingMenu()
        {
            Assert.Pass();
        }

        [Test]
        public void ForgotPassword()
        {
            Assert.Pass();
        }

        [Test]
        public void FormAuthentication()
        {
            Assert.Pass();
        }

        [Test]
        public void Frames()
        {
            Assert.Pass();
        }

        [Test]
        public void Geolocation()
        {
            Assert.Pass();
        }

        [Test]
        public void HorizontalSlider()
        {
            Assert.Pass();
        }

        [Test]
        public void Hovers()
        {
            Assert.Pass();
        }

        [Test]
        public void InfiniteScroll()
        {
            Assert.Pass();
        }
    }
}