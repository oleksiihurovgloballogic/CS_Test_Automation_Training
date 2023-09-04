using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SANDBOX_Tests
{
	public class Tests
	{
		protected IWebDriver drv;
		protected WebDriverWait wait;
		protected static string _BaseUrl = Environment.GetEnvironmentVariable("ENT_QA_BASE_URL", EnvironmentVariableTarget.User);
		protected static string _User = Environment.GetEnvironmentVariable("ENT_QA_USER", EnvironmentVariableTarget.User);
		protected static string _Password = Environment.GetEnvironmentVariable("ENT_QA_PASS", EnvironmentVariableTarget.User);
		protected static string _Company = Environment.GetEnvironmentVariable("ENT_QA_COMPANY", EnvironmentVariableTarget.User);

		[OneTimeSetUp]
		public void Setup()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("start-maximized");
			drv = new ChromeDriver(options);
			wait = new WebDriverWait(drv, TimeSpan.FromSeconds(5));
			drv.Navigate().GoToUrl($"{_BaseUrl}/CorpNet/Login.aspx");
			LoginToCorpNet();
		}

		protected void LoginToCorpNet()
		{
			wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("username")))
				.SendKeys(_User);
			drv.FindElement(By.Id("password"))
				.SendKeys(_Password);
			drv.FindElement(By.Name("_companyText"))
				.SendKeys(_Company);
			drv.FindElement(By.ClassName("login-submit-button"))
				.Click();
			wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.page-title")));
		}

		[OneTimeTearDown]
		public void ShutDown()
		{
			drv.Quit();
		}

		private void NavigateToPage()
		{
			drv.Navigate().GoToUrl($"{_BaseUrl}/corpnet/common/todolist.aspx");
		}

		private void OpenDialog()
		{
			drv.FindElement(By.ClassName("area-action background-border icon-add")).Click();
		}

		[Test, Order(1)]
		public void Test()
		{
			NavigateToPage();
			OpenDialog();
			Thread.Sleep(3000); // DEBUG //
		}
	}
}
