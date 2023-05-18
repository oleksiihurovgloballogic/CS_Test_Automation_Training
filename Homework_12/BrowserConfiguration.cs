using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Homework_12
{
    public class Tests
    {
        IWebDriver drv;

        [SetUp]
        public void Setup()
        {
            /// for the browsers started locally:
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=en_us");
            options.AddArgument("start-maximized");
            options.AddArgument("auto-open-devtools-for-tabs");
            //opt.AddArgument("headless");
            //opt.AddArgument("start-fullscreen");

            /// for the browsers started remotely:
            /// TBD

            drv = new ChromeDriver(options);
        }

        [TearDown]
        public void TearDown()
        {
            drv.Quit();
        }

        [Test]
        public void Test1()
        {
            drv.Navigate().GoToUrl("https://google.com");

            /// working with cookies:
            foreach (var cookie in drv.Manage().Cookies.AllCookies)
            {
                Console.WriteLine("\nDriver default cookies:\n" + cookie);
            }

            drv.Manage().Cookies.AddCookie(new Cookie(name: "myCookie", value: "myValue"));
            drv.Manage().Cookies.DeleteCookieNamed(name: "myCookie");

            /// seaching for the element in DOM tree: tag > attribute > value
            /// searching strategies: Id, Name, TagName, ClassName, LinkText

            //var myElement = drv.FindElement(By.Name("q"));
            //myElement.SendKeys(text: "Selenium");

            drv.FindElement(By.CssSelector("[name=q]")).SendKeys(text: "Selenium");
            drv.FindElement(By.Name("q")).SendKeys(text: "Selenium");
        }
    }
}
