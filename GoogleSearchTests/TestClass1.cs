using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GoogleSearchTests
{
    public class TestClass1
    {
        IWebDriver driver;

        [Test]
        public void TestByClassName()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");
             
            var element = driver.FindElement(By.ClassName("navFooterBackToTopText"));
            string text = element.Text;
        }

        [Test]
        public void TestById()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            var element = driver.FindElement(By.Id("nav-cart-count"));
            element.Click();
        }

        [Test]
        public void TestByName()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.amazon.com/");

            var element = driver.FindElement(By.Name("dropdown-selection-ubb"));
            string text = element.GetAttribute("id");
        }

        [Test]
        public void TestByLinkText()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/link.html");

            var element = driver.FindElement(By.LinkText("click here"));
            string text = element.GetAttribute("href");
        }

        [Test]
        public void TestByPartialLinkText()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demo.guru99.com/test/accessing-link.html");

            var element = driver.FindElement(By. PartialLinkText("here"));
            string text = element.GetAttribute("href");
            System.Console.WriteLine(text);
        }

        [Test]
        public void TestByTagName()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            var element = driver.FindElement(By.TagName("h1"));
            string text = element.Text;
            System.Console.WriteLine(text);
        }

        [Test]
        public void NegativeTestByTagName()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            var element = driver.FindElement(By.TagName("h4"));
            string text = element.Text;
            System.Console.WriteLine(text);
        }

        [Test]
        public void TestByXpath()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            var element = driver.FindElement(By.XPath("//h1"));
            string text = element.Text;
            System.Console.WriteLine(text);
        }

        [Test]
        public void NegativeTestByXpath()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            var element = driver.FindElement(By.XPath("//h4"));
            string text = element.Text;
            System.Console.WriteLine(text);
        }

        [Test]
        public void TestByCssSelector()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://exe.ua/ua/");

            var element = driver.FindElement(By.CssSelector("div.page-header > h1"));
            string text = element.Text;
            System.Console.WriteLine(text);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    } 
}
