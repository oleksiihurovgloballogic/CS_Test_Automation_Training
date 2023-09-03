using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Homework_17.Framework
{
	[TestFixture]
	public class BaseTest
	{
		protected IWebDriver drv;
		protected WebDriverWait wait;
		protected static string testUrl = Environment.GetEnvironmentVariable("ENT_QA_BASE_URL", EnvironmentVariableTarget.User);
		protected static string testUser = Environment.GetEnvironmentVariable("ENT_QA_USER", EnvironmentVariableTarget.User);
		protected static string testPass = Environment.GetEnvironmentVariable("ENT_QA_PASS", EnvironmentVariableTarget.User);
		protected static string testCompany = Environment.GetEnvironmentVariable("ENT_QA_COMPANY", EnvironmentVariableTarget.User);

		[OneTimeSetUp]
		public void Setup()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("start-maximized");
			drv = new ChromeDriver(options);
			wait = new WebDriverWait(drv, TimeSpan.FromSeconds(5));
			drv.Navigate().GoToUrl($"{testUrl}/CorpNet/Login.aspx");
			LoginToCorpNet();
		}

		protected void LoginToCorpNet()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("username")))
				.SendKeys(testUser);
			drv.FindElement(By.Id("password"))
				.SendKeys(testPass);
			drv.FindElement(By.Name("_companyText"))
				.SendKeys(testCompany);
			drv.FindElement(By.ClassName("login-submit-button"))
				.Click();
			wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.page-title")));
		}

		[OneTimeTearDown]
		public void ShutDown()
		{
			drv.Quit();
		}
	}
}
