using LoginDatatable.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace LoginDatatable.StepDefinitions
{
    [Binding]
    public class LogInextra_FeatureStepDefinitions
    {
        IWebDriver driver;
        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            
        }

        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {
			driver = new ChromeDriver();
			driver.Manage().Window.Maximize();

			driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
		}

        [When(@"User enter credentials")]
        public void WhenUserEnterCredentials(Table table)
        {
            Thread.Sleep(3000);
            var dataTable = TableExtensions.ToDataTable(table);
            foreach (DataRow row in dataTable.Rows)
            {
                driver.FindElement(By.XPath("//input[@name='username']")).SendKeys(row.ItemArray[0].ToString());
				driver.FindElement(By.XPath("//input[@name='username']")).Clear();
				driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(row.ItemArray[1].ToString());

				
				driver.FindElement(By.XPath("//input[@name='password']")).Clear();

			}
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
				driver.FindElement(By.Id("login")).Click();
			}

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            
        }

        [When(@"User LogOut from the Application")]
        public void WhenUserLogOutFromTheApplication()
        {
			true.Equals(driver.FindElement(By.XPath("//span[@class='oxd-userdropdown-tab']/i")).Displayed);
		}

        [Then(@"Successful LogOut message should display")]
        public void ThenSuccessfulLogOutMessageShouldDisplay()
        {

			
		}
    }
}
