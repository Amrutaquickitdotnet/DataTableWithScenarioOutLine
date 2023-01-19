using LoginDatatable.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace LoginDatatable.StepDefinitions
{
    [Binding]
    public class LoginstepsStepDefinitions
    {
        IWebDriver driver;
        [Given(@"user is on home age")]
        public void GivenUserIsOnHomeAge()
        {
			Console.WriteLine("User is on Home Page");
		}

        [Given(@"navigate to Login Page")]
        public void GivenNavigateToLoginPage()
        {
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();

			driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
		}

        [When(@"user enter credentials")]
        public void WhenUserEnterCredentials(Table table)
        {
            Thread.Sleep(5000);
          var dataTable =  TableExtensions.ToDataTable(table);

            foreach (DataRow row in dataTable.Rows) {
                Thread.Sleep(3000);
				
				driver.FindElement(By.XPath("//input[@name='username']")).SendKeys(row.ItemArray[0].ToString());

				driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(row.ItemArray[1].ToString());

				driver.FindElement(By.XPath("//input[@name='username']")).Clear();
				driver.FindElement(By.XPath("//input[@name='password']")).Clear();
			}
		}

        [When(@"user is clicking on login button\.")]
        public void WhenUserIsClickingOnLoginButton_()
        {
			var LoginBtn = driver.FindElement(By.XPath("//button[@type='submit']"));
			LoginBtn.Click();

			Thread.Sleep(3000);

		}

		[Then(@"user should lands on Dashboard Page\.")]
        public void ThenUserShouldLandsOnDashboardPage_()
        {
			Console.WriteLine("On Dashboard");
		}
		[Then(@"User click on Logout button")]
		public void ThenUserClickOnLogoutButton()
		

		{
			IWebElement dropdown = driver.FindElement(By.XPath("//span[@class='oxd-userdropdown-tab']/i"));
			//Actions act = new Actions(driver);
			//act.MoveToElement(dropdown).Build().Perform();
			dropdown.Click();
			Thread.Sleep(3000);
			driver.FindElement(By.LinkText("Logout")).Click();
		}


		
		[Then(@"Successful logout message should display\.")]
		public void ThenSuccessfulLogoutMessageShouldDisplay_()
		{
			
		}

	}
}
