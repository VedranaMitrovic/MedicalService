using MedicalService.Driver;
using MedicalService.Page;

namespace MedicalService
{
    public class Tests
    {
        LoginPage loginPage;
        MedicalPage medicalPage;

        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            medicalPage = new MedicalPage();
        }

        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }

        [Test]
        public void TC01_MakeAppointment_ShouldAppointmentBeCompleted()
        {
            loginPage.AppMed.Click();
            loginPage.Login("John Doe", "ThisIsNotAPassword");
            medicalPage.SelectFacility("Hongkong CURA Healthcare Center");
            medicalPage.CheckBox.Click();
            medicalPage.MedicAid.Click();
            medicalPage.VisitDate.SendKeys("02/12/2022");
            medicalPage.Comment.SendKeys("Appointment successfully made.");
            medicalPage.BookApp.Submit();
            Assert.That("Appointment Confirmation", Is.EqualTo(medicalPage.Confirm.Text));
            
        }
    }
}