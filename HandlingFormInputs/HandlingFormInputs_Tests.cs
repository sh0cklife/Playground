using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace HandlingFormInputs
{
    public class HandlingFormInputs_Tests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void HandlingFormInputs()
        {
            var myAccountButton = driver.FindElements(By.XPath("//span[@class=\"ui-button-text\"]"))[2];
            myAccountButton.Click();

            var continueButton = driver.FindElements(By.XPath("//span[@class=\"ui-button-text\"]"))[3];
            continueButton.Click();

            var genderMaleButton = driver.FindElement(By.XPath("//input[@type=\"radio\"][@value=\"m\"]"));
            

            var firstName = driver.FindElement(By.XPath("//input[@name=\"firstname\"]"));
            var lastName = driver.FindElement(By.XPath("//input[@name=\"lastname\"]"));
            var birthDate = driver.FindElement(By.Id("dob"));
            
            genderMaleButton.Click();
            firstName.SendKeys("Denis");
            lastName.SendKeys("Atanassov");
            birthDate.SendKeys("03/28/2025");

            var emailAddress = driver.FindElement(By.XPath("//input[@name=\"email_address\"]"));
            Random random = new Random();
            int randomNumber = random.Next(999, 9999);
            string email = "sined" + randomNumber.ToString() + "@gmail.com";

            emailAddress.SendKeys(email);

          
        }
    }
}