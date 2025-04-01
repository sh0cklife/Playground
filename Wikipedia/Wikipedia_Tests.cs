using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Linq;

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

        [Test]
        public void ValidateLanguageSelection()
        {
            IWebElement englishLanguage = driver.FindElement(By.XPath("//nav//div[@dir=\"ltr\" and @lang=\"en\"]"));
            englishLanguage.Click();

            Assert.That(driver.Url, Is.EqualTo("https://en.wikipedia.org/wiki/Main_Page"));
            Console.WriteLine("URL changed to english version.");
        }

        [Test]
        public void TodaysFeaturedArticle()
        {
            IWebElement englishLanguage = driver.FindElement(By.XPath("//nav//div[@dir=\"ltr\" and @lang=\"en\"]"));
            englishLanguage.Click();

            IWebElement todaysArticle = wait.Until(d => driver.FindElement(By.Id("mp-tfa-h2")));
            Assert.That(todaysArticle.Text, Is.EqualTo("From today's featured article"));

            driver.FindElement(By.XPath("//div[@id='mp-tfa']//a[@title='Apollo 15 postal covers incident']")).Click();
            Assert.That(driver.Url, Is.EqualTo("https://en.wikipedia.org/wiki/Apollo_15_postal_covers_incident"));
            Assert.That(driver.Title, Is.EqualTo("Apollo 15 postal covers incident - Wikipedia"));
            Console.WriteLine("The user is taken to an article from \"Today's featured article.");
        }

        [Test]
        public void SearchSuggestionDropdown()
        {
            IWebElement searchBar = wait.Until(d => d.FindElement(By.Id("searchInput")));
            searchBar.SendKeys("Selen");

            var suggestions = wait.Until(d => driver.FindElements(By.XPath("//div[@class='suggestions-dropdown']//a")));
            Assert.That(suggestions.Count, Is.GreaterThan(0), "No search suggestions found!");

            var seleniumSuggestion = suggestions.FirstOrDefault(s => s.GetAttribute("href") != null && s.GetAttribute("href").Contains("Selenium"));
            Assert.That(seleniumSuggestion, Is.Not.Null, "No search suggestion with 'Selenium' found!");

            Assert.That(seleniumSuggestion.Displayed, Is.True, "The search suggestion containing 'Selenium' is NOT visible!");
            Console.WriteLine($"Found suggestion: {seleniumSuggestion.Text} = {seleniumSuggestion.GetAttribute("href")}");

        }

        [Test]
        public void VerifyLoginPage()
        {
            IWebElement englishLanguage = driver.FindElement(By.XPath("//nav//div[@dir=\"ltr\" and @lang=\"en\"]"));
            englishLanguage.Click();

            IWebElement loginButton = driver.FindElement(By.LinkText("Log in"));
            loginButton.Click();

            IWebElement loginPage = driver.FindElement(By.Id("firstHeading"));
            Assert.That(loginPage.Text, Is.EqualTo("Log in"));

            IWebElement usernameField = driver.FindElement(By.Id("wpName1"));
            IWebElement passwordField = driver.FindElement(By.Id("wpPassword1"));

            Assert.That(usernameField.Displayed, Is.True);
            Assert.That(passwordField.Displayed, Is.True);

            Console.WriteLine("The user is taken to the Wikipedia login page.");
        }

        [Test]
        public void VerifyBrokenLinks()
        {
            IWebElement englishLanguage = driver.FindElement(By.XPath("//nav//div[@dir=\"ltr\" and @lang=\"en\"]"));
            englishLanguage.Click();


        }
    }
}