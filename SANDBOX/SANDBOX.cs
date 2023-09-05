using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SANDBOX
{
	public class TestSuit
	{
		protected IWebDriver drv;
		protected WebDriverWait wait;
		protected static string _ChromeDriver = Environment.GetEnvironmentVariable("CHROMEDRIVER", EnvironmentVariableTarget.User);
		protected static string _BaseUrl = Environment.GetEnvironmentVariable("ENT_QA_BASE_URL", EnvironmentVariableTarget.User);
		protected static string _User = Environment.GetEnvironmentVariable("ENT_QA_USER", EnvironmentVariableTarget.User);
		protected static string _Password = Environment.GetEnvironmentVariable("ENT_QA_PASS", EnvironmentVariableTarget.User);
		protected static string _Company = Environment.GetEnvironmentVariable("ENT_QA_COMPANY", EnvironmentVariableTarget.User);

		[OneTimeSetUp]
		public void Setup()
		{
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("start-maximized");

			//drv = new ChromeDriver(options);
			var service = ChromeDriverService.CreateDefaultService(_ChromeDriver);
			drv = new ChromeDriver(service, options);

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
			var pageTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("page-title")));
			Thread.Sleep(3000); // DEBUG //
		}

		private void OpenDialog()
		{
			drv.FindElement(By.XPath("//ul[@class='plain-actions']/li[@class='area-action background-border icon-add']")).Click();
			Thread.Sleep(1000); // DEBUG //
		}

		private void FillInputFields()
		{
			const string ToDoTypeFieldXpath = "//span[@class='k-widget k-dropdown corrigo-text-field']//span[@class='k-input']";
			const string ToDoDescriptionFieldXpath = "//input[@data-bind='kendoCorrigoTextField: description']";
			const string ToDoAssignedToFieldXpath = "//div[@class='widget-control']//span[@class='k-widget k-combobox k-combobox-clearable corrigo-autocomplete']//input[@class='k-input']";
			const string ToDoDueByFieldXpath = "//input[@data-bind='kendoCorrigoDateTimePicker: dueBy']";

			drv.FindElement(By.XPath(ToDoTypeFieldXpath)).Click();
			Thread.Sleep(2000); // DEBUG //
			drv.FindElement(By.XPath(ToDoDescriptionFieldXpath)).SendKeys("d e s c r i p t i o n");
			Thread.Sleep(2000); // DEBUG //
			drv.FindElement(By.XPath(ToDoAssignedToFieldXpath)).SendKeys("System Administrator");
			Thread.Sleep(2000); // DEBUG //
			drv.FindElement(By.XPath(ToDoDueByFieldXpath)).SendKeys("9/4/2023 5:22 PM");
		}

		[Test, Order(1)]
		public void Test()
		{
			NavigateToPage();
			OpenDialog();
			FillInputFields();
			Thread.Sleep(2000); // DEBUG //
		}
	}
}
