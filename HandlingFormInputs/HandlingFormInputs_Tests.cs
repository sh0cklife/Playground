using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


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
            genderMaleButton.Click();

            var firstName = driver.FindElement(By.XPath("//input[@name=\"firstname\"]"));
            firstName.SendKeys("Denis");
            var lastName = driver.FindElement(By.XPath("//input[@name=\"lastname\"]"));
            lastName.SendKeys("Atanassov");
            var birthDate = driver.FindElement(By.Id("dob"));
            birthDate.SendKeys("03/28/2025");

            var emailAddress = driver.FindElement(By.XPath("//input[@name=\"email_address\"]"));
            Random random = new Random();
            int randomNumber = random.Next(999, 9999);
            string email = "sined" + randomNumber.ToString() + "@gmail.com";
            emailAddress.SendKeys(email);

            var companyName = driver.FindElement(By.XPath("//input[@name=\"company\"]"));
            companyName.SendKeys("Company Name");

            var streetAddress = driver.FindElement(By.XPath("//input[@name=\"street_address\"]"));
            streetAddress.SendKeys("Company Address");

            var postalCode = driver.FindElement(By.XPath("//input[@name=\"postcode\"]"));
            postalCode.SendKeys("1000");

            var city = driver.FindElement(By.XPath("//input[@name=\"city\"]"));
            city.SendKeys("City Name");

            var state = driver.FindElement(By.XPath("//input[@name=\"state\"]"));
            state.SendKeys("State Name");

            // SELECT FROM COUNTRY DROPDOWN - SELENIUM SUPPORT
            new SelectElement(
                driver.FindElement
                (By.Name("country")))
                .SelectByText("Bulgaria");

            var phoneNumber = driver.FindElement(By.XPath("//input[@name=\"telephone\"]"));
            string randomPhoneNumber = "0888" + randomNumber.ToString() + randomNumber.ToString();
            phoneNumber.SendKeys(randomPhoneNumber);

            var faxNumber = driver.FindElement(By.XPath("//input[@name=\"fax\"]"));
            string randomFaxNumber = "000" + randomNumber.ToString();
            faxNumber.SendKeys(randomFaxNumber);

            var newsletter = driver.FindElement(By.XPath("//input[@name=\"newsletter\"]"));
            newsletter.Click();

            var password = driver.FindElement(By.XPath("//input[@name=\"password\"]"));
            password.SendKeys("123456789");

            var passwordConfirmation = driver.FindElement(By.XPath("//input[@name=\"confirmation\"]"));
            passwordConfirmation.SendKeys("123456789");

            var continueRegistrationButton = driver.FindElements(By.XPath("//span[@class=\"ui-button-text\"]"))[3];
            continueRegistrationButton.Click();

            //ASSERTION
            var successMessage = driver.FindElement(By.XPath("//div[@id=\"bodyContent\"]//h1"));
            var result = successMessage.Text;
            Assert.That(result, Is.EqualTo("Your Account Has Been Created!"));
            

            var logOff = driver.FindElements(By.XPath("//span[@class=\"ui-button-text\"]"))[3];
            logOff.Click();

            var logOffMessage = driver.FindElement(By.XPath("//div[@id=\"bodyContent\"]//h1"));
            var logResult = logOffMessage.Text;
            Assert.That(logResult, Is.EqualTo("Log Off"));

            driver.FindElement(By.LinkText("Continue")).Click();

            Console.WriteLine("User Created Successfully");
        }
    }
}