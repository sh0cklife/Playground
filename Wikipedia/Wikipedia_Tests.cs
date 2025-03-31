using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Wikipedia
{
    public class Wikipedia_Tests
    {
        WebDriver driver;
        WebDriverWait wait;


        [SetUp]

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void OpenWikipediaWebpage()
        {
            IWebElement wikiLogo = driver.FindElement(By.XPath("//h1//span"));
            Assert.That(wikiLogo, Is.Not.Null);
            
            Assert.That(wikiLogo.Text, Is.EqualTo("Wikipedia"));
            Console.WriteLine("Wikipedia logo is visible on the main page!");
        }

        [Test]
        public void SearchForAnArticle()
        {
            IWebElement searchBar = wait.Until(d => d.FindElement(By.Id("searchInput")));
            searchBar.SendKeys("Selenium (software)");
            driver.FindElement(By.XPath("//button[@type=\"submit\"]")).Click();
            IWebElement result = wait.Until(d=> driver.FindElement(By.XPath("//h1//span[@class='mw-page-title-main']")));
            Assert.That(result.Text, Is.EqualTo("Selenium (software)"));
            Assert.That(driver.Title, Is.EqualTo("Selenium (software) - Wikipedia"));
            Console.WriteLine("The user is navigated to the article Selenium");
        }
    }
}