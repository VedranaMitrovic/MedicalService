using MedicalService.Driver;
using MedicalService.Page;

namespace MedicalService.Tests
{
    public class LoginTest
    {
        LoginPage loginPage;
        string Message = "Login failed! Please ensure the username and password are valid.";

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();

        }

        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_EnterInvalidUsername_ShouldNotBeLoggedIn()
        {
            loginPage.AppMed.Click();
            loginPage.Login("Vedrana", "ThisIsNotAPassword");
            Assert.That(Message, Is.EqualTo(loginPage.UserNotLoggedIn.Text));
        }

        [Test]
        public void TC02_EnterInvalidPassword_ShouldNotBeLoggedIn()
        {
            loginPage.AppMed.Click();
            loginPage.Login("John Doe", "ThisIsAPassword");
            Assert.That(Message, Is.EqualTo(loginPage.UserNotLoggedIn.Text));
        }

        [Test]
        public void TC03_EnterNoData_ShouldNotBeLoggedIn()
        {
            loginPage.AppMed.Click();
            loginPage.Login("", "");
            Assert.That(Message, Is.EqualTo(loginPage.UserNotLoggedIn.Text));

        }
    }
}
