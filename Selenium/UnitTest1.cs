using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Selenium
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Users\\marti\\Downloads\\chromedriver_win32";

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FireFoxDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethodAdd()
        {
            string url = "file:///C:/Users/marti/OneDrive/Noter/Zealand/Programmering/3.%20Semester/VS/My%20Solution/REST%20+%20JavaScript%20from%20user%20stories/index.html";
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(500);
            IWebElement titleElement = _driver.FindElement(By.Id("address"));
            titleElement.SendKeys("UnitTest1");
            Thread.Sleep(500);
            IWebElement buttonElement = _driver.FindElement(By.Id("buttonNew"));
            buttonElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.Id("list"));
            Assert.AreEqual(2, listElements.Count);
        }

        [TestMethod]
        public void TestMethodwDeleteRecord()
        {
            string url = "file:///C:/Users/marti/OneDrive/Noter/Zealand/Programmering/3.%20Semester/VS/My%20Solution/REST%20+%20JavaScript%20from%20user%20stories/index.html";
            _driver.Navigate().GoToUrl(url);
            Thread.Sleep(500);
            IWebElement deleteElement = _driver.FindElement(By.Id("remove"));
            deleteElement.SendKeys("1");
            Thread.Sleep(500);
            IWebElement buttonElement = _driver.FindElement(By.Id("buttonOld"));
            buttonElement.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.Id("list"));
            Assert.AreEqual(3, listElements.Count);
        }
    }
}