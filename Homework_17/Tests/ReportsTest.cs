using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using Homework_17.Framework;


namespace Homework_17.Tests
{
	public class ReportsTest : BaseTest
	{
		private string _reportName = "";

		private void NavigateToReportsListPageByUrl()
		{
			drv.Navigate().GoToUrl($"{testUrl}/corpnet/report/reportlist.aspx");
			var pageTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("page-title")));
			Assert.That(pageTitle.Text, Is.EqualTo("REPORTS"));
		}

		private void ClickOnTheFirstReportInTheList()
		{
			var locator = By.CssSelector("table tr:nth-child(1) td.gc-ReportsListGrid-DisplayAs a");
			var reportNameLocator = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
			_reportName = reportNameLocator.Text;
			reportNameLocator.Click();

			var modalDialog = By.CssSelector("div[data-role='generatereportdialog']");
			wait.Until(ExpectedConditions.ElementIsVisible(modalDialog));
		}

		private void SelectToggleShowReportHeader()
		{
			var locator = By.XPath(
				"//div[contains(@class,'widget-label')]//label[contains(text(),'Show Report Header')]/.." +
				"/following-sibling::div//span[contains(@class,'k-switch-container')]"
			);
			var toogleLocator = drv.FindElement(locator);
			toogleLocator.Click();
		}

		private void ClickOnGenerateReportButton()
		{
			var buttonLocator = drv.FindElement(By.ClassName("id-generate-button"));
			buttonLocator.Click();
		}

		private void SwitchToReportResultsTab()
		{
			var windowHandlesCount = drv.WindowHandles.Count;
			wait.Until(drv => drv.WindowHandles.Count > windowHandlesCount);
			drv.SwitchTo().Window(drv.WindowHandles.Last());
			wait.Until(drv => drv.FindElement(By.CssSelector("[aria-label='Report table']")));
		}

		private void VerifyReportResultsTitle()
		{
			Assert.That(drv.Title, Is.EqualTo(_reportName));
		}

		private void CloseGeneratedReportTab()
		{
			drv.Close();
		}

		private void CloseGenerateReportDialog()
		{
			drv.SwitchTo().Window(drv.WindowHandles.First());
			var buttonLocator = drv.FindElement(By.ClassName("id-btn-close"));
			buttonLocator.Click();
		}

		[Test, Order(1)]
		public void GenerateReport()
		{
			NavigateToReportsListPageByUrl();
			ClickOnTheFirstReportInTheList();
			SelectToggleShowReportHeader();
			ClickOnGenerateReportButton();
			SwitchToReportResultsTab();
			VerifyReportResultsTitle();
			CloseGeneratedReportTab();
			CloseGenerateReportDialog();
		}
	}
}
